/*

Tree Decrements.

A tree can be represented as an unweighted undirected graph of t_nodes nodes numbered from 1 to t_nodes
and t_​nodes − 1 edges where the i-th edge connects the nodes numbered t_​from[i] and t_​to [i].

A value vall[i] is associated with the i-th node. In a single operation, two nodes can be selected, 
and their values can be decremented by 1 at a cost equal to the distance between the two nodes,
i.e., the number of edges in the simple path between them. It is possible to select the same node
for the operation and decrease its value by 2 at the cost of 0.

Given the tree, t, and the values val, find the minimum cost to decrease the values of all the nodes to 0.
It is guaranteed that the values of all the nodes can be decreased to exactly 0.

Example:

Suppose t_nodes = 3, t_from = [1, 1], t_to = [2, 3], val = [3, 1, 2]

The optimal strategy is to choose nodes 1 and 2 at cost 1. The val becomes [2, 0, 2]. 
Now nodes 1 and 1, followed by 3 and 3 can be chosen, each with a cost of 0.
Thus the total cost is 1 + 0 + 0 = 1.
 
 */

namespace CSharpLeetCode.InterviewProblems
{
    public class MinCostToDecreaseTreeNodesToZero
    {
        public int GetMinCost(List<int> val, int tNodes, List<int> tFrom, List<int> tTo)
        {
            // Modifying values to be their parity (0 or 1)
            for (int i = 0; i < val.Count; i++)
            {
                val[i] = val[i] % 2;
            }

            // Create adjacency list for the tree
            List<HashSet<int>> adjList = new List<HashSet<int>>(tNodes);
            for (int i = 0; i < tNodes; i++)
            {
                adjList.Add(new HashSet<int>());
            }

            // Build the tree
            for (int i = 0; i < tFrom.Count; i++)
            {
                adjList[tFrom[i] - 1].Add(tTo[i] - 1);
                adjList[tTo[i] - 1].Add(tFrom[i] - 1);
            }

            // Find initial leaves
            List<int> leaves = new List<int>();
            for (int i = 0; i < tNodes; i++)
            {
                if (adjList[i].Count == 1)
                {
                    leaves.Add(i);
                }
            }

            int remaining = tNodes;
            int cost = 0;

            // Process leaves
            while (leaves.Count > 0 && remaining > 2)
            {
                remaining -= leaves.Count;
                List<int> newLeaves = new List<int>();

                foreach (int leaf in leaves)
                {
                    // Each leaf only has one parent so pop any from adjList
                    int parent = adjList[leaf].First();
                    adjList[leaf].Remove(parent);
                    adjList[parent].Remove(leaf);

                    if (val[leaf] == 1)
                    {
                        cost += 1;
                        val[parent] = 1 - val[parent];
                    }

                    if (adjList[parent].Count == 1)
                    {
                        newLeaves.Add(parent);
                    }
                }

                leaves = newLeaves;
            }

            // Check if the remaining leaf is odd
            if (leaves.Count > 0 && val[leaves[0]] == 1)
            {
                cost += 1;
            }

            return cost;
        }
    }
}
