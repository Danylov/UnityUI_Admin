using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSelector : MonoBehaviour
{
    private DateTime? selectedDate1;
    private DateTime? selectedDate2;

    public void OnClick()
    {
        MenuUIManager.Instance.OpenCalendar();
    }

    private void Awake()
    {
        MenuUIManager.Instance.DatePicker.OnDateSelected += DatePickerOnOnDateSelected;
    }

    private void DatePickerOnOnDateSelected(DateTime d1, DateTime d2)
    {
        if (d1 > d2)
        {
            selectedDate2 = d1;
            selectedDate1 = d2;
        }
        else
        {
            selectedDate1 = d1;
            selectedDate2 = d2;
        }
    }

    private void OnDestroy()
    {
        MenuUIManager.Instance.DatePicker.OnDateSelected -= DatePickerOnOnDateSelected;
    }
}