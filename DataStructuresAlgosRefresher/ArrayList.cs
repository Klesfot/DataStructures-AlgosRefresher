using System.Collections;

namespace DataStructuresAlgosRefresher
{
    enum SortType
    {
        Merge,
        Quick
    }

    internal class ArrayList<T>: IEnumerable<T>
        where T : IComparable<T>
    {
        private T[] _array;

        public ArrayList()
        {
            Clear();
        }

        public ArrayList<T> Add(T value)
        {
            T[] temp = new T[_array.Length + 1];
            for (int i = 0; i < _array.Length; i++)
            {
                temp[i] = _array[i];
            }
            
            temp[_array.Length - 1] = value;
            _array = temp;
            return this;
        }

        public void Clear()
        {
            _array = new T[1];
        }

        public int Find(T element)
        {
            return RecursiveBinarySearch(element, _array, 0, _array.Length - 1);
        }

        public void Sort(SortType type = SortType.Quick)
        {
            if (type == SortType.Merge)
            {
                _array = MergeSort(_array);
            }
            if (type == SortType.Quick)
            {
                _array = QuickSort(_array);
            }

            Print();
        }

        public void Print()
        {
            Console.WriteLine();
            foreach (T item in _array)
                Console.WriteLine(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _array)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int RecursiveBinarySearch(T element, T[] arr, int beginIndex, int endIndex)
        {
            var mid = (beginIndex + endIndex) / 2;
            if (EqualityComparer<T>.Default.Equals(arr[mid], element))
            {
                return mid;
            }
            else if (beginIndex >= endIndex) // base case
            {
                return -1;
            }
            else if (arr[mid].CompareTo(element) < 0)
            {
                beginIndex = mid + 1;
                return RecursiveBinarySearch(element, arr, beginIndex, endIndex);
            }
            else if (arr[mid].CompareTo(element) > 0)
            {
                endIndex = mid - 1;
                return RecursiveBinarySearch(element, arr, beginIndex, endIndex);
            }

            return -1;
        }

        private T[] MergeSort(T[] arr)
        {
            T[] left;
            T[] right;
            var result = new T[arr.Length];
            if (arr.Length <= 1) // base case
            {
                return arr;
            }

            int mid = arr.Length / 2;
            left = new T[mid];

            if (arr.Length % 2 == 0)
            {
                right = new T[mid];
            }
            else
            {
                right = new T[mid + 1];
            }

            for (int i = 0; i < mid; i++)
            {
                left[i] = arr[i];
            }

            int rIndex = 0;
            for (int i = mid; i < arr.Length; i++)
            {
                right[rIndex] = arr[i];
                rIndex++;
            }

            left = MergeSort(left);
            right = MergeSort(right);
            result = Merge(left, right);

            return result;
        }

        private T[] Merge(T[] left, T[] right)
        {
            int resultLen = left.Length + right.Length;
            T[] result = new T[resultLen];

            int indexL = 0;
            int indexR = 0;
            int indexResult = 0;

            while (indexL < left.Length || indexR < right.Length)
            {
                if (indexL < left.Length && indexR < right.Length)
                {
                    if (left[indexL].CompareTo(right[indexR]) < 0)
                    {
                        result[indexResult] = left[indexL];
                        indexL++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexR];
                        indexR++;
                        indexResult++;
                    }
                }
                else if (indexL < left.Length)
                {
                    result[indexResult] = left[indexL];
                    indexL++;
                    indexResult++;
                }
                else if (indexR < right.Length)
                {
                    result[indexResult] = right[indexR];
                    indexR++;
                    indexResult++;
                }
            }

            return result;
        }

        private T[] QuickSort(T[] arr)
        {
            throw new NotImplementedException();
        }
    }
}
