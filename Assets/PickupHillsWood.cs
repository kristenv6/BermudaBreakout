using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHillsWood : MonoBehaviour
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

        if (GameStats.HillsWoodPickedUp)
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
        if (GameStats.hillsWoodPosition != new Vector3(0, 0, 0))
        {
            woodParent.transform.position = GameStats.hillsWoodPosition;
            return;
        }

        float randValue = Random.value * 4;
        Vector3 pos;
        if (randValue <= 1)
        {
            pos = new Vector3(47.95f, 0.07f, 29.55f);
        }
        else if (randValue <= 2)
        {
            pos = new Vector3(37.27f, 0.41f, 28.95f);
        }
        else if (randValue <= 3)
        {
            pos = new Vector3(17.47f, 0.07f, 46.15f);
        }
        else
        {
            pos = new Vector3(12.66f, 5.667f, 19.823f);
        }

        GameStats.hillsWoodPosition = pos;
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
        GameStats.HillsWoodPickedUp = true;
        GameStats.WoodCount += 1;
        woodParent.SetActive(false);

        audioWoodPickup.GetComponent<AudioSource>().Play();
    }
}
