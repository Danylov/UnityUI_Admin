using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DateSelector : MonoBehaviour
{
    private DateTime? selectedDate1;
    private DateTime? selectedDate2;
    [SerializeField] private DatePicker picker;

    [SerializeField] private string defaultText = "Выбрать дату (от\\до)";
    [SerializeField] private TMP_InputField dateInputField;

    [SerializeField] private Vector2 calendarPosition = Vector2.zero;

    public void OnClick()
    {
        MenuUIManager.Instance.OpenCalendar(calendarPosition);
    }

    private void Awake()
    {
        dateInputField.onEndEdit.AddListener(ProcessEndEdit);
    }

    public void ProcessEndEdit(string editedText)
    {
        var dates = editedText.Replace(" ", string.Empty)
            .Split('-');


        if (dates.Length == 2 && DateTime.TryParse(dates[0], out DateTime resultD1)
                              && DateTime.TryParse(dates[1], out DateTime resultD2))
        {
            if (resultD1 < resultD2)
                picker.ForceDaySelect(resultD1, resultD2);
            else
                picker.ForceDaySelect(resultD2, resultD1);
        }
        else if (selectedDate1 == null && selectedDate2 == null)
        {
            dateInputField.interactable = false;
            dateInputField.text = defaultText;
        }
        else
        {
            dateInputField.interactable = true;
            dateInputField.text = $"{selectedDate1?.ToString("dd/MM/yyyy")} - {selectedDate2?.ToString("dd/MM/yyyy")}";
        }
    }

    private void OnEnable()
    {
        MenuUIManager.Instance.DatePicker.OnDateSelected += DatePickerOnOnDateSelected;

        dateInputField.interactable = false;
    }

    private void OnDisable()
    {
        picker.ForceDaySelect(null, null);
        
        MenuUIManager.Instance.DatePicker.OnDateSelected -= DatePickerOnOnDateSelected;
    }

    private void DatePickerOnOnDateSelected(DateTime? d1, DateTime? d2)
    {
        if (d1 == null && d2 == null)
        {
            selectedDate1 = d1;
            selectedDate2 = d2;

            dateInputField.text = defaultText;
            dateInputField.interactable = false;
            return;
        }

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

        dateInputField.interactable = true;

        dateInputField.text = $"{d1?.ToString("dd/MM/yyyy")} - {d2?.ToString("dd/MM/yyyy")}";
    }

    private void OnDestroy()
    {
        MenuUIManager.Instance.DatePicker.OnDateSelected -= DatePickerOnOnDateSelected;
    }
}