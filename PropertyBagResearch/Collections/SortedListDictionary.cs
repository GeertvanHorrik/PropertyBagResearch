// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortedList2.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace PropertyBagResearch.Collections
{
    public class SortedListDictionary<TKey, TValue> : SortedList<TKey, TValue>, IDictionary<TKey, TValue>
    {
    }
}