using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SetUpCaveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Text pickupInstructionsText = GameObject.Find("FoodPickUpDir").GetComponent<Text>();
      Image instructionsBackground = GameObject.Find("InstructionsBackground_Food").GetComponent<Image>();
      pickupInstructionsText.enabled = false;
      instructionsBackground.enabled = false;
      
      for (int i = 0; i < GameStats.heartNum; i++) {
        GameObject heart = GameObject.Find("Heart" + i.ToString());
        heart.SetActive(false);
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
