// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedListDictionaryFactory.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using PropertyBagResearch.Collections;

namespace PropertyBagResearch
{
    public class SortedListDictionaryFactory : IDictionaryFactory
    {
        public IDictionary<string, TValue> GenerateDictionary<TValue>()
        {
            return new SortedListDictionary<string, TValue>();;
        }
    }
}