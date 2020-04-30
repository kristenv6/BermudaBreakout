using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    public GameObject congratsText;
    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect4;
    public GameObject effect3;
    public GameObject effect5;
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject boat;

    public GameObject gameOverText;
    public GameObject playAgainButton;
    public GameObject mainMenuButton;
    public GameObject quitButton;
    public GameObject panel;
    public float time = 5.0f;
    //sspeedText = GameObject.Find("SpeedText").GetComponent<Text>();


    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.Find("Boat");
        boat.SetActive(false);
        paddle1 = GameObject.Find("paddle1");
        paddle1.SetActive(false);
        paddle2 = GameObject.Find("paddle2");
        paddle2.SetActive(false);
        effect1 = GameObject.Find("Effect_01");
        effect1.SetActive(false);
        effect2 = GameObject.Find("Effect_02");
        effect2.SetActive(false);
        effect3 = GameObject.Find("Effect_03");
        effect3.SetActive(false);    
        effect4 = GameObject.Find("Effect_04");
        effect4.SetActive(false);    
        effect5 = GameObject.Find("Effect_05");
        effect5.SetActive(false);
        congratsText = GameObject.Find("Congrats");
        gameOverText = GameObject.Find("Game Over");
        gameOverText.SetActive(false);

        playAgainButton = GameObject.Find("Play Again");
        playAgainButton.SetActive(false);
        mainMenuButton = GameObject.Find("MainMenu");
        mainMenuButton.SetActive(false);
        quitButton = GameObject.Find("Quit");
        quitButton.SetActive(false);

        panel = GameObject.Find("Panel");
        panel.SetActive(false);

        StartCoroutine(ActivationRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private IEnumerator ActivationRoutine()
     {        
         //Wait for 14 secs.
        yield return new WaitForSeconds(3);
 
         //Turn My game object that is set to false(off) to True(on).
        StartCoroutine(FadeTextToZeroAlpha(1f, congratsText.GetComponent<Text>()));
        //congratsText.SetActive(false);
        effect1.SetActive(true);
        effect2.SetActive(true);
        effect5.SetActive(true);
        effect3.SetActive(true);
        effect4.SetActive(true);
         //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(1.2f);
        boat.SetActive(true);
        paddle1.SetActive(true);
        paddle2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        effect1.SetActive(false);
        effect2.SetActive(false);
        effect3.SetActive(false);
        effect4.SetActive(false);
        effect5.SetActive(false);

        yield return new WaitForSeconds(2);
        panel.SetActive(true);
        gameOverText.SetActive(true);
        playAgainButton.SetActive(true);
        mainMenuButton.SetActive(true);
        quitButton.SetActive(true);
        // SceneManager.LoadScene("GameOver");
     }

    private IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
