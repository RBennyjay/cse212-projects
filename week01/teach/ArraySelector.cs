using System;
using System.Collections.Generic;

public static class ArraySelector
{
    public static void Run()
    {
        // Integer test
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select1 = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };

        var intResult = ListSelector(l1, l2, select1);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}");
        // Expected: <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}

        // Character test
        var l3 = new[] { 'A', 'A', 'A', 'A', 'A' };
        var l4 = new[] { 'B', 'B', 'B', 'B', 'B' };
        var select2 = new[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };

        var charResult = ListSelector(l3, l4, select2);
        Console.WriteLine("<char[]>{" + string.Join(", ", charResult) + "}");
        // Expected: <char[]>{A, B, A, B, A, B, A, B, A, B}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        List<int> results = new List<int>();
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1 && index1 < list1.Length)
            {
                results.Add(list1[index1]);
                index1++;
            }
            else if (select[i] == 2 && index2 < list2.Length)
            {
                results.Add(list2[index2]);
                index2++;
            }
        }

        return results.ToArray();
    }

    private static char[] ListSelector(char[] list1, char[] list2, int[] select)
    {
        List<char> results = new List<char>();
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1 && index1 < list1.Length)
            {
                results.Add(list1[index1]);
                index1++;
            }
            else if (select[i] == 2 && index2 < list2.Length)
            {
                results.Add(list2[index2]);
                index2++;
            }
        }

        return results.ToArray();
    }
}
