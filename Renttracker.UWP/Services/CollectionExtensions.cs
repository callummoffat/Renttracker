using MyToolkit.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Renttracker.Services
{
    public static class CollectionExtensions
    {
        public static void FilterCollection<T>(this ObservableCollectionView<T> collection, IEnumerable<Func<T, bool>> filters)
        {
            collection.Filter = a =>
            {
                var matches = true;

                filters.ToList().ForEach(b =>
                {
                    if (!b.Invoke(a).Equals(true))
                        matches = false;
                });

                return matches;
            };
        }
    }
}
