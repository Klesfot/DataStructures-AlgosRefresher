namespace DataStructuresAlgosRefresher.DataStructures
{
    internal class Stack<T>
    {
        private Node<T>? _top;
        
        public bool IsEmpty()
        {
            return _top == null;
        }

        public T Peek()
        {
            if (_top == null)
            {
                throw new InvalidOperationException("Stack was empty");
            }

            return _top.data;
        }

        public void Push(T data)
        {
            if (_top == null)
            {
                _top = new Node<T>(data);
                return;
            }

            var node = new Node<T>(data);
            node.next = _top;
            _top = node;
        }

        public T Pop()
        {
            if (_top == null)
            {
                throw new InvalidOperationException("Stack was empty");
            }

            var data = _top.data;
            _top = _top.next;
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
