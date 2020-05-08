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

        //AddHighScoreEntry(1000, "Jessica");

        HighScores highScores;
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        if (jsonString != null) {
            highScores = JsonUtility.FromJson<HighScores>(jsonString);
        } else {
            // in case player prefs gets screwed up
            highScores = null;
            AddDummyHighScores();
        }

        // sort the scores
        highScores.highScoreEntryList.Sort((x, y) => x.score.CompareTo(y.score));

        // prune greater than 10 scores
        if (highScores.highScoreEntryList.Count > 10) {
            for (int i = highScores.highScoreEntryList.Count; i > 10; i--){
                highScores.highScoreEntryList.RemoveAt(10);
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList) {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
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

        float score = highScoreEntry.score;
        System.TimeSpan t = System.TimeSpan.FromSeconds(score);
        string timerFormatted = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
        entryTransform.Find("TimeTextEntry").GetComponent<Text>().text = timerFormatted;

        string name = highScoreEntry.name;
        entryTransform.Find("NameTextEntry").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    public void AddDummyHighScores() {
        // in case player prefs gets screwed up
            List<HighScoreEntry> highScoreEntryList = new List<HighScoreEntry>() {
                new HighScoreEntry{ score = 12345, name = "sarah" },
                new HighScoreEntry{ score = 32434, name = "jon" },
                new HighScoreEntry{ score = 10101, name = "jake" },
                new HighScoreEntry{ score = 39393, name = "jack" },
                new HighScoreEntry{ score = 29292, name = "sandy" },
                new HighScoreEntry{ score = 43434, name = "jacob" },
                new HighScoreEntry{ score = 58585, name = "beatrice" },
                new HighScoreEntry{ score = 29292, name = "lee" },
                new HighScoreEntry{ score = 55455, name = "kate" },
                new HighScoreEntry{ score = 11111, name = "julia" },
            };
            HighScores highScores = new HighScores{ highScoreEntryList = highScoreEntryList };
            string json = JsonUtility.ToJson(highScores);

            PlayerPrefs.SetString("highScoreTable", json);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetString("highScoreTable"));
    }

    public void AddHighScoreEntry(float score, string name) {
        HighScoreEntry highScoreEntry = new HighScoreEntry{ score = score, name = name };

        HighScores highScores;
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        if (jsonString != null) {
            highScores = JsonUtility.FromJson<HighScores>(jsonString);
        } else {
            // in case player prefs gets screwed up
            highScores = null;
            AddDummyHighScores();
        }

        highScores.highScoreEntryList.Add(highScoreEntry);

        // sort the scores
        highScores.highScoreEntryList.Sort((x, y) => x.score.CompareTo(y.score));

        // prune greater than 10 scores
        if (highScores.highScoreEntryList.Count > 10) {
            for (int i = highScores.highScoreEntryList.Count; i > 10; i--){
                highScores.highScoreEntryList.RemoveAt(10);
            }
        }

        // clear out the old transforms
        foreach (Transform highScoreEntryTransform in highScoreEntryTransformList) {
            highScoreEntryTransform.gameObject.SetActive(false);
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry hsEntry in highScores.highScoreEntryList) {
            CreateHighScoreEntryTransform(hsEntry, entryContainer, highScoreEntryTransformList);
        }

        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetString("highScoreTable"));
    }

    private class HighScores {
        public List<HighScoreEntry> highScoreEntryList;
    }

    // a single high score entry
    [System.Serializable]
    private class HighScoreEntry {
        public float score;
        public string name;
    }
}
