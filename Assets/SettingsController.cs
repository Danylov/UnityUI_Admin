using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private ToggleButton resetWindowsStateToggle;

    private void Start()
    {
        resetWindowsStateToggle.Button.onClick.AddListener(() => SetResetWindowSetting(resetWindowsStateToggle.IsOn));
    }

    public void SetResetWindowSetting(bool isOn)
    {
        LauncherSettings.Current.ResetPanelStates = isOn;
    }
}