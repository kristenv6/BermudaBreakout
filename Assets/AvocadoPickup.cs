using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AvocadoPickup : MonoBehaviour
{
    GameObject foodItem;
    GameObject healthSystem;
    Text pickupInstructionsText;
    Image instructionsBackground;
    public bool inRange;
    
    // Start is called before the first frame update
    void Start()
    {
      foodItem = GameObject.Find("Avocado");  
      healthSystem = GameObject.Find("HealthSystem");
      pickupInstructionsText = GameObject.Find("FoodPickUpDir").GetComponent<Text>();
      instructionsBackground = GameObject.Find("InstructionsBackground_Food").GetComponent<Image>();
      
      pickupInstructionsText.enabled = false;
      instructionsBackground.enabled = false;
      inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (inRange && Input.GetKeyDown("a"))
      {
          UserPicksUp();
      }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        pickupInstructionsText.enabled = true;
        instructionsBackground.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        pickupInstructionsText.enabled = false;
        instructionsBackground.enabled = false;
    }

    private void UserPicksUp()
    {
        foodItem.SetActive(false);
        pickupInstructionsText.enabled = false;
        instructionsBackground.enabled = false;
        
        // do the health stuff 
        int heartToShow = GameStats.heartNum;
        GameObject heart = null;
        Debug.Log("looking for " + "Heart" + GameStats.heartNum.ToString());
        Transform[] trs= healthSystem.GetComponentsInChildren<Transform>(true);
        foreach(Transform t in trs){
           int temp = GameStats.heartNum - 1;
           if(t.name == "Heart" + temp.ToString()){
                heart =  t.gameObject;
           }
        }
        
        if (heart) {
          if (GameStats.heartNum > 0) {
            GameStats.heartNum--;
            Debug.Log("heart num is " + GameStats.heartNum);
          }
          heart.SetActive(true);
          setRestToActive(trs);
          GameStats.healthTimer = 0;
          GameStats.lifeGapTime = GameStats.orig_lifeGapTime;
          GameStats.nextLife = GameStats.orig_nextLife;
        }
        
    }
    
    void setRestToActive(Transform[] trs) {
      while (GameStats.heartNum > -1) {
        foreach(Transform t in trs) {
           if(t.name == "Heart" + GameStats.heartNum.ToString()){
                GameObject heart =  t.gameObject;
                heart.SetActive(true);
           }
        }
        GameStats.heartNum--;
      }
      GameStats.heartNum++;
    }
    
}
