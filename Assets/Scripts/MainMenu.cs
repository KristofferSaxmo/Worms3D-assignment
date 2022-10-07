using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider teamSlider;
    [SerializeField] private Slider wormSlider;
    public void LoadGame()
    {
        GlobalSceneData.TeamAmount = (int)teamSlider.value;
        GlobalSceneData.WormsPerTeam = (int)wormSlider.value;
        SceneManager.LoadScene(1);
    }
}
