namespace DataStructuresAlgosRefresher.DataStructures
{
    internal class MinHeap
    {
        private int _capacity;
        private int _size;
        private int[] _items;

        public MinHeap()
        {
            _capacity = 10;
            _size = 0;
            _items = new int[_capacity];
        }

        public int Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Heap was empty");
            }
            return _items[0];
        }

        public int Poll()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Heap was empty");
            }
            int item = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();
            _items[_size] = item;
            _size++;
            HeapifyUp();
        }

        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (_items[index] < _items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }

                index = smallerChildIndex;
            }
        }

        private void HeapifyUp()
        {
            int index = _size - 1;
            while (HasParent(index) && GetParent(index) > _items[index])
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChild(int index)
        {
            return _items[GetLeftChildIndex(index)];
        }

        private int GetRightChild(int index)
        {
            return _items[GetRightChildIndex(index)];
        }

        private int GetParent(int index)
        {
            return _items[GetParentIndex(index)];
        }

        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < _size;
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < _size;
        }

        private bool HasParent(int index)
        {
            return GetParentIndex(index) >= 0;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

        private void EnsureExtraCapacity()
        {
            if (_size == _capacity)
            {
                var newArr = new int[_capacity * 2];
                _capacity *= 2;
                for (int i = 0; i < _items.Length; i++)
                {
                    newArr[i] = _items[i];
                }
                _items = newArr;
            }
        }
    }
}
