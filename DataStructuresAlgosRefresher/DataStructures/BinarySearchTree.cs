namespace DataStructuresAlgosRefresher.DataStructures
{
    enum PrintType
    {
        InOrder,
        PreOrder,
        PostOrder
    }

    internal class BinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node _rootNode;

        public BinarySearchTree(T value)
        {
            _rootNode = new Node(value);
        }

        public void Insert(T value)
        {
            _rootNode.Insert(value);
        }

        public bool Lookup(T value)
        {
            return _rootNode.Lookup(value);
        }

        public void Print(PrintType type = PrintType.InOrder)
        {
            _rootNode.Print(type);
        }

        class Node
        {
            Node left, right;
            T data;

            public Node(T value)
            {
                data = value;
            }

            public void Insert(T value)
            {
                if (value.CompareTo(data) <= 0)
                {
                    if (left == null)
                    {
                        left = new Node(value);
                    }
                    else
                    {
                        left.Insert(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        right = new Node(value);
                    }
                    else
                    {
                        right.Insert(value);
                    }    
                }
            }

            public bool Lookup(T value)
            {
                if (value.Equals(data))
                {
                    return true;
                }
                else if (value.CompareTo(data) < 0)
                {
                    if (left == null)
                    {
                        return false;
                    }
                    else
                    {
                        return left.Lookup(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        return false;
                    }
                    else
                    {
                        return right.Lookup(value);
                    }
                }
            }

            public void Print(PrintType printType = PrintType.InOrder)
            {
                if (printType == PrintType.InOrder)
                {
                    PrintInOrder();
                }
                else if (printType == PrintType.PreOrder)
                {
                    PrintPreOrder();
                }
                else if (printType == PrintType.PostOrder)
                {
                    PrintPostOrder();
                }

                Console.WriteLine();
            }

            private void PrintInOrder()
            {
                if (left != null)
                {
                    left.PrintInOrder();
                }
                Console.WriteLine($"{data}");
                if (right != null)
                {
                    right.PrintInOrder();
                }    
            }

            private void PrintPreOrder()
            {
                Console.WriteLine($"{data}");
                if (left != null)
                {
                    left.PrintInOrder();
                }
                if (right != null)
                {
                    right.PrintInOrder();
                }
            }

            private void PrintPostOrder()
            {
                if (left != null)
                {
                    left.PrintInOrder();
                }
                if (right != null)
                {
                    right.PrintInOrder();
                }
                Console.WriteLine($"{data}");
            }
        }

    }
}
