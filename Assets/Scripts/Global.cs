using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    //Geberal
    public static bool canAudioPlay = true;
    public static bool canSFXPlay = true;

    //Game
    public static int score;
    public static int maxScore = 0;
    public static int level = 1;
    public static int maxLevel = 0;
    public static int maxLevelPublished = 10;
    public static int maxTime;
    public static int maxTotalTime = 0;
    public static List<int> requestBox = new List<int>();
    public static int machine2BoxTime = 0;
    public static int machine2accumulatedBoxesLimit;
}
