using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class LeftPanelStudentBlock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI studentNameText;
    [SerializeField] private TextMeshProUGUI labCodeText;

    [SerializeField] private TextMeshProUGUI labTimer;
    [SerializeField] private TextMeshProUGUI pcNumText;

    [SerializeField] private Animator blockAnimator;

    [SerializeField] private Image[] onlineImages;

    private readonly Color activeColor = new Color32(255, 255, 255, 128);
    private readonly Color inactiveColor = new Color32(255, 255, 255, 128);
    private readonly int userEndedLab = Animator.StringToHash("UserEndedLab");

    //public StudentData data 

    /*public void FillData(StudentData data)
    {
        this.data = data;
    }*/


    private void SetOffline()
    {
        foreach (var onlineImage in onlineImages)
        {
            onlineImage.enabled = false;

            labTimer.color = inactiveColor;
        }
    }

    private void SetOnline()
    {
        foreach (var onlineImage in onlineImages)
        {
            onlineImage.enabled = false;

            labTimer.color = activeColor;
        }
    }

    private void AnimateLabEnded()
    {
        blockAnimator.SetTrigger(userEndedLab);
    }
}