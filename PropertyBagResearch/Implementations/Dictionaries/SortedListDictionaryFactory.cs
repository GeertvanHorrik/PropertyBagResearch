// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedListDictionaryFactory.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace PropertyBagResearch
{
    using System.Collections.Generic;

    using PropertyBagResearch.Collections;

    public class SortedListDictionaryFactory : IDictionaryFactory
    {
        public IDictionary<string, TValue> GenerateDictionary<TValue>()
        {
            return new SortedListDictionary<string, TValue>();
            
        }
    }
}