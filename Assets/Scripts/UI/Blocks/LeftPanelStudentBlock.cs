using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class LeftPanelStudentBlock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI studentNameText;
    [SerializeField] private TextMeshProUGUI labCodeText;

    [SerializeField] private TextMeshProUGUI labTimer;
    [SerializeField] private TextMeshProUGUI pcNumText;

    [SerializeField] private Animator blockAnimator;
    
    //public StudentData data 

    /*public void FillData(StudentData data)
    {
        this.data = data;
    }*/

    public void StartStudentEndLabAnim()
    {
        // potom :]
    }
}