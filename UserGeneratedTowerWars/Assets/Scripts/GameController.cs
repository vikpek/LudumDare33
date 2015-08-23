using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    int cash = 100;
    int points = 0;

    int lifes = 10;

    Button tower1;
    Button tower2;
    Button tower3;

    void Start()
    {
        UpdateLifeUI();
        tower1 = GameObject.FindGameObjectWithTag(Tags.TOWER1_BUTTON).GetComponent<Button>();
        tower2 = GameObject.FindGameObjectWithTag(Tags.TOWER2_BUTTON).GetComponent<Button>();
        tower3 = GameObject.FindGameObjectWithTag(Tags.TOWER3_BUTTON).GetComponent<Button>();

    }

    public void IncreasePoints(int value)
    {
        points += value;
        GameObject.FindGameObjectWithTag(Tags.POINTS_TEXT).GetComponent<Text>().text = points + "";
    }

    public void IncreaseCash(int value)
    {
        cash += value;
        GameObject.FindGameObjectWithTag(Tags.CASH_TEXT).GetComponent<Text>().text = cash + "";
    }

    public void DecreaseLife()
    {
        lifes--;
        if (lifes < 1)
        {
            EndGame();
        }
		UpdateLifeUI();
    }

    void EndGame()
    {
        print("Game Over");
    }

    void UpdateLifeUI()
    {
        GameObject.FindGameObjectWithTag(Tags.LIFES_TEXT).GetComponent<Text>().text = lifes + "";
    }
}
