// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyBag.cs" company="Catel development team">
//   Copyright (c) 2008 - 2015 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Data
{
    using PropertyBagResearch;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    //using Catel.Reflection;

    /// <summary>
    /// Class that is able to manage all properties of a specific object in a thread-safe manner.
    /// </summary>
    public partial class PropertyBag : PropertyBagBase
    {
        #region Fields
        private readonly object _lockObject = new object();

        private readonly IDictionary<string, object> _properties;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBag"/> class.
        /// </summary>
        public PropertyBag()
            : this(new Dictionary<string, object>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBag"/> class.
        /// </summary>
        /// <param name="propertyDictionary">The property dictionary.</param>
        public PropertyBag(IDictionary<string, object> propertyDictionary)
        {
            _properties = propertyDictionary;
        }

        public PropertyBag(IDictionaryFactory factory)
            : this(factory.GenerateDictionary<object>())
        {
        }
        #endregion

        #region Methods
        public override bool IsAvailable(string name)
        {
            //Argument.IsNotNullOrWhitespace("name", name);

            lock (_lockObject)
            {
                return _properties.ContainsKey(name);
            }
        }

        public override string[] GetAllNames()
        {
            lock (_lockObject)
            {
                return _properties.Keys.ToArray();
            }
        }

        public override TValue GetValue<TValue>(string name, TValue defaultValue = default)
        {
            //Argument.IsNotNullOrWhitespace("name", name);

            lock (_lockObject)
            {
                if (_properties.TryGetValue(name, out var propertyValue))
                {
                    return (TValue)propertyValue;

                    //// Safe-guard null values for value types
                    //if (!(propertyValue is null) || typeof(TValue).IsNullableType())
                    //{
                    //    return (TValue)propertyValue;
                    //}
                }

                return defaultValue;
            }
        }

        public override void SetValue<TValue>(string name, TValue value)
        {
            //Argument.IsNotNullOrWhitespace("name", name);

            var raisePropertyChanged = false;

            lock (_lockObject)
            {
                if (!_properties.TryGetValue(name, out var propertyValue) || !ReferenceEquals(propertyValue, value))
                {
                    _properties[name] = value;
                    raisePropertyChanged = true;
                }
            }

            if (raisePropertyChanged)
            {
                RaisePropertyChanged(name);
            }
        }
        #endregion
    }
}
