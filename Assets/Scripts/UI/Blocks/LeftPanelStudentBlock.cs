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

    [SerializeField] private Image rBlockImage;
    [SerializeField] private Image blockImage;

    [SerializeField] private Sprite activeBlockSprite;
    [SerializeField] private Sprite inactiveBlockSprite;

    private readonly Color activeColor = new Color32(255, 255, 255, 128);
    private readonly Color inactiveColor = new Color32(255, 0, 61, 255);
    private readonly int userEndedLab = Animator.StringToHash("UserEndedLab");

    //public StudentData data 

    /*public void FillData(StudentData data)
    {
        this.data = data;
    }*/


    private void SetOffline()
    {
        rBlockImage.enabled = false;
        blockImage.sprite = inactiveBlockSprite;

        labTimer.color = inactiveColor;
    }

    private void SetOnline()
    {
        rBlockImage.enabled = true;
        blockImage.sprite = activeBlockSprite;

        labTimer.color = activeColor;
    }

    private void AnimateLabEnded()
    {
        blockAnimator.SetTrigger(userEndedLab);
    }
}