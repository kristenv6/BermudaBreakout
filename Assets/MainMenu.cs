using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniyEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("IslandScene");
    }

    public void QuitGame() 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
