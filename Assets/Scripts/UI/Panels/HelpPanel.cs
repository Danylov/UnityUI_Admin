using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Il2Cpp;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanel : MonoBehaviour
{
    [SerializeField] private HelpBlock[] trackedBlocks;
    private static readonly Color activeTextColor = new Color32(58, 255, 113, 255);
    private static readonly Color inactiveTextColor = Color.white;

    private bool isOpen = false;

    public void OpenPanel()
    {
        isOpen = true;
        gameObject.SetActive(isOpen);
    }

    public void ClosePanel()
    {
        isOpen = false;
        gameObject.SetActive(isOpen);
    }

    public void SwitchPanelState()
    {
        if (isOpen)
            ClosePanel();
        else
            OpenPanel();
    }

    private void OnEnable()
    {
        foreach (HelpBlock trackedBlock in trackedBlocks)
        {
            trackedBlock.HelpButton.onClick.AddListener(() => ProcessClick(trackedBlock));
        }

        ProcessClick(trackedBlocks[0]);
    }

    private void ProcessClick(HelpBlock helpBlock)
    {
        foreach (var trackedBlock in trackedBlocks)
        {
            trackedBlock.LabText.color = helpBlock == trackedBlock ? activeTextColor : inactiveTextColor;
        }
    }
}