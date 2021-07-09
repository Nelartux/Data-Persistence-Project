using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    void Update()
    {
        highscore.text ="" + MainMenuManager.instance.hScoreName + " - " + MainMenuManager.instance.currentHScore + "\n"
            + MainMenuManager.instance.hScoreName1 + " - " + MainMenuManager.instance.currentHScore1 + "\n"
            + MainMenuManager.instance.hScoreName2 + " - " + MainMenuManager.instance.currentHScore2 + "\n"
            + MainMenuManager.instance.hScoreName3 + " - " + MainMenuManager.instance.currentHScore3 + "\n"
            + MainMenuManager.instance.hScoreName4 + " - " + MainMenuManager.instance.currentHScore4 + "\n"
            ;
    }
}
