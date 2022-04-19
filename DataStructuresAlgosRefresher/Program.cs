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
            var al = new ArrayList<int>();
            al.Add(9).Add(14).Add(2).Add(5).Add(12).Add(3).Add(7);
            al.Sort(SortType.Merge); // 0, 2, 3, 5, 7, 9, 12, 14
            Console.WriteLine();
            Console.WriteLine(al.Find(2)); // exists, 1
            Console.WriteLine(al.Find(12)); // exists, 6
            Console.WriteLine(al.Find(6)); // does not exist, -1
        }
    }
}