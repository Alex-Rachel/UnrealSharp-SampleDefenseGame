using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedMiniJam1742;

public static class LinqExtensions
{
    private static readonly Random _random = new Random();

    public static T RandomElement<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        var list = source as IList<T> ?? source.ToList();
        if (!list.Any())
            throw new InvalidOperationException("Sequence contains no elements.");

        int index = _random.Next(list.Count);
        return list[index];
    }
}