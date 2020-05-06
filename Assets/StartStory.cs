using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class StartStory : MonoBehaviour
{
   public GameObject textOne;
   public Text textTwo;
   public Text textThree;
   public Text textFour;
   public Text textFive;
   public Text textSix;
   public Text instructions;
    public Text goodLuck;
    public GameObject imageObject;
   public Image image;
    public Sprite secondImage;
   public Sprite thirdImage;
   public Sprite fourthImage;
   public Sprite portal;
   public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        textOne = GameObject.Find("Text1");
        textTwo = GameObject.Find("Text2").GetComponent<Text>();
        textTwo.color = new Color(textTwo.color.r, textTwo.color.g, textTwo.color.b, 0);
        //textTwo.SetActive(false);
        textThree = GameObject.Find("Text3").GetComponent<Text>();
        textThree.color = new Color(textThree.color.r, textTwo.color.g, textTwo.color.b, 0);
        //textThree.SetActive(false);
        textFour = GameObject.Find("Text4").GetComponent<Text>();
        textFour.color = new Color(textThree.color.r, textTwo.color.g, textTwo.color.b, 0);
        textFive = GameObject.Find("Text5").GetComponent<Text>();
        textFive.color = new Color(textThree.color.r, textTwo.color.g, textTwo.color.b, 0);
        textSix = GameObject.Find("Text6").GetComponent<Text>();
        textSix.color = new Color(textThree.color.r, textTwo.color.g, textTwo.color.b, 0);
        instructions = GameObject.Find("Instructions").GetComponent<Text>();
        instructions.color = new Color(textThree.color.r, textTwo.color.g, textTwo.color.b, 0);

        goodLuck = GameObject.Find("GoodLuck").GetComponent<Text>();
        goodLuck.color = new Color(textThree.color.r, textTwo.color.g, textTwo.color.b, 0);

        imageObject  =GameObject.Find("Image");
        image = imageObject.GetComponent<Image>();

        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        StartCoroutine(ActivationRoutine());
    }

         private IEnumerator ActivationRoutine()
     {        
        // "it all started"
         StartCoroutine(FadeTextToFullAlpha(1f, textOne.GetComponent<Text>()));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(FadeTextToZeroAlpha(1f, textOne.GetComponent<Text>()));
        yield return new WaitForSeconds(1);
        // nasty storm
        StartCoroutine(FadeTextToFullAlpha(1f, textTwo));
        image.sprite = secondImage;
        yield return new WaitForSeconds(3);
        StartCoroutine(FadeTextToZeroAlpha(1f, textTwo));
        yield return new WaitForSeconds(1);
        // you awoke
        StartCoroutine(FadeTextToFullAlpha(1f, textThree));
        image.sprite = thirdImage;
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(FadeTextToZeroAlpha(1f, textThree));
        yield return new WaitForSeconds(1);
        // must now rebuild boat
        StartCoroutine(FadeTextToFullAlpha(1f, textFour));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(FadeTextToZeroAlpha(1f, textFour));
        yield return new WaitForSeconds(1);
        // maintain health
        StartCoroutine(FadeTextToFullAlpha(1f, textFive));
        image.sprite = fourthImage;
        yield return new WaitForSeconds(3);
        StartCoroutine(FadeTextToZeroAlpha(1f, textFive));
        yield return new WaitForSeconds(1);
        // portal
        StartCoroutine(FadeTextToFullAlpha(1f, textSix));
        image.sprite = portal;
        yield return new WaitForSeconds(4f);
        StartCoroutine(FadeTextToZeroAlpha(1f, textSix));
        yield return new WaitForSeconds(1);
        imageObject.SetActive(false);
        StartCoroutine(FadeTextToFullAlpha(1f, instructions));
        yield return new WaitForSeconds(11);
        StartCoroutine(FadeTextToZeroAlpha(1f, instructions));
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeTextToFullAlpha(1f, goodLuck));
        yield return new WaitForSeconds(3);
        StartCoroutine(FadeOut(audio, 0.2f));
        SceneManager.LoadScene("IslandScene");



     }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
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
        public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
       audioSource.volume = startVolume;
    }
}
