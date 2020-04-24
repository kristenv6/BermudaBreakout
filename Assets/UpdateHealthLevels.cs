using System;﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UpdateHealthLevels : MonoBehaviour
{
  GameObject gameOver;
  public int lifeGapTime;
  public int nextLife;
  // Start is called before the first frame update
  void Start()
  {
    gameOver = GameObject.Find("TempGameOver");
    gameOver.SetActive(false);
  }
  
  // Update is called once per frame
  void Update()
  {
      var ts = TimeSpan.FromSeconds(GameStats.healthTimer);

      if (ts.Seconds == GameStats.nextLife) {
        GameObject heart = GameObject.Find("Heart" + GameStats.heartNum.ToString());
        if (heart) {
          GameStats.heartNum++;
          //Debug.Log("Curr HeartNum: " + GameStats.heartNum);
          heart.SetActive(false);
          if (GameStats.heartNum == 5) {
            gameOver.SetActive(true);
          }
          GameStats.nextLife += GameStats.lifeGapTime;
        }
      }
  }
  
}
