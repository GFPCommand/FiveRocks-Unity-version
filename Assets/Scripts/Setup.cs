using UnityEngine;
using UnityEngine.UI;

public class Setup : MonoBehaviour
{
    public static int[,] Field = new int[5, 5];
    public static readonly int countOfFreeFields = 25;
    public static int maxLengthCross, maxLengthCircle;
    public static bool turnCross, turnCircle, isGameEnd;

    public GameObject Restart;

    public GameObject[] images = new GameObject[25];

    public Text turn, win;
    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Field[i, j] = 0;
            }
        }

        for (int i = 0; i < 25; i++)
        {
            images[i].SetActive(false);
        }

        maxLengthCross = 0;
        maxLengthCircle = 0;

        turnCross = true;
        turnCircle = false;
        isGameEnd = false;

        Restart.SetActive(false);

        win.text = "";
        turn.text = "Turn: X";
    }
}
