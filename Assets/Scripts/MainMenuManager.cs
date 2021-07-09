using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    public string playerName;
    public int currentHScore=0;
    public string hScoreName = "Bob";
    public int currentHScore1 = 0;
    public string hScoreName1 = "Robert";
    public int currentHScore2 = 0;
    public string hScoreName2 = "Patricia";
    public int currentHScore3 = 0;
    public string hScoreName3 = "Annette";
    public int currentHScore4 = 0;
    public string hScoreName4 = "Tanaka";

    //Making this object persistent and unique
    private void Awake()
    {
        LoadHS();
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("MMM destroyed");
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }



    //Store the player name
    public void SetThePlayerName(string name)
    {
        playerName = name;
        Debug.Log("The player is called: " + playerName);

    }

    //Store the player score
    public void StoreHS(int score)
    {
        currentHScore = score;
        hScoreName = playerName;
    }

    //Save the player Highscore along with his name
    [System.Serializable]
    class SavedataNameAndScore
    {
        public string savedName;
        public int savedScore;
        public string savedName1;
        public int savedScore1;
        public string savedName2;
        public int savedScore2;
        public string savedName3;
        public int savedScore3;
        public string savedName4;
        public int savedScore4;
    }

    public void SaveHS()
    {
        SavedataNameAndScore data = new SavedataNameAndScore();
        data.savedName = hScoreName;
        data.savedScore = currentHScore;
        data.savedName1 = hScoreName1;
        data.savedScore1 = currentHScore1;
        data.savedName2 = hScoreName2;
        data.savedScore2 = currentHScore2;
        data.savedName3 = hScoreName3;
        data.savedScore3 = currentHScore3;
        data.savedName4 = hScoreName4;
        data.savedScore4 = currentHScore4;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.dataPath + "/SaveFiles/Highscores.json", json);

    }
    public void LoadHS()
    {
        Debug.Log("Data Loaded");
        string path = Application.dataPath + "/SaveFiles/Highscores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedataNameAndScore data = JsonUtility.FromJson<SavedataNameAndScore>(json);
            hScoreName = data.savedName;
            currentHScore = data.savedScore;
            hScoreName1 = data.savedName1;
            currentHScore1 = data.savedScore1;
            hScoreName2 = data.savedName2;
            currentHScore2 = data.savedScore2;
            hScoreName3 = data.savedName3;
            currentHScore3 = data.savedScore3;
            hScoreName4 = data.savedName4;
            currentHScore4 = data.savedScore4;

        }

    }
    public void ResetSave()
    {
        SavedataNameAndScore data = new SavedataNameAndScore();
        data.savedName = "Bob";
        data.savedScore = 0;
        data.savedName1 = "Robert";
        data.savedScore1 = 0;
        data.savedName2 = "Patricia";
        data.savedScore2 = 0;
        data.savedName3 = "Annette";
        data.savedScore3 = 0;
        data.savedName4 = "Tanaka";
        data.savedScore4 = 0;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.dataPath + "/SaveFiles/Highscores.json", json);

    }

}
