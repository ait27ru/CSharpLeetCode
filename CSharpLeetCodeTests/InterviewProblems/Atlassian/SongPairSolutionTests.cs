using CSharpLeetCode.InterviewProblems.Atlassian;

namespace CSharpLeetCodeTests.InterviewProblems.Atlassian;

[TestClass()]
public class SongPairSolutionTests
{
    private readonly SongPairSolution _sut = new();

    [TestMethod()]
    public void FindSongPair_WhenNoMatchingPairs_ReturnEmptyList()
    {
        // act
        var result = _sut.FindSongPair(TestData.noMatchingPairs);

        // assert
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod()]
    public void FindSongPair_WhenOneMatchingPair_ReturnIt()
    {
        // act
        var result = _sut.FindSongPair(TestData.oneMatchingPair);

        // assert
        CollectionAssert.AreEqual(new List<string> { "Hey Ya!", "What's going on?" }, result);
    }

    [TestMethod()]
    public void FindSongPair_WhenMultipleMatchingPairs_ReturnTheFirstOne()
    {
        // act
        var result = _sut.FindSongPair(TestData.twoMatchingPairs);

        // assert
        CollectionAssert.AreEqual(new List<string> { "Hey Ya!", "What's going on?" }, result);
    }

}

static class TestData
{
    public static readonly List<Song> noMatchingPairs = [
        new Song("Hey Ya!", "3:54"),
        new Song("Dreams", "2:34"),
        new Song("Respect", "2:06"),
    ];

    public static readonly List<Song> oneMatchingPair = [
        new Song("Hey Ya!", "3:54"),
        new Song("Dreams", "2:34"),
        new Song("What's going on?", "3:06"),
        new Song("Respect", "2:06"),
    ];

    public static readonly List<Song> twoMatchingPairs = [
        new Song("Hey Ya!", "3:54"),
        new Song("Dreams", "2:34"),
        new Song("What's going on?", "3:06"),
        new Song("Respect", "2:06"),
        new Song("Imagine", "3:26"),
    ];
}