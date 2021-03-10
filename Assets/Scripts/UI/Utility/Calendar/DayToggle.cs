using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using RSToolkit.Helpers;

[RequireComponent(typeof(Button))]
public class DayToggle : MonoBehaviour
{
    private DateTime? m_dateTime;

    public DateTime? dateTime
    {
        get => m_dateTime;
        set
        {
            m_dateTime = value;
        }
    }

    public event UnityAction<DateTime?> onDateTimeSelected = null;

    private bool isOn = false;

    [SerializeField] private Button dayButton;
    [SerializeField] private Text dayText;
    [SerializeField] private Image buttonImage;

    [SerializeField] private Color activeDayColor = Color.white;
    [SerializeField] private Color inactiveDayColor = Color.white;
    
    public bool interactable
    {
        get => dayButton.interactable;
        set
        {
            dayButton.interactable = value;

            dayText.color = value ? Color.black : Color.white;
        }
    }

    private void Start()
    {
        dayButton.onClick.AddListener(() => { onDateTimeSelected(dateTime); });
    }

    public void SetState(bool isActive)
    {
        buttonImage.color = isActive ? activeDayColor : inactiveDayColor;
    }

    public void SetText(string text)
    {
        dayText.text = text;
    }

    public void ClearText()
    {
        SetText(string.Empty);
    }
}