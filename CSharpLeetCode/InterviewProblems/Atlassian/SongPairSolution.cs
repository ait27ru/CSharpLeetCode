/*
 * Given a list of songs, find a pair in the list whose combined length is exactly 7 minutes. 
 * Each item in the list is a song represented by its name and length in the format "mm:ss".
 * If there are multiple pairs, you may return any one of them.
 * 
 */

using System.Runtime.CompilerServices;

namespace CSharpLeetCode.InterviewProblems.Atlassian;

public class SongPairSolution
{
    public List<string> FindSongPair(List<Song> songs)
    {
        const int TargetTimeInSeconds = 7 * 60;

        var timeToIndexMap = new Dictionary<int, int>();

        var result = new List<string>();

        for (int i = 0; i < songs.Count; i++)
        {
            var songLengthInSeconds = ConvertToSeconds(songs[i].Duration);

            if (timeToIndexMap.TryGetValue(songLengthInSeconds, out int pairedIndex))
            {
                result.Add(songs[pairedIndex].Name);
                result.Add(songs[i].Name);
                return result;
            }
            var complementaryTime = TargetTimeInSeconds - songLengthInSeconds;
            timeToIndexMap[complementaryTime] = i;
        }
        return result;
    }

    private static int ConvertToSeconds(string time) =>
        time.Split(':') is { Length: 2 } timeParts
            ? int.Parse(timeParts[0]) * 60 + int.Parse(timeParts[1])
            : throw new FormatException("Invalid time format");
}

public record Song(string Name, string Duration);
