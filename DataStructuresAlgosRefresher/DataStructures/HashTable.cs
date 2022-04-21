namespace DataStructuresAlgosRefresher.DataStructures
{
    internal class HashTable
    {
        private const int _initialCapacity = 50;

        private readonly int capacity;
        private readonly HTNode[] buckets;

        public int Size { get; private set; }

        public HashTable()
        {
            capacity = _initialCapacity;
            Size = 0;
            buckets = new HTNode[capacity];
        }

        public void Add(string key, int value)
        {
            Size++;
            var index = Hash(key);
            var node = buckets[index];

            if (node == null)
            {
                buckets[index] = new HTNode(key, value);
                return;
            }

            // Collision
            var prev = node;
            while (node != null)
            {
                prev = node;
                node = node.next;
            }
            prev.next = new HTNode(key, value);

            return;
        }

        public int Remove(string key)
        {
            var index = Hash(key);
            var node = this.buckets[index];
            int result;

            var prev = new HTNode();

            while (node != null && node.key != key)
            {
                prev = node;
                node = node.next;
            }

            if (node == null)
            {
                return -1;
            }
            else
            {
                Size--;
                result = node.value;

                if (prev == null)
                {
                    node = null;
                }
                else
                {
                    prev.next = null;
                }
                return result;
            }
        }

        public int Find(string key)
        {
            var index = Hash(key);
            var node = this.buckets[index];

            while (node != null && node.key != key)
            {
                node = node.next;
            }
            if (node == null)
            {
                return -1;
            }
            else
            {
                return node.value;
            }
        }

        private int Hash(string key)
        {
            var hashSum = 0;
            for (var i = 0; i < key.Length; i++)
            {
                hashSum += (int)Math.Pow(i + key.Length, (int)key[i]);
                hashSum %= capacity;
            }

            return hashSum;
        }
    }

    public class HTNode
    {
        public string key;
        public int value;
        public HTNode? next;

        public HTNode(string key = "", int value = 0)
        {
            this.key = key;
            this.value = value;
            this.next = null;
        }
    }
}
