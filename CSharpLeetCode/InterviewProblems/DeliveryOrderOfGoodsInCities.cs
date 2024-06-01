/*

A manufacturing company is located in a certain city. Their goods need to be shipped to other cities that are connected with bidirectional roads,
though some cities may not be accessible because roads don't connect to them. The order of deliveries is determined first by distance, then by priority. 
Given the number of cities, their connections via roads, and what city the manufacturing company is located in, determine the order of cities
where the goods will be delivered.

For example, let's say that the number of cities is cityNodes = 4, where cityFrom = [1, 2, 2], cityTo = [2, 3, 4], and company = 1. 
In other words, the manufacturing company is located in city 1, and the roads run between cities 1 and 2, cities 2 and 3, and cities 2 and 4.

In this case, the cities would be visited based on the following logic:
• The closest city (or cities) is visited first. This is city 2, which is 1 unit from the manufacturing company.
• The next-closest city (or cities) is visited next. This is city 3 and city 4. which are both 2 units from the manufacturing company.
In this case, priority is then calculated, visiting the smaller- numbered city first (city 3) and continuing in ascending order (city 4).
Therefore, the order is [2, 3, 4], which is the answer you would return.

Another example, cityNodes = 3, where cityFrom = [1], cityTo = [2], and company = 2. 
City 1 is located 1 unit of distance away from the manufacturing company.
City 3 is not accessible because there are no roads connecting it to the manufacturing company's city. 
Therefore, the answer is [1].

One more example, cityNodes = 5, where cityFrom = [1, 1, 2, 3, 1], cityTo = [2, 3, 4, 5, 5], and company = 1. 
Cities 2, 3, and 5 are all 1 unit of distance away from the manufacturing company. 
These are visited based on priority in ascending order, so [2, 3, 5). 
City 4 is 2 units of distance away from the manufacturing company, so it is visited next. 
Therefore, the final order is [2, 3, 5, 4].

--------------------------------
v - vertices, e - edges.

Time complexity:

Create and initialise an adjacency dictionary.
It allows to easily iterate through the neighbours of the node.
Adjacency matrix would require iterating through all the nodes to identify a node's neighbours.
Time: O(v)

Fill the adjacency dictionary with connections. 
Time: O(e)

Perform BFS on the graph.
Time: O(v + e) (since each node enqued and dequeued at most once and we iterate over its neighbours (edges))

Return ordered list of cities: O(v * log(v))

Combined time: O(e + v * log(v))

--------------------------------
Space Complexity:

Fill the adjacency dictionary with connections: O(v + e) since cities dictionary may store all edges and vertices

Create a queue to do BFS on the graph: O(v) since the queue can hold at most v elements

Initialise distances dictionary, distance to each city: O(v)

Return ordered list of cities: O(v), the final list of cities can have at most v - 1 elements.

Combined space: O(v + e)

 */

namespace CSharpLeetCode.InterviewProblems
{
    public class DeliveryOrderOfGoodsInCities
    {
        public List<int> Order(int cityNodes, List<int> cityFrom, List<int> cityTo, int company)
        {
            Dictionary<int, List<int>> cities = new Dictionary<int, List<int>>();

            for (int i = 1; i <= cityNodes; i++)
            {
                cities[i] = new List<int>();
            }

            for (int i = 0; i < cityFrom.Count; i++)
            {
                cities[cityFrom[i]].Add(cityTo[i]);
                cities[cityTo[i]].Add(cityFrom[i]);
            }

            var queue = new Queue<int>([company]);

            // Distance to self is 0.
            var dist = new Dictionary<int, int> { { company, 0 } };

            // Perform BFS
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                foreach (int neighbor in cities[current])
                {
                    if (!dist.ContainsKey(neighbor))
                    {
                        dist[neighbor] = dist[current] + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return dist.Where(kvp => kvp.Key != company)
                                        .OrderBy(kvp => kvp.Value)
                                        .ThenBy(kvp => kvp.Key)
                                        .Select(kvp => kvp.Key)
                                        .ToList();
        }
    }
}
