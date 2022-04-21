namespace DataStructuresAlgosRefresher.DataStructures
{
    internal class Stack
    {
        private Node? _top;
        
        public bool IsEmpty()
        {
            return _top == null;
        }

        public int Peek()
        {
            if (_top == null)
            {
                throw new InvalidOperationException("Stack was empty");
            }

            return _top.data;
        }

        public void Push(int data)
        {
            if (_top == null)
            {
                _top = new Node(data);
                return;
            }

            var node = new Node(data);
            node.next = _top;
            _top = node;
        }

        public int Pop()
        {
            if (_top == null)
            {
                throw new InvalidOperationException("Stack was empty");
            }

            var data = _top.data;
            _top = _top.next;
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
