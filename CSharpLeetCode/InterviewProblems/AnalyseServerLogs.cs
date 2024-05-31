/*
Implement a prototype service to analyze logs of requests to n servers.
The servers are indexed from 1 to n. The logs are given as a 2- dimensional array, log_data, of size m,
where log_data[i] = [server_id, time] denotes that a request was served by the server with id server_id at time.

Given log_data, an integer parameter x, and q queries, for each query[i], 
find the number of servers that did not receive a request in the time interval [query[i] - x, query[i]].

Example

Suppose n = 3, x = 5, m = 3, q = 2,
log_data[] = [[1, 3], [2, 6], [1, 5] ]
query[] = [10, 11].

Interval for query[0] = [5, 10], servers 1 and 2 received a request, server 3 didn't.
Interval for query[1] = [6, 11], server 2 received a request, servers 1 and 2 didn't.

Hence the answer is [1, 2].
--------------------------------
Time complexity:

The outer loop iterates over each element in the query list, which has m elements, where m is the length of the query list.
Within each iteration of the outer loop, there is an inner loop iterating over each element in the log_data list.
The log_data list has p sublists, where each sublist contains two integers.
Both loops run independently of each other, so we can consider their time complexity separately.
Since the inner loop is nested within the outer loop, the total time complexity is the product 
of the time complexities of the outer and inner loops.

O (m * p)
--------------------------------
Space Complexity:

The space complexity mainly depends on the size of the respondedServers HashSet.
The maximum size of the HashSet is the number of unique server IDs that respond within the time range [minTime, maxTime].
In the worst case, if all servers respond within this time range, the HashSet could potentially contain n elements, where n is the total number of servers.
However, the actual size of the HashSet depends on the number of distinct server IDs present in the given time range.
Additionally, the space complexity also includes the space required for the result list, which holds the results for each query.
Overall, the space complexity is determined by the size of the largest HashSet created during the execution of the algorithm.

O(n) (worst-case scenario for the HashSet)
O(m) (space required for the result list)

 */

namespace CSharpLeetCode.InterviewProblems
{
    public class AnalyseServerLogs
    {
        public List<int> GetStaleServerCount(int n, List<List<int>> log_data, List<int> query, int X)
        {
            var result = new List<int>();

            foreach (var q in query)
            {
                var minTime = q - X;
                var maxTime = q;

                var respondedServers = new HashSet<int>();

                foreach (var log in log_data)
                {
                    var server = log[0];
                    var time = log[1];

                    if (time >= minTime && time <= maxTime)
                    {
                        respondedServers.Add(server);
                    }
                }
                var nonRespondedServers = n - respondedServers.Count();
                result.Add(nonRespondedServers);
            }
            return result;
        }
    }
}
