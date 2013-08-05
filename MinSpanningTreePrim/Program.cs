using System;
using System.Collections.Generic;

class PrimAlgorithm
{
    static int startingNode = 1;
    static HashSet<int> visitedNodes;

    static void Main(string[] args)
    {
        SortedSet<Edge> priorityQueue = new SortedSet<Edge>();
        visitedNodes = new HashSet<int>();
        List<Edge> mpdNodes = new List<Edge>();
        List<Edge> edges = new List<Edge>();

        LoadTheGraph(edges);

        // checking for both start and end node because we have double directions paths
        for (int i = 0; i < edges.Count; i++)
        {
            if (edges[i].StartNode == startingNode)
            {
                priorityQueue.Add(edges[i]);
            }
            else if (edges[i].EndNode == startingNode)
            {
                priorityQueue.Add(edges[i]);
            }
        }
        // starting from the first node /house/
        visitedNodes.Add(startingNode);

        FindMinimumSpanningTree(priorityQueue, mpdNodes, edges);

        PrintMinimumSpanningTree(mpdNodes);
    }

    #region Prim`s algorithm
    private static void FindMinimumSpanningTree(SortedSet<Edge> priorityQueue, List<Edge> mpdEdges, List<Edge> edges) 
    {
        while (priorityQueue.Count > 0)
        {
            Edge edge = priorityQueue.Min;
            priorityQueue.Remove(edge);

            if (!visitedNodes.Contains(edge.EndNode))
            {
                mpdEdges.Add(edge);
                AddEdgesFromEnd(edge, edges, mpdEdges, priorityQueue);
                visitedNodes.Add(edge.EndNode);
            }
            else if (!visitedNodes.Contains(edge.StartNode))
            {
                mpdEdges.Add(edge);
                AddEdgesFromStart(edge, edges, mpdEdges, priorityQueue);
                visitedNodes.Add(edge.StartNode);
            }
        }
    }

    private static void AddEdgesFromEnd(Edge edge, List<Edge> edges, List<Edge> mpd, SortedSet<Edge> priorityQueue)
    {
        for (int i = 0; i < edges.Count; i++)
        {
            if (!mpd.Contains(edges[i]))
            {
                if (edge.EndNode == edges[i].StartNode)
                {
                    priorityQueue.Add(edges[i]);
                }
                else if (edge.EndNode == edges[i].EndNode)
                {
                    priorityQueue.Add(edges[i]);
                }
            }
        }
    }

    private static void AddEdgesFromStart(Edge edge, List<Edge> edges, List<Edge> mpd, SortedSet<Edge> priorityQueue)
    {
        for (int i = 0; i < edges.Count; i++)
        {
            if (!mpd.Contains(edges[i]))
            {
                if (edge.StartNode == edges[i].StartNode)
                {
                    priorityQueue.Add(edges[i]);
                }
                else if (edge.StartNode == edges[i].EndNode)
                {
                    priorityQueue.Add(edges[i]);
                }
            }
        }
    }
    #endregion Prim`s algorithm

    private static void LoadTheGraph(List<Edge> edges)
    {
        edges.Add(new Edge(1, 2, 5));
        edges.Add(new Edge(4, 1, 2));
        edges.Add(new Edge(1, 3, 1));
        edges.Add(new Edge(3, 4, 4));
        edges.Add(new Edge(4, 5, 1));
        edges.Add(new Edge(2, 4, 3));
        edges.Add(new Edge(5, 2, 1));
        edges.Add(new Edge(2, 3, 20));
    }

    private static void PrintMinimumSpanningTree(List<Edge> mpdNodes)
    {
        for (int i = 0; i < mpdNodes.Count; i++)
        {
            Console.WriteLine("{0}", mpdNodes[i]);
        }
    }
}


