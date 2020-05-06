using System;﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SetUpForestScene : MonoBehaviour
{
   GameObject avo_p;
   GameObject apple1_p;
   GameObject apple2_p;
   
   GameObject avo;
   GameObject apple1;
   GameObject apple2;
   
    // Start is called before the first frame update
    void Start()
    {
      Text pickupInstructionsText = GameObject.Find("FoodPickUpDir").GetComponent<Text>();
      Image instructionsBackground = GameObject.Find("InstructionsBackground_Food").GetComponent<Image>();
      
      pickupInstructionsText.enabled = false;
      instructionsBackground.enabled = false;
      
      // load the right amt of hearts
        for (int i = 0; i < GameStats.heartNum; i++) {
          GameObject heart = GameObject.Find("Heart" + i.ToString());
          heart.SetActive(false);
        }
      
        avo = GameObject.Find("Avocado"); 
        apple1 = GameObject.Find("Apple1"); 
        apple2 = GameObject.Find("Apple2"); 
        
        avo_p = GameObject.Find("SpecialFood"); 
        apple1_p = GameObject.Find("Apple_1"); 
        apple2_p = GameObject.Find("Apple_2"); 
        
        System.Random rnd = new System.Random();
        int bananas  = rnd.Next(1, 4); 
        if (bananas == 1) {
          avo.SetActive(true);
          apple1.SetActive(true);
          apple2.SetActive(false);
          
          avo_p.SetActive(true);
          apple1_p.SetActive(true);
          apple2_p.SetActive(false);
        } 
        else if (bananas == 2) {
          avo.SetActive(false);
          apple1.SetActive(true);
          apple2.SetActive(true);
          
          avo_p.SetActive(false);
          apple1_p.SetActive(true);
          apple2_p.SetActive(true);
        }
        else if (bananas == 3) {
          avo.SetActive(true);
          apple1.SetActive(false);
          apple2.SetActive(true);
          
          avo_p.SetActive(true);
          apple1_p.SetActive(false);
          apple2_p.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
