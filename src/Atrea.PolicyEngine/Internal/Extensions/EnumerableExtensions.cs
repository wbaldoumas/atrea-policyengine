using System;
using System.Collections.Generic;
using System.Linq;

namespace Atrea.PolicyEngine.Internal.Extensions;

internal static class EnumerableExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.OrderBy(_ => Random.Shared.Next());
}