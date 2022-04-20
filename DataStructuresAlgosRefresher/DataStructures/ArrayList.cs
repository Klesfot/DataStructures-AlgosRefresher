using System.Collections;

namespace DataStructuresAlgosRefresher.DataStructures
{
    enum SortType
    {
        Merge,
        Quick
    }

    internal class ArrayList
    {
        private int[] _array;

        public ArrayList()
        {
            _array = new int[1];
        }

        public ArrayList Add(int value)
        {
            int[] temp = new int[_array.Length + 1];
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
            _array = new int[1];
        }

        public int Find(int element)
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
            foreach (int item in _array)
            {
                Console.WriteLine(item);
            }
        }

        private int RecursiveBinarySearch(int element, int[] arr, int beginIndex, int endIndex)
        {
            var mid = (beginIndex + endIndex) / 2;
            if (EqualityComparer<int>.Default.Equals(arr[mid], element))
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

        private int[] MergeSort(int[] arr)
        {
            int[] left;
            int[] right;
            var result = new int[arr.Length];
            if (arr.Length <= 1) // base case
            {
                return arr;
            }

            int mid = arr.Length / 2;
            left = new int[mid];

            if (arr.Length % 2 == 0)
            {
                right = new int[mid];
            }
            else
            {
                right = new int[mid + 1];
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

        private int[] Merge(int[] left, int[] right)
        {
            int resultLen = left.Length + right.Length;
            int[] result = new int[resultLen];

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

        private int[] QuickSort(int[] arr)
        {
            return RecursiveQuickSort(arr, 0, arr.Length - 1);
        }

        private int[] RecursiveQuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return arr;
            }

            var pivot = arr[(left + right) / 2];
            var index = Partition(arr, left, right, pivot);
            RecursiveQuickSort(arr, left, index - 1);
            RecursiveQuickSort(arr, index, right);

            return arr;
        }

        private int Partition(int[] arr, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    arr = Swap(arr, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        private int[] Swap(int[] arr, int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            return arr;
        }
    }
}
