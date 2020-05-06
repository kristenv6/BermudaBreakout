using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIslandWood : MonoBehaviour
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

        if(GameStats.IslandWoodPickedUp)
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
        if (GameStats.islandWoodPosition != new Vector3(0, 0, 0))
        {
            woodParent.transform.position = GameStats.islandWoodPosition;
            return;
        }

        float randValue = Random.value * 4;
        Vector3 pos;
        if (randValue <= 1)
        {
            pos = new Vector3(28.12f, 1.37f, -36.17f);
        }
        else if (randValue <= 2)
        {
            pos = new Vector3(-40.35f, 0.42f, -38.83f);
        }
        else if (randValue <= 2)
        {
            pos = new Vector3(43.81f, 0.69f, 37.31f);
        }
        else
        {
            pos = new Vector3(-15.8f, 1.04f, 37.13f);
        }

        GameStats.islandWoodPosition = pos;
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
        GameStats.IslandWoodPickedUp = true;
        GameStats.WoodCount += 1;
        woodParent.SetActive(false);

        audioWoodPickup.GetComponent<AudioSource>().Play();
    }
}
