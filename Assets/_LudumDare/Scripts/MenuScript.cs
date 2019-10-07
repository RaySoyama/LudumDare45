﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public string StartScene;

    public void StartGame()
    {      
        ScreenFade.SFade.FadeIn(StartScene);
    }

    public void ShowCredits()
    {
        ScreenFade.SFade.FadeIn("CamCreditScene");
    }

    public void EndGame()
    {
        Application.Quit();
    }



}
