using System;

public static class MergeMinusSort
{
static int numbersCount;
public static int[] tempArray;

    public static void Merge(int[] numbers, int left, int mid, int right)
    {
	    int i;
	    int leftEnd;
	    int numElements;
	    int tempPosition;

	    leftEnd = (mid - 1);
	    tempPosition = left;
	    numElements = (right - left + 1);

	    while ((left <= leftEnd) && (mid <= right))
	    {
	    if (numbers[left] <= numbers[mid])
	    {
            tempArray[tempPosition] = numbers[left];
		    tempPosition += 1;
		    left += 1;
	    }
	    else
	    {
            tempArray[tempPosition] = numbers[mid];
		    tempPosition += 1;
		    mid += 1;
	    }
	    }

	    while (left <= leftEnd)
	    {
            tempArray[tempPosition] = numbers[left];
	    left += 1;
	    tempPosition += 1;
	    }
	    while (mid <= right)
	    {
            tempArray[tempPosition] = numbers[mid];
	    mid += 1;
	    tempPosition += 1;
	    }

	    for (i = 0; i < numElements; i++)
	    {
            numbers[right] = tempArray[right];
	    right -= 1;
	    }
    }

    public static void M_sort(int[] numbers, int left, int right)
    {
	    if (right > left)
	    {
		    int mid = (right + left) / 2;
		    M_sort(numbers, left, mid);
		    M_sort(numbers, (mid + 1), right);
		    Merge(numbers, left, (mid + 1), right);
	    }
    }

    public static void MergeSort(int[] numbers, int arraySize)
    {
	    M_sort(numbers, 0, arraySize - 1);
    }

    static void Main()
    {
	    int[] arrayOne = {1, 3, 5, 2, 4, 8, 10, 6, 16, 14, 12 , -1, 0};
            numbersCount = arrayOne.Length;
            tempArray = new int[numbersCount];

	    MergeSort(arrayOne, numbersCount);

	    for (int i = 0; i < numbersCount; i++)
	    {
			    Console.Write(arrayOne[i]);
			    Console.Write(" ");
	    }
    }
}
