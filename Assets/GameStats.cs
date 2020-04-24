﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public static class GameStats
{
    // game timer
    public static float gameTimer = 0;
    
    // health levels
    public static float healthTimer = 0;
    public static int heartNum = 0;
    public static int orig_lifeGapTime = 60;
    public static int orig_nextLife = 60;
    public static int lifeGapTime = 60;
    public static int nextLife = 60;
    
    // wood pickup vars 
    private static int woodCount = 0;

    private static bool islandWoodPickedUp = false;
    private static bool caveWoodPickedUp = false;
    private static bool forestWoodPickedUp = false;
    private static bool hillsWoodPickedUp = false;

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
    
    public static int LifeGapTimeOrig
    {
        get
        {
            return orig_lifeGapTime;
        }
        set
        {
            orig_lifeGapTime = value;
        }
    }
    
    public static int NextLife
    {
        get
        {
            return nextLife;
        }
        set
        {
            nextLife = value;
        }
    }
    
    public static int NextLifeOrig
    {
        get
        {
            return orig_nextLife;
        }
        set
        {
            orig_nextLife = value;
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

}
