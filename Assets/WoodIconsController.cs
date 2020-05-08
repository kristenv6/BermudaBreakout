using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WoodIconsController : MonoBehaviour
{
    GameObject woodIcon1;
    GameObject woodIcon2;
    GameObject woodIcon3;
    GameObject woodIcon4;
    float screenWidth;
    float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        woodIcon1 = GameObject.Find("WoodCountIcon1");
        woodIcon2 = GameObject.Find("WoodCountIcon2");
        woodIcon3 = GameObject.Find("WoodCountIcon3");
        woodIcon4 = GameObject.Find("WoodCountIcon4");
        woodIcon1.SetActive(false);
        woodIcon2.SetActive(false);
        woodIcon3.SetActive(false);
        woodIcon4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = screenWidth - 550;
        float yPos = screenHeight - 225;
        float zPos = this.transform.position.z;
        this.transform.position = new Vector3(xPos, yPos, zPos);

        if (GameStats.WoodCount >= 1)
        {
            woodIcon1.SetActive(true);
        }
        if (GameStats.WoodCount >= 2)
        {
            woodIcon2.SetActive(true);
        }
        if (GameStats.WoodCount >= 3)
        {
            woodIcon3.SetActive(true);
        }
        if (GameStats.WoodCount >= 4)
        {
            woodIcon4.SetActive(true);
            EndOfGameCleanup();
            SceneManager.LoadScene("BuildBoat");
        }
    }

    private void EndOfGameCleanup()
    {
        GameStats.FinalTime = GameStats.GameTimer;

        GameStats.WoodCount = 0;
        GameStats.IslandWoodPickedUp = false;
        GameStats.CaveWoodPickedUp = false;
        GameStats.HillsWoodPickedUp = false;
        GameStats.ForestWoodPickedUp = false;

        GameStats.islandWoodPosition = new Vector3(0, 0, 0);
        GameStats.caveWoodPosition = new Vector3(0, 0, 0);
        GameStats.forestWoodPosition = new Vector3(0, 0, 0);
        GameStats.hillsWoodPosition = new Vector3(0, 0, 0);

        GameStats.GameTimer = 0;
        GameStats.HealthTimer = 0;
        GameStats.heartNum = 0;
        Destroy(GameObject.Find("MapCanvas"));
    }

    private void OnGUI()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }
}
