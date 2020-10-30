using System;
using System.Collections.Generic;
using System.Linq;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => collection.Select(x => x).Where(y => predicate(y));

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => collection.Select(x => x).Where(y => !predicate(y));
}
