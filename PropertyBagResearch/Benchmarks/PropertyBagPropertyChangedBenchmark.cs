// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyBagPropertyChangedBenchmark.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace PropertyBagResearch.Benchmarks
{
    using System;

    using BenchmarkDotNet.Attributes;

    /// <summary>
    ///     The property bag property changed benchmark.
    /// </summary>
    public class PropertyBagPropertyChangedBenchmark : BenchmarkBase
    {
        private const int PropertyCount = 10;

        private static readonly bool[] BoolValues = new[] { true, false };

        private IDictionaryFactory _dictionaryFactory;

        private IPropertyBag _propertyBag;

        private Random _random;

        [Params(typeof(DictionaryFactory))]
        public Type DictionaryFactoryType { get; set; }

        [Params(typeof(NonTypedPropertyBag), typeof(SuperTypedPropertyBag), typeof(TypedPropertyBag))]
        public Type ProperyBagType { get; set; }

        [Benchmark]
        public void PropertyChanged()
        {
            for (int i = 0; i < 5000; i++)
            {
                for (var j = 0; j < PropertyCount; j++)
                {
                    _propertyBag.SetValue($"Int{j}", _random.Next(1000));
                }

                for (var j = 0; j < PropertyCount; j++)
                {
                    _propertyBag.SetValue($"Bool{j}", BoolValues[_random.Next(1000) % 2]);

                }

                for (var j = 0; j < PropertyCount; j++)
                {
                    _propertyBag.SetValue($"Ref{j}", new object());
                }
            }
        }

        [GlobalSetup]
        public void Setup()
        {
            _dictionaryFactory = Activator.CreateInstance(DictionaryFactoryType) as IDictionaryFactory;
            _propertyBag = Activator.CreateInstance(ProperyBagType, _dictionaryFactory) as IPropertyBag;

            _random = new Random(1000);

            for (var i = 0; i < PropertyCount; i++)
            {
                _propertyBag.SetValue($"Int{i}", 0);
            }

            for (var i = 0; i < PropertyCount; i++)
            {
                _propertyBag.SetValue($"Bool{i}", false);
            }

            for (var i = 0; i < PropertyCount; i++)
            {
                _propertyBag.SetValue($"Ref{i}", new object());
            }
        }
    }
}