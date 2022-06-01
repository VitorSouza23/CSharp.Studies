//Source from: https://www.geeksforgeeks.org/dijkstras-shortest-path-algorithm-greedy-algo-7/
var V = 9;

var g = new int[, ] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
    { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
    { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
    { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

Dijkstra(g, 0);


int MinDistance(int[] dist, bool[] sptSet)
{
    int min = int.MaxValue, min_index = -1;

    for (var v = 0; v < V; v++)
    {
        if (sptSet[v] != false || dist[v] > min) continue;
        min = dist[v];
        min_index = v;
    }

    return min_index;
}

void PrintSolution(int[] dist)
{
    Console.WriteLine("Vertex \t\t Distance from Source");
    for(int i = 0; i < V; i++)
        Console.WriteLine($"{i} \t\t {dist[i]}");
}

void Dijkstra(int[,] graph, int src)
{
    var dist = new int[V];
    var sptSet = new bool[V];
    Array.Fill(dist, int.MaxValue);

    dist[src] = 0;

    for (int count = 0; count < V - 1; count++)
    {
        int u = MinDistance(dist, sptSet);
        sptSet[u] = true;

        for (int v = 0; v < V; v++)
        {
            if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                dist[v] = dist[u] + graph[u, v];
        }
    }
    
    PrintSolution(dist);
}

