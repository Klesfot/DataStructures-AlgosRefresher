namespace DataStructuresAlgosRefresher.DataStructures
{
    internal class Queue
    {
        private Node? _tail;
        private Node? _head;

        public bool IsEmpty()
        {
            return _head == null;
        }

        public int Peek()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue was empty");
            }

            return _head.data;
        }

        public void Add(int value)
        {
            var node = new Node(value);
            if (_tail != null)
            {
                _tail.next = node;
            }
            _tail = node;

            if (_head == null)
            {
                _head = node;
            }
        }

        public int Remove()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue was empty");
            }

            int data = _head.data;
            _head = _head.next;

            if (_head == null)
            {
                _tail = null;
            }

            return data;
        }

        public class Node
        {
            public int data;
            public Node? next;
            
            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }
    }
}
