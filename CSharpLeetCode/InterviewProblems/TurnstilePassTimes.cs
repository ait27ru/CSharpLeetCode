/*
A university is equipped with a single turnstile that serves both as an entry and an exit. 
Occasionally, this turnstile becomes congested as multiple individuals attempt to use it simultaneously in different directions.

Each individual arrives at the turnstile at a specific time, designated as time[i], 
and either wishes to exit (if direction[i] = 1) or enter (if direction[i] = 0) the university. 
They line up in two separate queues, one for exiting and one for entering, organized by their arrival times,
and by their order in the queue if their arrival times are the same.

The operation of the turnstile when individuals wish to pass at the same time is determined by the following rules:

* If the turnstile was not used in the previous second, the individual wishing to exit will proceed first.
* If the turnstile was last used to exit, then the next individual who wishes to exit will continue to do so.
* Conversely, if the turnstile was last used for entry, the next individual who wishes to enter will proceed first.

It takes one second for a person to pass through the turnstile.

The goal is to determine the exact time each individual successfully passes through the turnstile based on these conditions. 

--------------------------------
Time complexity: O(n)

--------------------------------
Space Complexity: O(n)

 */

namespace CSharpLeetCode.InterviewProblems
{
    public class TurnstilePassTimes
    {
        public List<int> GetTimes(List<int> times, List<int> directions)
        {
            var peopleCount = times.Count;
            times.Add(int.MaxValue);
            var timestamps = new int[peopleCount];
            var lines = new Queue<int>[] { new Queue<int>(), new Queue<int>() };
            int lastUsedDirection = -1;
            int currentTime = times[0];

            for (int person = 0; person < peopleCount; person++)
            {
                lines[directions[person]].Enqueue(person);

                // while time of the next person is greater than time of current person
                while (currentTime < times[person + 1])
                {
                    // if there are people in the entries queue and the last used direction was entry
                    if (lines[0].Count > 0 && lastUsedDirection == 0)
                    {
                        timestamps[lines[0].Dequeue()] = currentTime++;
                        lastUsedDirection = 0;
                    }
                    // if there are people in the exits queue
                    // also either the entries queue is empty or last used direction was exit
                    else if (lines[1].Count > 0)
                    {
                        timestamps[lines[1].Dequeue()] = currentTime++;
                        lastUsedDirection = 1;
                    }
                    // if there are people in the entries queue
                    // also either the entries queue is empty or last used direction was exit
                    // or exits queue is empty
                    else if (lines[0].Count > 0)
                    {
                        timestamps[lines[0].Dequeue()] = currentTime++;
                        lastUsedDirection = 0;
                    }
                    else
                    {
                        currentTime = times[person + 1];
                        lastUsedDirection = -1;
                    }
                }
            }
            return timestamps.ToList();
        }
    }
}
