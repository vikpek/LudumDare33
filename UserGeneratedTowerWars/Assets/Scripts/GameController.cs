using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{


    [SerializeField]
    int cash = 750;
    int points = 0;

    [SerializeField]
    int lifes = 10;

    Button tower1;
    Button tower2;
    Button tower3;

    [SerializeField]
    int costTower1 = 250;

    [SerializeField]
    int costTower2 = 500;

    [SerializeField]
    int costTower3 = 125;
    
    GameObject endScene;
    GameObject actualScene;
    
    int phaseCounter = 1;




    void Start()
    {

        actualScene = GameObject.FindGameObjectWithTag("ActualScene");        
        actualScene.SetActive(true);
        endScene = GameObject.FindGameObjectWithTag("EndScene");
        endScene.SetActive(false);
        
        tower1 = GameObject.FindGameObjectWithTag(Tags.TOWER1_BUTTON).GetComponent<Button>();
        tower2 = GameObject.FindGameObjectWithTag(Tags.TOWER2_BUTTON).GetComponent<Button>();
        tower3 = GameObject.FindGameObjectWithTag(Tags.TOWER3_BUTTON).GetComponent<Button>();
        UpdateCashUI();
        UpdateLifeUI();
        UpdatePhaseUI();
        InvokeRepeating("NewWave", 20, 25);

    }


    void NewWave() {
        phaseCounter ++;
        UpdatePhaseUI();
    }
    void Example() {
        
    }
    public int GetPhaseCount()
    {
        return phaseCounter;
    }

    void UpdatePhaseUI(){
        
        GameObject.FindGameObjectWithTag("WaveText").GetComponent<Text>().text = phaseCounter + "";
    }

    public void IncreasePoints(int value)
    {
        points += value;
        UpdatePointsUI();
    }

    void UpdatePointsUI()
    {
        GameObject.FindGameObjectWithTag(Tags.POINTS_TEXT).GetComponent<Text>().text = points + "";
    }

    public void IncreaseCash(int value)
    {
        cash += value;
        UpdateCashUI();
    }

    public void DecreaseCash(int value)
    {
        
        int dec = 0;
		switch (value)
		{
			case 1 : 
				dec = costTower1;
				break;
			case 2 : 
				dec = costTower2;
				break;
			case 3 : 
				dec = costTower3;
				break;
		}
        
        print("lost " + dec + " of " + cash);
        cash -= dec;
        
        UpdateCashUI();
    }

    void UpdateCashUI()
    {
        GameObject.FindGameObjectWithTag(Tags.CASH_TEXT).GetComponent<Text>().text = cash + "";

        if (cash >= costTower1)
        {
            tower1.interactable = true;
        }
        else
        {
            tower1.interactable = false;
        }

        if (cash >= costTower2)
        {
            tower2.interactable = true;
        }
        else
        {
            tower2.interactable = false;
        }

        if (cash >= costTower3)
        {
            tower3.interactable = true;
        }
        else
        {
            tower3.interactable = false;
        }
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
        actualScene.SetActive(false);
        endScene.SetActive(true);
        UpdatePointsUI();
    }

    void UpdateLifeUI()
    {
        GameObject.FindGameObjectWithTag(Tags.LIFES_TEXT).GetComponent<Text>().text = lifes + "";
    }

    public void SwitchSceneLevel1()
    {
        Application.LoadLevel("Level01");
    }
    
    public void RestartScene(){
        //  actualScene.SetActive(true);
        //  endScene.SetActive(false);
        SwitchSceneLevel1();
    }


    public void SwitchSceneMenu()
    {
        Application.LoadLevel("Menu");
    }
}
