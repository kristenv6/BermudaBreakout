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

        SetWoodPosition();

        if (GameStats.ForestWoodPickedUp)
        {
            woodParent.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            UserPicksUp();
        }
    }

    private void SetWoodPosition()
    {
        if (GameStats.forestWoodPosition != new Vector3(0, 0, 0))
        {
            woodParent.transform.position = GameStats.forestWoodPosition;
            return;
        }

        float randValue = Random.value * 4;
        Vector3 pos;
        if (randValue <= 1)
        {
            pos = new Vector3(44.33f, 1.59f, 43.29f);
        }
        else if (randValue <= 2)
        {
            pos = new Vector3(23.57f, 0.87f, 47.07f);
        }
        else if (randValue <= 3)
        {
            pos = new Vector3(29.17f, 0.1f, 15.27f);
        }
        else
        {
            pos = new Vector3(43.81f, 1.62f, 42.96f);
        }

        GameStats.forestWoodPosition = pos;
        woodParent.transform.position = pos;
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
