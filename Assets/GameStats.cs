﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GameStats
{
    // game timer
    public static float gameTimer = 0;

    // final game timer
    public static float finalTime = 0;
    
    // health levels
    public static float healthTimer = 0;
    public static int heartNum = 0;
    public static int lifeGapTime = 30;
    
    // wood pickup vars 
    private static int woodCount = 0;

    private static bool islandWoodPickedUp = false;
    private static bool caveWoodPickedUp = false;
    private static bool forestWoodPickedUp = false;
    private static bool hillsWoodPickedUp = false;

    public static Vector3 islandWoodPosition = new Vector3(0, 0, 0);
    public static Vector3 caveWoodPosition = new Vector3(0, 0, 0);
    public static Vector3 forestWoodPosition = new Vector3(0, 0, 0);
    public static Vector3 hillsWoodPosition = new Vector3(0, 0, 0);

    //scene
    private static string currSceneName = "";

    // timer function
    public static float GameTimer
    {
        get
        {
            return gameTimer;
        }
        set
        {
            gameTimer = value;
        }
    }

      // timer function
    public static float FinalTime
    {
        get
        {
            return finalTime;
        }
        set
        {
            finalTime = value;
        }
    }
    
    // food function 
    public static float HealthTimer
    {
        get
        {
            return healthTimer;
        }
        set
        {
            healthTimer = value;
        }
    }
    
    public static int HealthLevel
    {
        get
        {
            return heartNum;
        }
        set
        {
            heartNum = value;
        }
    }
    
    public static int LifeGapTime
    {
        get
        {
            return lifeGapTime;
        }
        set
        {
            lifeGapTime = value;
        }
    }
    
    
    // wood pick upfunctions
    public static int WoodCount
    {
        get
        {
            return woodCount;
        }
        set
        {
            woodCount = value;
        }
    }

    public static bool IslandWoodPickedUp
    {
        get
        {
            return islandWoodPickedUp;
        }
        set
        {
            islandWoodPickedUp = value;
        }
    }

    public static bool CaveWoodPickedUp
    {
        get
        {
            return caveWoodPickedUp;
        }
        set
        {
            caveWoodPickedUp = value;
        }
    }

    public static bool ForestWoodPickedUp
    {
        get
        {
            return forestWoodPickedUp;
        }
        set
        {
            forestWoodPickedUp = value;
        }
    }

    public static bool HillsWoodPickedUp
    {
        get
        {
            return hillsWoodPickedUp;
        }
        set
        {
            hillsWoodPickedUp = value;
        }
    }

    public static string CurrSceneName
    {
        get
        {
            return currSceneName;
        }
        set
        {
            currSceneName = value;
        }
    }

}
