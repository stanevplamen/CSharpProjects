using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
             {
                foreach (var child in node.Childred)
                {
                    hasParent[child.Value] = true; //  доказваме че този връх с този индекс е наследник
                }
            }

            // trqbwa da imame nakraq edin false

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("nodes", "The tree has no root");
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> midNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Childred.Count > 0)
                {
                    midNodes.Add(node);
                }
            }

            return midNodes;
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Childred.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Childred.Count == 0)
            {
                return 0; // имаме един връх без наследници
            }
            int maxPath = 0;
            foreach (var node in root.Childred)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }
            return maxPath + 1;
        }

        static int CheckSum(int sum, int currentSum, int currentNodeValue, List<int> currentNodes)
        {
            if (currentSum == sum)
            {
                //Console.Write("{0}, ", currentNode.Value);
                foreach (var nodeValue in currentNodes)
                {
                    Console.Write("{0}, ", nodeValue);
                }
                Console.WriteLine();
            }
            currentSum = currentSum - currentNodeValue;
            return currentSum;
        }


        public static void TraverseDFS(Node<int>[] nodes, int sum)
        {
            Console.WriteLine("The path members which sum is equal to {0} are: ", sum);
            Stack<Node<int>> stack = new Stack<Node<int>>();
            int currentSum = 0;
            foreach (var node in nodes)
            {
                List<int> currentNodes = new List<int>();
                stack.Push(node);
                currentSum = 0;
                while (stack.Count > 0)
                {
                    Node<int> currentNode = stack.Pop();
                    if (stack.Count == 0 && currentNode.Childred.Count != 0)
                    {
                        if (currentNode != node)
                        {
                            currentSum = node.Value + currentNode.Value;
                            currentNodes.RemoveAt(currentNodes.Count - 1);
                        }
                        else
                        {
                            currentSum = node.Value;
                        }
                    }
                    else
                    {
                        currentSum = currentNode.Value + currentSum;
                    }
                    currentNodes.Add(currentNode.Value);
                    if (currentNode.Childred.Count > 0)
                    {
                        for (int i = 0; i < currentNode.Childred.Count; i++)
                        {
                            Node<int> childNode = currentNode.Childred[i];
                            stack.Push(childNode);
                        }
                    }
                    else
                    {
                        currentSum = CheckSum(sum, currentSum, currentNode.Value, currentNodes);
                        currentNodes.RemoveAt(currentNodes.Count - 1);
                    }
                }
            }
        }

        public static void TraverseDFSsubTree(Node<int>[] nodes, int sum, Node<int> root)
        {
            Console.WriteLine("The subtrees which sum is equal to {0} are: ", sum);
            Stack<Node<int>> stack = new Stack<Node<int>>();
            int currentSum = 0;
            foreach (var node in nodes)
            {
                if (node == root)
                {
                    continue;
                }
                List<int> currentSubtreeNodes = new List<int>();
                stack.Push(node);
                currentSum = 0;
                while (stack.Count > 0)
                {
                    Node<int> currentNode = stack.Pop();
                    currentSum = currentNode.Value + currentSum;
                    currentSubtreeNodes.Add(currentNode.Value);
                    for (int i = 0; i < currentNode.Childred.Count; i++)
                    {
                        Node<int> childNode = currentNode.Childred[i];
                        stack.Push(childNode);
                    }
                }
                if (currentSum == sum)
                {
                    foreach (var nodeValue in currentSubtreeNodes)
                    {
                        Console.Write("{0}, ", nodeValue);
                    }
                    Console.WriteLine();
                }
            }
        }      

        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[N]; // масив в който ще пазим елементите на съответното ниво

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i); // е елеменра от масива i ще запишем стойност с индекс i
            }

            for (int i = 1; i <= N - 1; i++) // толкова реда четем и извличаме инфото
            {
                string edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                int parentId = int.Parse(edgeParts[0]);
                int childId = int.Parse(edgeParts[1]);

                nodes[parentId].Childred.Add(nodes[childId]); // така ги закачаме (дърпаме ги по индекси от горния масив)
                nodes[childId].HasParent = true; // гарантираме си актуалността на инфоро - че всяко дете си има родител
            }

            // 1. Find the root
            Node<int> root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            // 2. Find all leafs
            var leafs = FindAllLeafs(nodes);
            Console.WriteLine("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }
            Console.WriteLine();

            // 3. Find all middle nodes
            var moddleNodes = FindAllMiddleNodes(nodes);
            Console.WriteLine("Middle nodes: ");
            foreach (var node in moddleNodes)
            {
                Console.Write("{0}, ", node.Value);
            }
            Console.WriteLine();

            // 4. Find the longest path from the root
            var longestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine("Longest path from the root: {0}", longestPath);

            // 5. Find all paths summed equal to number
            int sum = 6;
            TraverseDFS(nodes, sum);

            // 6. Find all sub trees summed equal to number
            sum = 12; // 6
            TraverseDFSsubTree(nodes, sum, root);
        }     
    }
}
