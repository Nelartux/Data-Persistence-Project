using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    public string playerName;
    public int currentHScore;
    public string hScoreName;

    //Making this object persistent and unique
    private void Awake()
    {
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
    }

    //Save the player Highscore along with his name
    [System.Serializable]
    class SavedataNameAndScore
    {
        public string savedName;
        public int savedScore;
    }

    public void SaveHS()
    {
        SavedataNameAndScore data = new SavedataNameAndScore();
        data.savedName = playerName;
        data.savedScore = currentHScore;
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.dataPath + "/SaveFiles/Highscores.json", json);

    }
    public void LoadHS()
    {
        string path = Application.dataPath + "/SaveFiles/Highscores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedataNameAndScore data = JsonUtility.FromJson<SavedataNameAndScore>(json);
            hScoreName = data.savedName;
            currentHScore = data.savedScore;


        }

    }
}
