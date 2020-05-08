using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Apple2Pickup : MonoBehaviour
{
    GameObject foodItem;
    GameObject healthSystem;
    Text pickupInstructionsText;
    Image instructionsBackground;
    public bool inRange;
    
    GameObject foodSound;
    
    // Start is called before the first frame update
    void Start()
    {
      foodItem = GameObject.Find("Apple2");  
      healthSystem = GameObject.Find("HealthSystem");
      pickupInstructionsText = GameObject.Find("FoodPickUpDir").GetComponent<Text>();
      instructionsBackground = GameObject.Find("InstructionsBackground_Food").GetComponent<Image>();
      foodSound = GameObject.Find("AudioFoodPickup");
      
      pickupInstructionsText.enabled = false;
      instructionsBackground.enabled = false;
      inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (inRange && Input.GetKeyDown("space"))
      {
          UserPicksUp();
      }
    }
    
    private void OnTriggerEnter(Collider other)
    {
      if(foodItem.activeSelf) {
        inRange = true;
        pickupInstructionsText.enabled = true;
        instructionsBackground.enabled = true;
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if(foodItem.activeSelf) {
        inRange = false;
        pickupInstructionsText.enabled = false;
        instructionsBackground.enabled = false;
      }
    }

    private void UserPicksUp()
    {
        foodItem.SetActive(false);
        pickupInstructionsText.enabled = false;
        instructionsBackground.enabled = false;
        foodSound.GetComponent<AudioSource>().Play();
        StartCoroutine(FoodCoroutine());
        
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
        }
        
    }
    
    IEnumerator FoodCoroutine() {
      yield return new WaitForSeconds(60f);
      foodItem.SetActive(true);
    }
}
