using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCaveWood : MonoBehaviour
{
    GameObject wood1;
    GameObject wood2;
    GameObject woodParent;
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

        if (GameStats.CaveWoodPickedUp)
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
        if (GameStats.caveWoodPosition != new Vector3(0, 0, 0))
        {
            woodParent.transform.position = GameStats.caveWoodPosition;
            return;
        }

        float randValue = Random.value * 4;
        Vector3 pos;
        if (randValue <= 1)
        {
            pos = new Vector3(-40.74f, -4.9f, -56.46f);
        }
        else if (randValue <= 2)
        {
            pos = new Vector3(-57.41f, -4.54f, -70.71f);
        }
        else if (randValue <= 2)
        {
            pos = new Vector3(-75.2f, -4.68f, -53.94f);
        }
        else
        {
            pos = new Vector3(3.2f, -4.91f, -7.6f);
        }

        GameStats.caveWoodPosition = pos;
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
        GameStats.CaveWoodPickedUp = true;
        GameStats.WoodCount += 1;
        woodParent.SetActive(false);

        audioWoodPickup.GetComponent<AudioSource>().Play();
    }
}
