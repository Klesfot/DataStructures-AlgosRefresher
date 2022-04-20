using DataStructuresAlgosRefresher.DataStructures;

namespace DataStructuresAlgosRefresher
{
    public class DataStructuresAlgorithms
    {
        public static void Main(string[] args)
        {
            BinarySearchInArrayList();
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
    }
}