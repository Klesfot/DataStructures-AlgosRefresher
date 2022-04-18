namespace DataStructuresAlgosRefresher
{
    public class DataStructuresAlgorithms
    {
        public static void Main(string[] args)
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
    }
}