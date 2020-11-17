public static class BinarySearch
{
    private static int SearchBinary(int value, int[] array, int low, int high)
    {
        if (low > high) return -1;
        int mid = low + (high - low) / 2;
        int midValue = array[mid];

        if (midValue == value)
            return mid;

        else if (midValue < value)
            return SearchBinary(value, array, mid + 1, high);
        else
            return SearchBinary(value, array, low, mid - 1);
    }

    public static int Find(int[] input, int value) => input.Length < 1 ? -1 : SearchBinary(value, input, 0, input.Length - 1);

}