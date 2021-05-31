using UnityEngine;

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

    public static Vector2 RotateVector(Vector2 v, float angle)
    {
        angle *= Mathf.Deg2Rad;
        var x = v.x * Mathf.Cos(angle) - v.y * Mathf.Sin(angle);
        var y = v.x * Mathf.Sin(angle) + v.y * Mathf.Cos(angle);
        return new Vector2(x, y);
    }
}