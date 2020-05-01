using System;﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UpdateHealthLevels : MonoBehaviour
{
  GameObject gameOver;
  GameObject updateHealthAudio;
  
  public int lifeGapTime;
  public int nextLife;
  
  float screenWidth;
  float screenHeight;
  
  // Start is called before the first frame update
  void Start()
  {
    gameOver = GameObject.Find("TempGameOver");
    gameOver.SetActive(false);
    
    updateHealthAudio = GameObject.Find("AudioHeartLoss");
  }
  
  // Update is called once per frame
  void Update()
  {
      float xPos = screenWidth - 200;
      float yPos = screenHeight - 225;
      float zPos = this.transform.position.z;
      this.transform.position = new Vector3(xPos, yPos, zPos);

      var ts = TimeSpan.FromSeconds(GameStats.healthTimer);

      if (ts.Seconds == GameStats.nextLife) {
        GameObject heart = GameObject.Find("Heart" + GameStats.heartNum.ToString());
        if (heart) {
          GameStats.heartNum++;
          //Debug.Log("Curr HeartNum: " + GameStats.heartNum);
          heart.SetActive(false);
          updateHealthAudio.GetComponent<AudioSource>().Play();
          if (GameStats.heartNum == 5) {
            gameOver.SetActive(true);
          }
          GameStats.nextLife += GameStats.lifeGapTime;
        }
      }
  }
  
  private void OnGUI()
  {
      screenWidth = Screen.width;
      screenHeight = Screen.height;
  }
  
}
