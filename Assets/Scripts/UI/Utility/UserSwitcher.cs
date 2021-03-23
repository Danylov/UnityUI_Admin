using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSwitcher : MonoBehaviour
{
    [SerializeField] private Button studentsButton;
    [SerializeField] private Button teachersButton;
    [SerializeField] private Image studentsImage;
    [SerializeField] private Image teachersImage;

    [SerializeField] private GameObject filter;
    
    private bool isStudentState = false;

    private void Start()
    {
        studentsButton.onClick.AddListener(SetStudentState);
        teachersButton.onClick.AddListener(SetTeacherState);
    }

    private void SetTeacherState()
    {
        isStudentState = false;
        
        filter.SetActive(false);

        studentsImage.gameObject.SetActive(true);
        teachersImage.gameObject.SetActive(false);
    }

    private void SetStudentState()
    {
        isStudentState = true;
        
        filter.SetActive(true);

        studentsImage.gameObject.SetActive(false);
        teachersImage.gameObject.SetActive(true);
    }

    public void SwitchState()
    {
        if (isStudentState)
            SetTeacherState();
        else
            SetStudentState();
    }
}