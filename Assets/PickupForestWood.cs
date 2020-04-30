using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupForestWood : MonoBehaviour
{
    GameObject wood1;
    GameObject wood2;
    GameObject woodParent;
    GameObject woodIcon4;
    GameObject pickupInstructionsText;
    GameObject instructionsBackground;
    GameObject audioWoodPickup;
    public bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        wood1 = GameObject.Find("Wood1");
        wood2 = GameObject.Find("Wood2");
        woodParent = GameObject.Find("WoodParent");
        pickupInstructionsText = GameObject.Find("WoodPickupInstructions");
        instructionsBackground = GameObject.Find("InstructionsBackground");
        audioWoodPickup = GameObject.Find("AudioWoodPickup");

        pickupInstructionsText.SetActive(false);
        instructionsBackground.SetActive(false);
        inRange = false;

        if (GameStats.ForestWoodPickedUp)
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
        wood1.SetActive(false);
        wood2.SetActive(false);
        pickupInstructionsText.SetActive(false);
        instructionsBackground.SetActive(false);
        GameStats.ForestWoodPickedUp = true;
        GameStats.WoodCount += 1;
        woodParent.SetActive(false);

        audioWoodPickup.GetComponent<AudioSource>().Play();
    }
}
