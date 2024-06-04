﻿using System.Collections.Generic;

namespace Kibali;

public class OrderedPairEqualityComparer : IEqualityComparer<(string, string)>
{
    public bool Equals((string, string) x, (string, string) y)
    {
        // Check if the items are equal regardless of order
        return (x.Item1 == y.Item1 && x.Item2 == y.Item2) || (x.Item1 == y.Item2 && x.Item2 == y.Item1);
    }

    public int GetHashCode((string, string) obj)
    {
        int h1 = obj.Item1?.GetHashCode() ?? 0;
        int h2 = obj.Item2?.GetHashCode() ?? 0;

        // Use a commutative and associative operation to combine hash codes
        // This ensures that (A, B) and (B, A) have the same hash code
        return h1 ^ h2;
    }
}
