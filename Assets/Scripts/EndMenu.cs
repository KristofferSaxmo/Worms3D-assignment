using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private RawImage background;

    private void Start()
    {
        text.text = "Team " + GlobalSceneData.WinningTeam + " Wins!";
        background.color = GlobalSceneData.WinningTeamColor;
    }
    
    private void Update()
    {
        if (Input.anyKey)
            SceneManager.LoadScene(0);
    }
}
