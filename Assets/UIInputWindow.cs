using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputWindow : MonoBehaviour
{
    public static string userInputtedName = "";
    public GameObject inputText;
    public GameObject highScoreTable;
    HighScoreTable highScoreTableScript;
    
    private void Awake() {
        Show();

        inputText = GameObject.Find("InputText");
        highScoreTable = GameObject.Find("HighScoreTable");
        highScoreTableScript = highScoreTable.GetComponent<HighScoreTable>();
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void StoreName() {
        userInputtedName = inputText.GetComponent<Text>().text;
        Debug.Log(userInputtedName);
        
        highScoreTableScript.AddHighScoreEntry(11111, userInputtedName);

        Hide();
    }
}
