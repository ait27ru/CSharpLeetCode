
/*
 * 
We are implementing a security system for a badged-access room within our company's premises. 
Given a sequential list of employees who used their badges to enter or exit the room, write a function that returns two collections:

Employees who failed to use their badge to exit the room: These employees logged an entry without a corresponding exit.
(All employees must exit the room before the log concludes.)

Employees who failed to use their badge to enter the room: These employees logged an exit without a corresponding entry. 
(The room is empty at the start of the log.)

Each collection should only include unique entries, regardless of how many times an employee meets the criteria for inclusion.

*/

namespace CSharpLeetCode.InterviewProblems
{
    public class BadgeAccessTrackerMatchEntriesSolution
    {
        public (List<string> missingExits, List<string> missingEntries) FindNonMatchingRecords(IEnumerable<(string name, string action)> records)
        {
            var room = new HashSet<string>();
            var missingExits = new HashSet<string>();
            var missingEntries = new HashSet<string>();

            var actionsByName = new Dictionary<string, string>();

            foreach (var (employee, action) in records)
            {
                if (action == "enter")
                {
                    if (room.Contains(employee))
                    {
                        missingExits.Add(employee);
                    } else
                    {
                        room.Add(employee);
                    }
                }
                else if (action == "exit")
                {
                    if (!room.Contains(employee))
                    {
                        missingEntries.Add(employee);
                    }
                    else
                    {
                        room.Remove(employee);
                    }
                }
            }

            missingExits.UnionWith(room);

            return (missingExits.ToList(), missingEntries.ToList());
        }
    }
}
