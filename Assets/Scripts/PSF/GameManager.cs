using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
   [Header("State")]
   public bool isPlaying;           //Determina si estamos jugando o no. Hace referencia a cuando ponemos pause.
   public int actualLevel;          //Nivel actual.
   
   [Header("Machines")]
   public int totalBoxes;
   public int actualBox;
   public int actualBoxType;


   private Machine2 machine2;
    
   private void Awake() 
    {
        machine2 = GetComponent<Machine2>();
        isPlaying = false;
    }

    private void Start() 
    {
       Global.score = 0;
       Global.maxTime = 0;
       LoadLevel(Global.level);
 
       //Providional
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
         Global.machine2BoxTime = 10;
         Global.machine2accumulatedBoxesLimit = 3; 
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
       //machine1.StartMachine1();
       machine2.StartMachine2();
       //machine3.StartMachine3();
       isPlaying = true; 
   }

}
