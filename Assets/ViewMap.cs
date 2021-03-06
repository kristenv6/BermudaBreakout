﻿using System.Collections;
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

    float screenWidth;
    float screenHeight;

    float transformIslandX = -50;
    float transformIslandY = 50;
    float scaleIslandX = 155f/180;
    float scaleIslandY = 150f/180;

    float transformHillsX = 0;
    float transformHillsY = 0;
    float scaleHillsX = 155f/90;
    float scaleHillsY = 150f/90;

    float transformCaveX = -20;
    float transformCaveY = 85;
    float scaleCaveX = 155f/180;
    float scaleCaveY = 150f/180;

    float transformForestX = -50;
    float transformForestY = -50;
    float scaleForestX = 155f/90;
    float scaleForestY = -150f/90;

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
            ToggleViewMap();
        }

        UserViewsMap();

        if (viewMap) {
            navigationDot.SetActive(true);
            UpdateNavigationDot();
        } else {
            navigationDot.SetActive(false);
        }
    }

    private void UpdateNavigationDot()
    {
        player = GameObject.Find("FPSController");

        userPosition = player.transform.localPosition;
        currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "IslandScene") 
        {
            float newX = (userPosition.x + transformIslandX) * scaleIslandX;
            float newY = (userPosition.z + transformIslandY) * scaleIslandY;
            navigationDot.transform.localPosition = new Vector3(newX, newY, 1);
        }
        else if (sceneName == "CaveScene") 
        {
            float transformedX = userPosition.x + transformCaveX;
            float transformedY = userPosition.z + transformCaveY;
            float newX = RotateX(transformedX, transformedY, 90) * scaleCaveX;
            float newY = RotateY(transformedX, transformedY, 90) * scaleCaveY;
            navigationDot.transform.localPosition = new Vector3(newX, newY, 1);
        } 
        else if (sceneName == "HillsScene") 
        {
            float transformedX = userPosition.x + transformHillsX;
            float transformedY = userPosition.z + transformHillsY;
            float newX = RotateX(transformedX, transformedY, 180) * scaleHillsX;
            float newY = RotateY(transformedX, transformedY, 180) * scaleHillsY;
            navigationDot.transform.localPosition = new Vector3(newX, newY, 1);
        } 
        else if (sceneName == "ForestScene") 
        {
            float transformedX = userPosition.x + transformForestX;
            float transformedY = userPosition.z + transformForestY;
            float newX = RotateX(transformedX, transformedY, 180) * scaleForestX;
            float newY = RotateY(transformedX, transformedY, 180) * scaleForestY;
            navigationDot.transform.localPosition = new Vector3(newX, newY, 1);
        }
    }

    private float RotateX(float x, float y, float angle) {
        float radAngle = angle * Mathf.Deg2Rad;
        float newX = x * Mathf.Cos(radAngle) + y * Mathf.Sin(radAngle);

        return newX;
    }

    private float RotateY(float x, float y, float angle) {
        float radAngle = angle * Mathf.Deg2Rad;
        float newY = -1 * x * Mathf.Sin(radAngle) + y * Mathf.Cos(radAngle);

        return newY;
    }

    private void UserViewsMap()
    {
        if (viewMap) {
            float xPos = screenWidth - 450;
            float yPos = screenHeight - 190;
            mapIcon.transform.position = new Vector3(xPos, yPos, 0);
            //mapIcon.transform.localPosition = new Vector3(220, 200, 0);
            mapIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        } else {
            float xPos = screenWidth - 350;
            float yPos = screenHeight - 90;
            mapIcon.transform.position = new Vector3(xPos, yPos, 0);
            //mapIcon.transform.localPosition = new Vector3(330, 300, 0);
            mapIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
    }

    private void ToggleViewMap() 
    {
        viewMap = !viewMap;
    }

    private void OnGUI()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }
}
