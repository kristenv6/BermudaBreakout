using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIslandWood : MonoBehaviour
{
    GameObject wood1;
    GameObject wood2;
    GameObject woodParent;
    GameObject woodCountDisplay;
    GameObject pickupInstructionsText;
    GameObject instructionsBackground;
    public bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        wood1 = GameObject.Find("Wood1");
        wood2 = GameObject.Find("Wood2");
        woodParent = GameObject.Find("WoodParent");
        woodCountDisplay = GameObject.Find("WoodCount");
        pickupInstructionsText = GameObject.Find("WoodPickupInstructions");
        instructionsBackground = GameObject.Find("InstructionsBackground");

        pickupInstructionsText.SetActive(false);
        instructionsBackground.SetActive(false);
        inRange = false;

        if(GameStats.IslandWoodPickedUp)
        {
            woodParent.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown("a"))
        {
            UserPicksUp();
        }

        woodCountDisplay.GetComponent<UnityEngine.UI.Text>().text =
            "Boat Pieces Collected: " + GameStats.WoodCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        pickupInstructionsText.SetActive(true);
        instructionsBackground.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        pickupInstructionsText.SetActive(false);
        instructionsBackground.SetActive(false);
    }

    private void UserPicksUp()
    {
        GameStats.WoodCount = GameStats.WoodCount + 1;
        wood1.SetActive(false);
        wood2.SetActive(false);
        pickupInstructionsText.SetActive(false);
        instructionsBackground.SetActive(false);
        GameStats.IslandWoodPickedUp = true;
        woodParent.SetActive(false);
    }
}
