using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonOne : MonoBehaviour
{
    private readonly List<ToggleButton> trackingButtons = new List<ToggleButton>();

    public void AddButton(ToggleButton trackingButton)
    {
        trackingButtons.Add(trackingButton);
        trackingButton.isInGroup = true;
        trackingButton.Button.onClick.AddListener(() =>
        {
            SwitchButtons(trackingButton);
        });
    }

    public void freeList()
    {
        trackingButtons.Clear();
    }

    private void SwitchButtons(ToggleButton currButton)
    {
        foreach (var trackingButton in trackingButtons)
        {
            if (trackingButton == currButton) trackingButton.SetState(true);
            else trackingButton.SetState(false);
        }
    }
}