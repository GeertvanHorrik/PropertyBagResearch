// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyBagAllocBenchmark.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace PropertyBagResearch.Benchmarks
{
    using System;

    using BenchmarkDotNet.Attributes;
    using Catel.Data;

    /// <summary>
    ///     The property bag alloc benchmark.
    /// </summary>
    public class PropertyBagAllocBenchmark : BenchmarkBase
    {
        private IDictionaryFactory _dictionaryFactory;

        private IPropertyBag _propertyBag;

        [Params(typeof(DictionaryFactory))]
        public Type DictionaryFactoryType { get; set; }

        [Params(typeof(PropertyBag), typeof(TypedPropertyBag))]
        public Type ProperyBagType { get; set; }

        [Benchmark]
        public void AllocProperties()
        {
            const int PropertyCount = 10;
            for (var i = 0; i < PropertyCount; i++)
            {
                _propertyBag.SetValue<int>($"Int{i}", 0);
            }

            for (var i = 0; i < PropertyCount; i++)
            {
                _propertyBag.SetValue<bool>($"Bool{i}", true);
            }

            for (var i = 0; i < PropertyCount; i++)
            {
                _propertyBag.SetValue<object>($"Ref{i}", new object());
            }
        }

        [GlobalSetup]
        public void Setup()
        {
            _dictionaryFactory = Activator.CreateInstance(DictionaryFactoryType) as IDictionaryFactory;
            _propertyBag = Activator.CreateInstance(ProperyBagType, _dictionaryFactory) as IPropertyBag;
        }
    }
}