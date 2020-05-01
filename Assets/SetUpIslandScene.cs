using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SetUpIslandScene : MonoBehaviour
{
   GameObject banana1_p;
   GameObject banana2_p;
   GameObject banana3_p;
   
   GameObject banana1;
   GameObject banana2;
   GameObject banana3;
   
    // Start is called before the first frame update
    void Start()
    {
      // load the right amt of hearts
        for (int i = 0; i < GameStats.heartNum; i++) {
          GameObject heart = GameObject.Find("Heart" + i.ToString());
          heart.SetActive(false);
        }
      
        banana1 = GameObject.Find("Banana1"); 
        banana2 = GameObject.Find("Banana2"); 
        banana3 = GameObject.Find("Banana3"); 
        
        banana1_p = GameObject.Find("Banana_1"); 
        banana2_p = GameObject.Find("Banana_2"); 
        banana3_p = GameObject.Find("Banana_3"); 
        
        System.Random rnd = new System.Random();
        int bananas  = rnd.Next(1, 4); 
        if (bananas == 1) {
          banana1.SetActive(true);
          banana2.SetActive(true);
          banana3.SetActive(false);
          
          banana1_p.SetActive(true);
          banana2_p.SetActive(true);
          banana3_p.SetActive(false);
        } 
        else if (bananas == 2) {
          banana1.SetActive(false);
          banana2.SetActive(true);
          banana3.SetActive(true);
          
          banana1_p.SetActive(false);
          banana2_p.SetActive(true);
          banana3_p.SetActive(true);
        }
        else if (bananas == 3) {
          banana1.SetActive(true);
          banana2.SetActive(false);
          banana3.SetActive(true);
          
          banana1_p.SetActive(true);
          banana2_p.SetActive(false);
          banana3_p.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
