using UnityEngine;

public class CheckWinner : MonoBehaviour
{
    private static void CheckHorizontal()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                int k = j;
                int currX = 0, currO = 0;

                while (k < 5 && Setup.Field[i, k] == 1)
                {
                    currX++;
                    k++;
                }

                k = j;

                while (k < 5 && Setup.Field[i, k] == 2)
                {
                    currO++;
                    k++;
                }

                if (Setup.maxLengthCircle < currO) Setup.maxLengthCircle = currO;
                if (Setup.maxLengthCross < currX) Setup.maxLengthCross = currX;

                j = k;
            }
        }
    }

    private static void CheckVertical()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                int k = j;
                int currX = 0, currO = 0;

                while (k < 5 &&  Setup.Field[k, i] == 1)
                {
                    currX++;
                    k++;
                }

                k = j;

                while (k < 5 &&  Setup.Field[k, i] == 2)
                {
                    currO++;
                    k++;
                }

                if (Setup.maxLengthCircle < currO) Setup.maxLengthCircle = currO;
                if (Setup.maxLengthCross < currX) Setup.maxLengthCross = currX;

                j = k;
            }
        }
    }

    private static void CheckLeftDiagonal()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                int k = j, l = i;
                int currX = 0, currO = 0;
                while (k < 5 && l < 5 && Setup.Field[l, k] == 1)
                {
                    currX++;
                    k++;
                    l++;
                }

                k = j;
                l = i;

                while (k < 5 && l < 5 && Setup.Field[l, k] == 2)
                {
                    currO++;
                    k++;
                    l++;
                }

                if (Setup.maxLengthCircle < currO) Setup.maxLengthCircle = currO;
                if (Setup.maxLengthCross < currX) Setup.maxLengthCross = currX;

                j = k;
                i = l;
            }
        }

        for (int m = 1; m < 4; m++)
        {
            for (int i = 0; i < 5-m; i++)
            {
                for (int j = i+m; j < 5; j++)
                {
                    int k = j, l = i;
                    int currX = 0;
                    int currO = 0;

                    while (k < 5 && l < 5 && Setup.Field[l, k] == 1)
                    {
                        currX++;
                        k++;
                        l++;
                    }

                    k = j;
                    l = i;

                    while (k < 5 && l < 5 && Setup.Field[l, k] == 2)
                    {
                        currO++;
                        k++;
                        l++;
                    }

                    if (Setup.maxLengthCircle < currO) Setup.maxLengthCircle = currO;
                    if (Setup.maxLengthCross < currX) Setup.maxLengthCross = currX;

                    j = k;
                    i = l;
                }
            }
        }

        for (int m = 1; m < 4; m++)
        {
            for (int i = m; i < 5; i++)
            {
                for (int j = 0; j < 5-m; j++)
                {
                    int k = j, l = i;
                    int currX = 0;
                    int currO = 0;

                    while (k < 5 && l < 5 && Setup.Field[l, k] == 1)
                    {
                        currX++;
                        k++;
                        l++;
                    }

                    k = j;
                    l = i;

                    while (k < 5 && l < 5 && Setup.Field[l, k] == 2)
                    {
                        currO++;
                        k++;
                        l++;
                    }

                    if (Setup.maxLengthCircle < currO) Setup.maxLengthCircle = currO;
                    if (Setup.maxLengthCross < currX) Setup.maxLengthCross = currX;

                    j = k;
                    i = l;
                }
            }
        }
    }

    private static void CheckRightDiagonal()
    {
        for (int i = 0, j = 4; i < 5; i++, j--)
        {
            int k = j, l = i;
            int currX = 0;
            int currO = 0;

            while (l < 5 && k > -1 && Setup.Field[l, k] == 1)
            {
                currX++;
                k--;
                l++;
            }

            k = j;
            l = i;

            while (l < 5 && k > -1 && Setup.Field[l, k] == 2)
            {
                currO++;
                k--;
                l++;
                if (k == -1 && l == 5) break;
            }

            j = k;
            i = l;

            if (Setup.maxLengthCircle < currO) Setup.maxLengthCircle = currO;
            if (Setup.maxLengthCross < currX) Setup.maxLengthCross = currX;

            if (j < 0) break;
        }

        for (int i = 3; i > -1; i--)
        {
            for (int m = 0, n = i; m < 5; m++, n--)
            {
                int k = n, l = m;
                int currX = 0;
                int currO = 0;

                while (l < 5 && k > -1 && Setup.Field[l, k] == 1)
                {
                    currX++;
                    k--;
                    l++;

                    if (k == -1 && l == 5) break;
                }

                k = n;
                l = m;

                while (l < 5 && k > -1 && Setup.Field[l, k] == 2)
                {
                    currO++;
                    k--;
                    l++;

                    if (k == -1 && l == 5) break;
                }

                n = k;
                m = l;

                if (Setup.maxLengthCircle < currO) Setup.maxLengthCircle = currO;
                if (Setup.maxLengthCross < currX) Setup.maxLengthCross = currX;

                if (n < 0) break;
            }
        }

        for (int i = 1; i < 5; i++)
        {
            for (int m = i, n = 4; m < 5; m++, n--)
            {
                int k = n, l = m;
                int currX = 0;
                int currO = 0;

                while (l < 5 && k > -1 && Setup.Field[l, k] == 1)
                {
                    currX++;
                    k--;
                    l++;

                    if (k == -1 && l == 5) break;
                }

                k = n;
                l = m;

                while (l < 5 && k > -1 && Setup.Field[l, k] == 2)
                {
                    currO++;
                    k--;
                    l++;

                    if (k == -1 && l == 5) break;
                }

                n = k;
                m = l;

                if (Setup.maxLengthCircle < currO) Setup.maxLengthCircle = currO;
                if (Setup.maxLengthCross < currX) Setup.maxLengthCross = currX;

                if (n < 0) break;
            }
        }
    }

    public static void StartCheck()
    {
        CheckHorizontal();
        CheckVertical();
        CheckLeftDiagonal();
        CheckRightDiagonal();

        Debug.Log("OK");
        Debug.LogFormat("Cross = {0}, Circle = {1}", Setup.maxLengthCross, Setup.maxLengthCircle);
    }
}
