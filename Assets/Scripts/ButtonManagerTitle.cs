using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonManagerTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MainMenuManager.instance.LoadHS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Move to the game
    public void MoveToGame()
    {
        SceneManager.LoadScene("main");
    }
    //Reset Highscore
    public void ResetHS()
    {
        MainMenuManager.instance.ResetSave();
        MainMenuManager.instance.LoadHS();
    }

    //Exit the game
    public void ExitGame()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }



}
