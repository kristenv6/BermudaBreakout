using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSPositionController : MonoBehaviour
{
    public Vector3 islandStartPosition = new Vector3(5, 8, -3);
    public Vector3 islandFromCavePosition = new Vector3(40, 2, -30);
    public Vector3 islandFromHillsPosition = new Vector3(-4, 3, -40);
    public Vector3 caveFromForestPosition = new Vector3(8, -2, -36);
    public Vector3 caveFromIslandPosition = new Vector3(-2, -2, -68);
    public Vector3 forestFromCavePosition = new Vector3(9.5f, 5, 42.5f);
    public Vector3 forestFromHillsPosition = new Vector3(42, 1, 23);
    public Vector3 hillsFromIslandPosition = new Vector3(8, 2, 6);
    public Vector3 hillsFromForestPosition = new Vector3(5, 1, 37);
    public string activeSceneName;
    public string oldSceneName;

    // Start is called before the first frame update
    void Start()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        oldSceneName = GameStats.CurrSceneName;
        activeSceneName = activeScene.name;
        GameStats.CurrSceneName = activeScene.name;

        this.GetComponent<CharacterController>().enabled = false;

        if (activeScene.name == "IslandScene" && oldSceneName == "")
        {
            this.transform.position = islandStartPosition;
        }
        else if (activeScene.name == "IslandScene" && oldSceneName == "CaveScene")
        {
            this.transform.position = islandFromCavePosition;
        }
        else if (activeScene.name == "IslandScene" && oldSceneName == "HillsScene")
        {
            this.transform.position = islandFromHillsPosition;
        }
        else if (activeScene.name == "CaveScene" && oldSceneName == "ForestScene")
        {
            this.transform.position = caveFromForestPosition;
        }
        else if (activeScene.name == "CaveScene" && oldSceneName == "IslandScene")
        {
            this.transform.position = caveFromIslandPosition;
        }
        else if (activeScene.name == "ForestScene" && oldSceneName == "CaveScene")
        {
            this.transform.position = forestFromCavePosition;
        }
        else if (activeScene.name == "ForestScene" && oldSceneName == "HillsScene")
        {
            this.transform.position = forestFromHillsPosition;
        }
        else if (activeScene.name == "HillsScene" && oldSceneName == "IslandScene")
        {
            this.transform.position = hillsFromIslandPosition;
        }
        else if (activeScene.name == "HillsScene" && oldSceneName == "ForestScene")
        {
            this.transform.position = hillsFromForestPosition;
        }

        this.GetComponent<CharacterController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
