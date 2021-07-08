using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameProccess : MonoBehaviour
{
    private int coordX, coordY;
    private int count = Setup.countOfFreeFields;

    public GameObject Restart;

    public GameObject[] images = new GameObject[25];

    public Sprite cross, circle;

    public Text turn, win;

   public void MakeTurn(int field)
    {
        coordX = field % 10 - 1;
        coordY = field / 10 - 1;

        Debug.LogFormat("CoordX = {0}\nCoordY = {1}", coordX, coordY);

        if (Setup.Field[coordY, coordX] == 0 && Setup.turnCircle && !Setup.turnCross)
        {
            SetImage();
            Setup.Field[coordY, coordX] = 2;
            Setup.turnCircle = false;
            Setup.turnCross = true;
            count--;
            turn.text = "Turn: X";
            
        } else if (Setup.Field[coordY, coordX] == 0 && !Setup.turnCircle && Setup.turnCross)
        {
            SetImage();
            Setup.Field[coordY, coordX] = 1;
            Setup.turnCircle = true;
            Setup.turnCross = false;
            count--;
            turn.text = "Turn: O";
        }

        Debug.Log(Setup.isGameEnd);
        Debug.Log(count);

        if (count == 0) Setup.isGameEnd = true;
        if (Setup.isGameEnd)
        {
            CheckWinner.StartCheck();
            if (Setup.maxLengthCircle > Setup.maxLengthCross) win.text = "Win: O";
            else if (Setup.maxLengthCross > Setup.maxLengthCircle) win.text = "Win: X";
            else win.text = "Win: X and O";
            Restart.SetActive(true);
        }
    }

    private void SetImage()
    {
        if (Setup.turnCircle && !Setup.turnCross)
        {
            int tmp;
            tmp = coordX + 5 * coordY;
            images[tmp].SetActive(true);
            images[tmp].GetComponent<Image>().sprite = circle;
        } else if (!Setup.turnCircle && Setup.turnCross)
        {
            int tmp;
            tmp = coordX + 5 * coordY;
            images[tmp].SetActive(true);
            images[tmp].GetComponent<Image>().sprite = cross;
        }
    }

    public void RestartGame()
    {
        for (int i = 0; i < 25; i++)
        {
            images[i].SetActive(false);
        }

        SceneManager.LoadScene(0);
    }
}