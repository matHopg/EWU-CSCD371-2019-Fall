using System;

namespace Sorter
{
    public delegate bool Comparison(int first, int second);

    public class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public void InsertionSort(int[] array, Comparison comparison)
        {
            if (array is null) throw new ArgumentNullException($"{nameof(array)} cannot be null");
            if (comparison is null) throw new ArgumentNullException($"{nameof(comparison)} cannot be null");
            for(var i =1; i<array.Length; i++)
            {
                var currentValue = array[i];
                var tempValue = 0;
                for(var x = i-1; x>= 0 && tempValue != 1;)
                {
                    if(comparison(currentValue, array[x]))
                    {
                        array[x + 1] = array[x];
                        x--;
                        array[x + 1] = currentValue;
                    }
                    else
                    {
                        tempValue = 1;
                    }
                }

            }
        }
    }
}
