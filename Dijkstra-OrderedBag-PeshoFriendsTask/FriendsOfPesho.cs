using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace FriendsOfPesho
{
    public class Node : IComparable
    {
        public int ID { get; private set; }
        public int DijkstraDistance { get; set; }

        public Node(int id)
        {
            this.ID = id;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class Connection
    {
        public Node Node { get; set; }
        public int Distance { get; set; }

        public Connection(Node node, int distance)
        {
            this.Node = node;
            this.Distance = distance;
        }
    }

    class MainProgram
    {
        static Dictionary<Node, List<Connection>> graph;
        static Dictionary<int, Node> uniqueNodes;
        static int allNodes;
        static int streetsNumber;
        static int allHospitals;
        static HashSet<int> hospitalsSet;
        static Node currentNode;

        static void DijkstraAlgorithm(Node source)
        {
            OrderedBag<Node> priorQueue = new OrderedBag<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = int.MaxValue;
            }

            source.DijkstraDistance = 0;
            priorQueue.Add(source);

            while (priorQueue.Count != 0)
            {
                currentNode = priorQueue.GetFirst();
                priorQueue.RemoveFirst();

                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    int potDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijkstraDistance)
                    {
                        neighbour.Node.DijkstraDistance = potDistance;
                        priorQueue.Add(neighbour.Node);
                    }
                }
            }
        }


        static void Main()
        {
            LoadTheInput();

            int minDijkstraSum = int.MaxValue;

            foreach (var host in hospitalsSet)
            {
                DijkstraAlgorithm(uniqueNodes[host]);

                int currentSum = 0;

                foreach (var item in uniqueNodes)
                {
                    if (!hospitalsSet.Contains(item.Key))
                    {
                        currentSum += item.Value.DijkstraDistance;
                    }
                }

                if (currentSum < minDijkstraSum)
                {
                    minDijkstraSum = currentSum;
                }
            }

            Console.WriteLine(minDijkstraSum);
        }

        private static void LoadTheInput()
        {
            string firstLine = Console.ReadLine();
            string[] splitedFirst = firstLine.Split();
            allNodes = int.Parse(splitedFirst[0]);
            streetsNumber = int.Parse(splitedFirst[1]);
            allHospitals = int.Parse(splitedFirst[2]);

            string secondLine = Console.ReadLine();
            string[] splitInput = secondLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            FillTheHospitals(splitInput);

            FillTheStreets();
        }

        private static void FillTheHospitals(string[] arrayToConvert)
        {
            hospitalsSet = new HashSet<int>();
            for (int i = 0; i < arrayToConvert.Length; i++)
            {
               hospitalsSet.Add(int.Parse(arrayToConvert[i].Trim()));
            }
        }

        private static void FillTheStreets()
        {
            graph = new Dictionary<Node, List<Connection>>();
            uniqueNodes = new Dictionary<int, Node>();
            for (int i = 0; i < streetsNumber; i++)
            {
                string thirdLine = Console.ReadLine();
                string[] splitedThird = thirdLine.Split();
                int currentFirstNode = int.Parse(splitedThird[0]);
                int currentSecondNode = int.Parse(splitedThird[1]);
                int currentStreetLength = int.Parse(splitedThird[2]);

                if (!uniqueNodes.ContainsKey(currentFirstNode))
                {
                    Node firstUniqueNode = new Node(currentFirstNode);
                    uniqueNodes.Add(currentFirstNode, firstUniqueNode);
                }

                if (!uniqueNodes.ContainsKey(currentSecondNode))
                {
                    Node secondUniqueNode = new Node(currentSecondNode);
                    uniqueNodes.Add(currentSecondNode, secondUniqueNode);
                }

                if (!graph.ContainsKey(uniqueNodes[currentFirstNode]))
                {
                    graph.Add(uniqueNodes[currentFirstNode], new List<Connection>());
                }

                if (!graph.ContainsKey(uniqueNodes[currentSecondNode]))
                {
                    graph.Add(uniqueNodes[currentSecondNode], new List<Connection>());
                }

                graph[uniqueNodes[currentFirstNode]].Add(new Connection(uniqueNodes[currentSecondNode], currentStreetLength));
                graph[uniqueNodes[currentSecondNode]].Add(new Connection(uniqueNodes[currentFirstNode], currentStreetLength));
            }
        }
    }
}
