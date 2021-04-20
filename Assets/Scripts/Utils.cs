public static class Utils
{
    public static int BinarySearch(int[] v, int k)
    {
        int esq = 0, dir = v.Length - 1, r = -1;
        while (esq <= dir)
        {
            var mid = (esq + dir) / 2;
            if (k <= v[mid])
            {
                r = mid;
                dir = mid - 1;
            }
            else esq = mid + 1;
        }
        return r;
    }
}