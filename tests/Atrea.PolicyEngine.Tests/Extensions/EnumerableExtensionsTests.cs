using Atrea.PolicyEngine.Internal.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Extensions;

[TestFixture]
public class EnumerableExtensionsTests
{
    [Test]
    public void Shuffle_ShouldReturnShuffledCollection()
    {
        // arrange
        var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // act
        var shuffledCollection = collection.Shuffle();

        // assert
        shuffledCollection.Should().NotBeInAscendingOrder();
    }
}