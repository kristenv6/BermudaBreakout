using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats
{
    private static int woodCount = 0;

    private static bool islandWoodPickedUp = false;
    private static bool caveWoodPickedUp = false;
    private static bool forestWoodPickedUp = false;
    private static bool hillsWoodPickedUp = false;

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
