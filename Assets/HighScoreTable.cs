using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        AddHighScoreEntry(10000, "Jessica");

        // highScoreEntryList = new List<HighScoreEntry>() {
        //     new HighScoreEntry{ score = 12345, name = "sarah" },
        //     new HighScoreEntry{ score = 32434, name = "jon" },
        //     new HighScoreEntry{ score = 10101, name = "jake" },
        //     new HighScoreEntry{ score = 39393, name = "jack" },
        //     new HighScoreEntry{ score = 29292, name = "sandy" },
        //     new HighScoreEntry{ score = 43434, name = "jacob" },
        //     new HighScoreEntry{ score = 58585, name = "beatrice" },
        //     new HighScoreEntry{ score = 29292, name = "lee" },
        //     new HighScoreEntry{ score = 55455, name = "kate" },
        //     new HighScoreEntry{ score = 11111, name = "julia" },
        // };

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        for (int i = 0; i < highScores.highScoreEntryList.Count; i++) {
            for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++) {
                if (highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score) {
                    // swap
                    HighScoreEntry temp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = temp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList) {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }

        // HighScores highScores = new HighScores{ highScoreEntryList = highScoreEntryList };
        // string json = JsonUtility.ToJson(highScores);

        // PlayerPrefs.SetString("highScoreTable", json);
        // PlayerPrefs.Save();
        // Debug.Log(PlayerPrefs.GetString("highScoreTable"));
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 40f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
            
        int rank = transformList.Count + 1;
        string rankString = rank.ToString();
        entryTransform.Find("PosTextEntry").GetComponent<Text>().text = rankString;

        int score = highScoreEntry.score;
        entryTransform.Find("TimeTextEntry").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("NameTextEntry").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private void AddHighScoreEntry(int score, string name) {
        HighScoreEntry HighScoreEntry = new HighScoreEntry(score, name);

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        highScores.highScoreEntryList.Add(highScoreEntry);

        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    private class HighScores {
        public List<HighScoreEntry> highScoreEntryList;
    }

    // a single high score entry
    [System.Serializable]
    private class HighScoreEntry {
        public int score;
        public string name;
    }
}
