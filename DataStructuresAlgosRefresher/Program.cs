using DataStructuresAlgosRefresher.DataStructures;

namespace DataStructuresAlgosRefresher
{
    public class DataStructuresAlgorithms
    {
        public static void Main(string[] args)
        {
            HeapTest();
        }

        private void FindArr1ElemsInArr2()
        {
            // Testing the HashTable using a common problem of finding elements
            // of one array in another
            int[] arr1 = new int[] { 56, 7, 14, 12, 2, 9, 8 };
            int[] arr2 = new int[] { 7, 6, 11, 8, 12, 3, 56, 7, 14, 12, 2, 9 };

            var ht = new HashTable();

            for (int i = 0; i < arr2.Length; i++)
            {
                ht.Add(Convert.ToString(arr2[i]), arr2[i]);
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(ht.Find(Convert.ToString(arr1[i])));
            }

            ht.Remove("56");
            ht.Remove("7");

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(ht.Find(Convert.ToString(arr1[i])));
            }
        }

        private static void BinarySearchInArrayList()
        {
            var al = new ArrayList();
            al.Add(9).Add(14).Add(2).Add(5).Add(12).Add(3).Add(7);
            al.Sort(SortType.Quick); // 0, 2, 3, 5, 7, 9, 12, 14
            Console.WriteLine();
            Console.WriteLine(al.Find(2)); // exists, 1
            Console.WriteLine(al.Find(12)); // exists, 6
            Console.WriteLine(al.Find(6)); // does not exist, -1
        }
        
        private static void BinarySearchTreeTest()
        {
            var bst = new BinarySearchTree<int>(15);
            bst.Insert(10);
            bst.Insert(20);
            bst.Insert(12);
            bst.Insert(5);
            bst.Insert(8);
            bst.Print(PrintType.InOrder); //  5, 8, 10, 12, 15, 20
            bst.Print(PrintType.PreOrder); // 15, 5, 8, 10, 12, 20
            bst.Print(PrintType.PostOrder); // 5, 8, 10, 12, 20, 15
            Console.WriteLine($"{bst.Lookup(8)}"); // true
            Console.WriteLine($"{bst.Lookup(2)}"); // false
        }

        private static void PrefixTreeTest()
        {
            var pt = new PrefixTree();
            pt.Insert("cats");
            pt.Insert("cast");
            Console.WriteLine(pt.Search("cats")); // true
            Console.WriteLine(pt.Search("cass")); // false
            Console.WriteLine(pt.StartsWith("ca")); // true
            Console.WriteLine(pt.StartsWith("cl")); //false
        }

        private static void LinkedListTest()
        {
            var ll = new DataStructures.LinkedList<int>();
            ll.Append(1);
            ll.Append(2);
            ll.Append(3);
            ll.Append(4);
            ll.Append(5);
            ll.Prepend(0);
            ll.Find(4); // true
            ll.Find(9); // false
            ll.DeleteFirst(3);
            ll.Find(3); // false
            ll.Print(); // 0, 1, 2, 4, 5
        }

        private static void QueueStackTest()
        {
            var s = new DataStructures.Stack<int>();
            s.Push(1);
            s.Push(6);
            s.Push(12);
            Console.WriteLine($"I spy {s.Peek()}"); // I spy 12
            Console.WriteLine($"Popped {s.Pop()}");
            Console.WriteLine($"I spy {s.Peek()}"); // I spy 6
            Console.WriteLine($"Popped {s.Pop()}");
            Console.WriteLine($"Popped {s.Pop()}");
            try
            {
                _ = s.Pop(); // same if Peek'd
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Stack was empty
            }

            Console.WriteLine();

            var ss = new DataStructures.Stack<string>();
            ss.Push("a");
            ss.Push("s");
            ss.Push("q");
            Console.WriteLine($"I spy {ss.Peek()}"); // I spy q
            Console.WriteLine($"Popped {ss.Pop()}");
            Console.WriteLine($"I spy {ss.Peek()}"); // I spy s
            Console.WriteLine($"Popped {ss.Pop()}");
            Console.WriteLine($"Popped {ss.Pop()}");

            Console.WriteLine();
            Console.WriteLine();

            var q = new DataStructures.Queue<int>();
            q.Add(1);
            q.Add(6);
            q.Add(12);
            Console.WriteLine($"I spy {q.Peek()}"); // I spy 1
            Console.WriteLine($"Removed {q.Remove()}");
            Console.WriteLine($"Removed {q.Remove()}");
            Console.WriteLine($"I spy {q.Peek()}"); // I spy 12
            Console.WriteLine($"Removed {q.Remove()}");
            try
            {
                _ = q.Peek();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // Queue was empty
            }

            Console.WriteLine();

            var qs = new DataStructures.Queue<string>();
            qs.Add("a");
            qs.Add("s");
            qs.Add("q");
            Console.WriteLine($"I spy {qs.Peek()}"); // I spy a
            Console.WriteLine($"Removed {qs.Remove()}");
            Console.WriteLine($"Removed {qs.Remove()}");
            Console.WriteLine($"I spy {qs.Peek()}"); // I spy q
            Console.WriteLine($"Removed {qs.Remove()}");
        }

        private static void GraphTest()
        {
            var g = new Graph();
            g.AddNode(1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);
            g.AddEdge(1, 4);
            g.AddEdge(4, 12);
            g.AddEdge(2, 5);
            g.AddEdge(3, 6);
            g.AddEdge(2, 3);
            g.AddEdge(5, 7);
            g.AddEdge(7, 11);
            g.AddEdge(5, 9);
            g.AddEdge(5, 10);
            g.AddEdge(7, 9); // 
            g.AddEdge(9, 3); // ^ check for infinite
            Console.WriteLine($"Result {g.HasPath(SearchType.DepthFirstSearch, 1, 12)}");
            Console.WriteLine($"Result {g.HasPath(SearchType.BreadthFirstSearch, 1, 12)}");
            g.AddNode(77);
            Console.WriteLine($"Result {g.HasPath(SearchType.DepthFirstSearch, 1, 77)}");
            Console.WriteLine($"Result {g.HasPath(SearchType.BreadthFirstSearch, 1, 77)}");
        }

        private static void HeapTest()
        {
            var mh = new MinHeap();
            mh.Add(12);
            mh.Add(22);
            mh.Add(33);
            mh.Add(44);
            mh.Add(55);
            Console.WriteLine(mh.Poll()); // 12
            Console.WriteLine(mh.Peek()); // 22
            mh.Add(66);
            Console.WriteLine(mh.Peek()); // 22
        }
    }
}