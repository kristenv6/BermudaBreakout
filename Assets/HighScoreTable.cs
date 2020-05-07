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

        highScoreEntryList = new List<HighScoreEntry>() {
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

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScoreEntryList) {
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

        int score = highScoreEntry.score;
        entryTransform.Find("TimeTextEntry").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("NameTextEntry").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    // a single high score entry
    private class HighScoreEntry {
        public int score;
        public string name;
    }
}
