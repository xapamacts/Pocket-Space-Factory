using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Text scoreText;

    [Header("UI Boxes")]
    public GameObject boxLevelFail;
    public GameObject boxLevelSuccess;
    public GameObject boxGameEnd;

    [Header("State")]
    public bool isPlaying;           //Determina si estamos jugando o no. Hace referencia a cuando ponemos pause.
    public int actualLevel;          //Nivel actual.
   
    [Header("Machines")]
    public int totalBoxes;
    public int actualBox;
    public int actualBoxType;

    private SFXManager sfxManager;
    private Machine2 machine2;
    private Machine1 machine1;
    private Machine3 machine3;

    private void Awake() 
    {
        machine2 = GetComponent<Machine2>();
        machine3 = GetComponent<Machine3>();
        machine1 = GetComponent<Machine1>();
        sfxManager = GameObject.Find("FXManager").GetComponent<SFXManager>();
        isPlaying = false;
    }

    private void Start() 
    {
        Global.score = 0;
        Global.maxTime = 0;
        boxGameEnd.SetActive(false);
        LoadLevel(Global.level);

        //Provisional
        ShowScoreInfo();
        StrtGame();
    }

   public void LoadLevel(int num)
   {
       // 1 - red box
       // 2 - Yellow box
       // 3 - blue box

       Global.requestBox.Clear();
       if (num == 1) 
       {
            Global.requestBox.Add(2);
            Global.requestBox.Add(2);
            Global.requestBox.Add(2);

            Global.machine1BoxTime = 25;
            Global.machine2BoxTime = 10;
            Global.machine3BoxTime = 15;
            Global.machine1accumulatedBoxesLimit = 3;
            Global.machine2accumulatedBoxesLimit = 3;
            Global.machine3accumulatedBoxesLimit = 3;
            Global.machine1BoxFirstTime = 6;
            Global.machine1Score = 10000;
            Global.machine2Score = 15000;
            Global.machine3Score = 20000;
        }
        if (num == 2)
        {
            //TO DO
        }
       actualBox = 0;
       totalBoxes = Global.requestBox.Count;
       actualBoxType = Global.requestBox[actualBox];
       actualLevel = num;
   } 

   private void StrtGame()
   {
       machine1.StartMachine1();
       machine2.StartMachine2();
       machine3.StartMachine3();
       isPlaying = true; 
   }

    public void PauseGame()
    {
        machine2.PauseMachine2();
        machine1.PauseMachine1();
        machine3.PauseMachine3();
        isPlaying = false;
    }

    private void unPauseGame()
    {
        machine2.PlayMachine2();
        machine1.PlayMachine1();
        machine3.PlayMachine3();
        isPlaying = true;
    }

    public void UpdateBox()
    {
        actualBox++;
        if(actualBox < totalBoxes)
        {
            actualBoxType = Global.requestBox[actualBox];
            Global.score+=1;
        }else
        {
            Debug.Log("victory");
        }
    }

    public void ShowScoreInfo()
    {
        scoreText.text = Global.score.ToString();
    }

    public void ShowGameOver()
    {
        boxLevelFail.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void ShowLevelCompleted()
    {
        boxLevelSuccess.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    public void ShowGameCompleted()
    {
        boxGameEnd.GetComponent<Animator>().SetInteger("StateBox", 1);
    }

    //BUTTONS
    public void GoToMainMenu()
    {
        sfxManager.PlayStandardClick();
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGameButton()
    {
        sfxManager.PlayStandardClick();
        if (isPlaying == true)
        {
            PauseGame();
        } else
        {
            unPauseGame();
        }
    }
}
