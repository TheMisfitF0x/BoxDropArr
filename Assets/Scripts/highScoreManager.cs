using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScoreManager : MonoBehaviour
{
    static int highScore;

    public static void updateScore(int newVal)
    {

    }

    public static int getScore()
    {
        return highScore;
    }

    public static void resetScore()
    {
        highScore = 0;
    }
}
