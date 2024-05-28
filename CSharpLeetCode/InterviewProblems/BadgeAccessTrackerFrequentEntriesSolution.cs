
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

namespace CSharpLeetCode.InterviewProblems
{
    public class BadgeAccessTrackerFrequentEntriesSolution
    {
        public List<ValueTuple<string, List<int>>> FindFrequentUsers(IEnumerable<ValueTuple<string, int>> records)
        {
            var result = new List<ValueTuple<string, List<int>>>();

            var entryTimesByName = new Dictionary<string, List<int>>();

            foreach (var (userName, entryTime) in records)
            {
                if (!entryTimesByName.ContainsKey(userName))
                {
                    entryTimesByName[userName] = new List<int>();
                }
                entryTimesByName[userName].Add(entryTime);
            }

            foreach (var times in entryTimesByName.Values)
            {
                times.Sort();                
            }

            foreach (var (userName, entryTimes) in entryTimesByName)
            {
                if (entryTimes.Count < 3)
                    continue;

                for (int i = 0; i <= entryTimes.Count - 3; i++)
                {
                    int startTime = entryTimes[i];

                    for (int j = i + 2; j < entryTimes.Count; j++)
                    {
                        if (entryTimes[j] - startTime <= 100)
                        {
                            // The 3rd time from startTime is within one hour
                            result.Add((userName, entryTimes.GetRange(i, j - i + 1)));
                            break;
                        }
                        if (entryTimes[j] - startTime > 100)
                        {
                            // The 3rd time from startTime exceeds one hour
                            break;
                        }
                    }

                    // If a record exists for a user, that's enough
                    if (result.Any(r => r.Item1 == userName)) break;
                }
            }
            return result;
        }
    }
}