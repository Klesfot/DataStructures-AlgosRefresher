namespace DataStructuresAlgosRefresher.DataStructures
{
    internal class PrefixTree
    {
        private Node _rootNode;

        public PrefixTree()
        {
            _rootNode = new Node('\0');
        }

        public void Insert(string word)
        {
            var curr = _rootNode;
            for (int i = 0; i < word.Length; i++)
            {
                var ch = word[i];
                if (curr.children[ch - 'a'] == null) // substract character's index by index of a to get ch's index in our array
                {
                    curr.children[ch - 'a'] = new Node(ch);
                }    
                curr = curr.children[ch - 'a'];
            }    
            curr.isWord = true;
        }

        public bool Search(string word)
        {
            var node = GetNode(word);
            return node != null && node.isWord;
        }

        public bool StartsWith(string prefix)
        {
            return GetNode(prefix) != null;
        }

        private Node GetNode(string word)
        {
            Node curr = _rootNode;
            for (int i = 0; i < word.Length; i++)
            {
                var ch = word[i];
                if (curr.children[ch - 'a'] == null)
                {
                    return null;
                }
                curr = curr.children[ch - 'a'];
            }
            return curr;
        }

        class Node
        {
            public char data;
            public bool isWord;
            public Node[] children;

            public Node(char value)
            {
                data = value;
                isWord = false;
                children = new Node[26]; // each child can have up to 26 children (26 letters in English alphabet)
            }
        }
    }
}
