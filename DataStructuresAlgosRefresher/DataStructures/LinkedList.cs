namespace DataStructuresAlgosRefresher.DataStructures
{
    internal class LinkedList<T>
    {
        private Node _rootNode;

        public void Append(T value)
        {
            if (_rootNode == null)
            {
                _rootNode = new Node(value);
                return;
            }

            Node current = _rootNode;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = new Node(value);
        }

        public void Prepend(T value)
        {
            Node newRoot = new Node(value);
            newRoot.next = _rootNode;
            _rootNode = newRoot;
        }

        public bool Find(T value)
        {
            if (_rootNode == null)
            { 
                return false;
            }
            if (_rootNode.data.Equals(value))
            {
                return true;
            }

            Node current = _rootNode;
            while (current.next != null)
            {
                if (current.data.Equals(value))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public void DeleteFirst(T value)
        {
            if (_rootNode == null)
            {
                return;
            }
            if (_rootNode.data.Equals(value))
            {
                _rootNode = _rootNode.next;
                return;
            }

            Node current = _rootNode;
            while (current.next != null)
            {
                if (current.next.data.Equals(value))
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
        }

        public void Print()
        {
            if (_rootNode == null)
            {
                return;
            }

            var current = _rootNode;
            while (current != null)
            {
                if (current.next == null)
                {
                    Console.Write($"{current.data}");
                    return;
                }
                Console.Write($"{current.data}, ");
                current = current.next;
            }
        }

        public class Node
        {
            public T data;
            public Node next;

            public Node(T value)
            {
                data = value;
            }
        }
    }
}
