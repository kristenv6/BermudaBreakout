using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewMap : MonoBehaviour
{
    GameObject mapIcon;
    GameObject navigationDot;
    GameObject player;
    bool viewMap = false;
    Vector3 userPosition;
    Scene currentScene;
    Vector2 islandDimensions = new Vector2(10, 10);
    Vector2 caveDimensions = new Vector2(10, 10);
    Vector2 hillsDimensions = new Vector2(10, 10);
    Vector2 forestDimensions = new Vector2(10, 10);

    // Start is called before the first frame update
    void Start()
    {
        mapIcon = GameObject.Find("MapIcon");
        navigationDot = GameObject.Find("NavigationDot");
        player = GameObject.Find("FPSController");

        navigationDot.SetActive(false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        player = GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m")) {
            UserViewsMap();
        }

        if (viewMap) {
            navigationDot.SetActive(true);
            UpdateNavigationDot();
        } else {
            navigationDot.SetActive(false);
        }
    }

    private void UpdateNavigationDot()
    {
        userPosition = player.transform.localPosition;
        currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "IslandScene") 
        {
            float newX = (userPosition.x - 40) * (-75 / -45);
            float newY = (userPosition.z + 40) * (80 / 50);
            navigationDot.transform.localPosition = new Vector3(newX, newY, 1);
        }
        else if (sceneName == "CaveScene") 
        {
            navigationDot.transform.localPosition = new Vector3(40, 42, 1);
        } 
        else if (sceneName == "HillsScene") 
        {
            navigationDot.transform.localPosition = new Vector3(-40, -42, 1);
        } 
        else if (sceneName == "ForestScene") 
        {
            navigationDot.transform.localPosition = new Vector3(40, -42, 1);
        }
    }

    private void UserViewsMap()
    {
        if (!viewMap) {
            mapIcon.transform.localPosition = new Vector3(220, 200, 0);
            mapIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        } else {
            mapIcon.transform.localPosition = new Vector3(330, 300, 0);
            mapIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
        }
        viewMap = !viewMap;
    }
}
