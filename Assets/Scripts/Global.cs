using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    //Geberal
    public static bool canAudioPlay = true;

    //Game
    public static int score = 0;
    public static int maxScore = 0;
    public static int level = 0;
    public static int maxLevel = 10;
    public static int maxTime = 0;
    public static int maxTotalTime = 0;
    public static List<int> requestBox = new List<int>();
    public static int machine2BoxTime = 0;
    public static int machine2accumulatedBoxesLimit;
}
