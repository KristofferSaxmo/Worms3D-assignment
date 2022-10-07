using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    [SerializeField] private Slider slider;

    public void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void OnValueChange()
    {
        _text.text = slider.value.ToString();
    }
}
