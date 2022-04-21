namespace DataStructuresAlgosRefresher.DataStructures
{
    enum SearchType
    {
        DepthFirstSearch,
        BreadthFirstSearch
    }

    internal class Graph
    {
        private Dictionary<int, Node> _nodeDict = new Dictionary<int, Node>();

        private Node GetNode(int id)
        {
            return _nodeDict.GetValueOrDefault(id);
        }

        public void AddNode(int id)
        {
            _nodeDict.Add(id, new Node(id));
        }

        public void AddEdge(int source, int destination)
        {
            if (!_nodeDict.ContainsKey(destination))
            {
                var node = new Node(destination);
                _nodeDict.Add(destination, node);
            }

            var s = GetNode(source);
            var d = GetNode(destination);
            s.adjacent.AddLast(d);
        }

        public bool HasPath(SearchType type, int source, int destination)
        {
#if DEBUG
            Console.WriteLine();
#endif
            if (type == SearchType.DepthFirstSearch)
            {
                return DepthFirstSearch(source, destination);
            }
            else
            {
                return BreadthFirstSearch(source, destination);
            }
        }

        private bool DepthFirstSearch(int source, int destination)
        {
            var s = GetNode(source);
            var d = GetNode(destination);
            var visited = new HashSet<int>();
            return HasPathDFS(s, d, visited);
        }

        private bool HasPathDFS(Node source, Node destination, HashSet<int> visited) // recursive
        {
#if DEBUG   
            Console.WriteLine($"Depth-first search source id: {source.id}, destination id: {destination.id}, visited.Count: {visited.Count}");
#endif
            if (visited.Contains(source.id))
            {
                return false;
            }    
            visited.Add(source.id);
            if (source == destination)
            {
                return true;
            }
            foreach (Node child in source.adjacent)
            {
                if (HasPathDFS(child, destination, visited))
                {
                    return true;
                }
            }
            return false;
        }

        private bool BreadthFirstSearch(int source, int destination)
        {
            var s = GetNode(source);
            var d = GetNode(destination);
            var visited = new HashSet<int>();
            return HasPathBFS(s, d, visited);
        }

        private bool HasPathBFS(Node source, Node destination, HashSet<int> visited) // iterative
        {
            System.Collections.Generic.LinkedList<Node> nextToVisit = new System.Collections.Generic.LinkedList<Node>();
            nextToVisit.AddLast(source);
            while (nextToVisit.Count > 0)
            {
#if DEBUG
                Console.WriteLine($"Breadth-first search nextToVisit.first.id: {nextToVisit.First().id}, destination id: {destination.id}, nextToVisit.Count: {nextToVisit.Count}");
#endif
                var node = nextToVisit.First();
                nextToVisit.RemoveFirst();
                if (node == destination)
                {
                    return true;
                }

                if (visited.Contains(node.id))
                {
                    continue;
                }
                visited.Add(node.id);

                foreach (Node child in node.adjacent)
                {
                    nextToVisit.AddLast(child);
                }
            }
            return false;
        }

        private class Node
        {
            public int id;
            public System.Collections.Generic.LinkedList<Node> adjacent = new System.Collections.Generic.LinkedList<Node>();

            public Node(int id)
            {
                this.id = id;
            }
        }
    }
}
