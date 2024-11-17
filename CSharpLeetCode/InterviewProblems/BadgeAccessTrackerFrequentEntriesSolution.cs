
/*

We are developing a security system for a badged-access room within our company's building and need to 
identify employees who entered the secured room unusually frequently. 

We have an unordered list of names and entry times recorded over a single day. Access times are provided 
as four-digit numbers in 24-hour format, such as "0800" or "2250".

Write a function that identifies any employee who badged into the room three or more times within a one-hour window.
Your function should return each employee who meets this criterion, 
along with the times they badged in during the one-hour period. 

If an employee meets this condition in multiple one-hour periods, return the earliest period for that employee.

 */

namespace CSharpLeetCode.InterviewProblems;

public class BadgeAccessTrackerFrequentEntriesSolution
{
    public List<(string name, List<int> times)> FindFrequentUsers(IEnumerable<(string name, int time)> records)
    {
        var result = new List<(string name, List<int> times)>();

        var timesByName = records.ToLookup(r => r.name, r => r.time);

        foreach (var group in timesByName)
        {
            var name = group.Key;
            var entryTimes = group.ToList();
            entryTimes.Sort();

            if (entryTimes.Count < 3)
                continue;

            for (int i = 0; i <= entryTimes.Count - 3; i++)
            {
                int startTime = entryTimes[i];

                if (entryTimes[i + 2] - startTime <= 100)
                {
                    result.Add((name, entryTimes.GetRange(i, 3)));
                    break;
                }
            }
        }
        return result;
    }
}