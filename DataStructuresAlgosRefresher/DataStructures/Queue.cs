namespace DataStructuresAlgosRefresher.DataStructures
{
    internal class Queue<T>
    {
        private Node<T>? _tail;
        private Node<T>? _head;

        public bool IsEmpty()
        {
            return _head == null;
        }

        public T Peek()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue was empty");
            }

            return _head.data;
        }

        public void Add(T value)
        {
            var node = new Node<T>(value);
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

        public T Remove()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue was empty");
            }

            T data = _head.data;
            _head = _head.next;

            if (_head == null)
            {
                _tail = null;
            }

            return data;
        }

        public class Node<T>
        {
            public T data;
            public Node<T>? next;
            
            public Node(T data)
            {
                this.data = data;
                next = null;
            }
        }
    }
}
