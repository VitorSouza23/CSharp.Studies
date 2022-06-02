//Original source from https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/

Graph g = new(4);

g.AddEdge(0, 1);
g.AddEdge(0, 2);
g.AddEdge(1, 2);
g.AddEdge(2, 0);
g.AddEdge(2, 3);
g.AddEdge(3, 3);

g.Bfs(2);

internal class Graph
{
    private readonly int _numberOfVertices;
    private readonly Queue<int>[] _adjacencyList;

    public Graph(int numberOfVertices)
    {
        _numberOfVertices = numberOfVertices;
        _adjacencyList = new Queue<int>[numberOfVertices];
        Array.Fill(_adjacencyList, new Queue<int>());
    }

    public void AddEdge(int verticeSource, int verticeDestination)
    {
        _adjacencyList[verticeSource].Enqueue(verticeDestination);
    }

    public void Bfs(int start)
    {
        var visited = new bool[_numberOfVertices];
        Queue<int> queue = new();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Any())
        {
            start = queue.Dequeue();
            Console.WriteLine(start + " ");

            var list = _adjacencyList[start];

            foreach (var val in list.Where(val => visited[val] is false))
            {
                visited[val] = true;
                queue.Enqueue(val);
            }
        }
    }
}
