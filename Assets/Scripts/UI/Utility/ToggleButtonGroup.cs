using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonGroup : MonoBehaviour
{
    [SerializeField] private ToggleButton[] trackingButtons;

    private void Start()
    {
        foreach (var trackingButton in trackingButtons)
        {
            trackingButton.Button.onClick.AddListener(() =>
            {
                trackingButton.isInGroup = true;
                UpdateGroup(trackingButton);
            });
        }
    }

    private void UpdateGroup(ToggleButton enabledButton)
    {
        foreach (var trackingButton in trackingButtons)
        {
            trackingButton.SetState(trackingButton == enabledButton);
        }
    }
}