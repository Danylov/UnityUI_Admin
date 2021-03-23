using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Globalization;
using RSToolkit.Helpers;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DatePicker : MonoBehaviour
{
    private DayToggle[] DayToggles = new DayToggle[7 * 6];
    private bool m_dayTogglesGenerated = false;
    public DayToggle DayToggleTemplate;
    public Text DayNameLabelTemplate;
    [SerializeField] private GridLayoutGroup DayContainer;
    [SerializeField] private Text SelectedDateText;
    [SerializeField] private Text CurrentMonth;
    [SerializeField] private Text CurrentYear;
    public string DateFormat = "dd-MM-yyyy";
    public string MonthFormat = "MMMMM";

    public bool ForwardPickOnly = false;

    // Null so that it can be deselected(Yet to be implemented)
    private DateTime? m_SelectedDate1;
    private DateTime? m_SelectedDate2;

    [SerializeField] private GameObject calendarBlocker;

    public event UnityAction<DateTime?, DateTime?> OnDateSelected = null;

    public DateTime? SelectedDate1
    {
        get { return m_SelectedDate1; }
        private set
        {
            m_SelectedDate1 = value;
            if (m_SelectedDate1 != null)
            {
                SelectedDateText.text = ((DateTime) m_SelectedDate1).ToString(DateFormat);
            }
            else
            {
                SelectedDateText.text = string.Empty;
            }
        }
    }

    public DateTime? SelectedDate2
    {
        get { return m_SelectedDate2; }
        private set
        {
            m_SelectedDate2 = value;
            if (m_SelectedDate2 != null)
            {
                SelectedDateText.text = ((DateTime) m_SelectedDate2).ToString(DateFormat);
            }
            else
            {
                SelectedDateText.text = string.Empty;
            }
        }
    }

    private bool? selectedD1 = null;

    DateTime m_ReferenceDate = DateTime.Now.AddYears(-100);
    DateTime m_DisplayDate = DateTime.Now.AddYears(-101);

    public DateTime ReferenceDateTime
    {
        get { return m_ReferenceDate; }
        set
        {
            m_ReferenceDate = DateTimeHelpers.GetYearMonthStart(value);
            CurrentYear.text = m_ReferenceDate.Year.ToString();
            CurrentMonth.text = m_ReferenceDate.ToString(MonthFormat);
        }
    }

    public DayOfWeek startDayOfWeek;

    void Awake()
    {
        GenerateDaysNames();
        GenerateDaysToggles();
        // Just in case SetSelectedDate is called before the Start function is executed
        if (SelectedDate1 == null)
        {
            SetSelectedDate(DateTime.Today);
        }
        else
        {
            SwitchToSelectedDate();
        }
    }

    public void Activate()
    {
        calendarBlocker.SetActive(true);
    }

    public void Deactivate()
    {
        calendarBlocker.SetActive(false);
    }

    public string Truncate(string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }

    public void GenerateDaysNames()
    {
        int dayOfWeek = (int) startDayOfWeek;
        for (int d = 1; d <= 7; d++)
        {
            string day_name = Truncate(Enum.GetName(typeof(DayOfWeek), dayOfWeek), 3);
            var DayNameLabel = Instantiate(DayNameLabelTemplate);

            day_name = Translate(day_name);

            DayNameLabel.name = String.Format("Day Name Label ({0})", day_name);
            DayNameLabel.transform.SetParent(DayContainer.transform);
            DayNameLabel.transform.localScale = Vector3.one;
            DayNameLabel.GetComponentInChildren<Text>().text = day_name;
            dayOfWeek++;
            if (dayOfWeek >= 7)
            {
                dayOfWeek = 0;
            }
        }
    }

    private string Translate(string dayName)
    {
        switch (dayName)
        {
            case "Mon":
                return "Пн";
            case "Tue":
                return "Вт";
            case "Wed":
                return "Ср";
            case "Thu":
                return "Чт";
            case "Fri":
                return "Пт";
            case "Sat":
                return "Сб";
            case "Sun":
                return "Вс";
        }

        return string.Empty;
    }

    public void GenerateDaysToggles()
    {
        for (int i = 0; i < DayToggles.Length; i++)
        {
            var DayToggle = Instantiate(DayToggleTemplate);
            DayToggle.transform.SetParent(DayContainer.transform);
            DayToggle.transform.localScale = Vector3.one;
            DayToggle.GetComponentInChildren<Text>().text = string.Empty;
            DayToggle.onDateTimeSelected += OnDaySelected;
            DayToggles[i] = DayToggle;
        }

        m_dayTogglesGenerated = true;
    }

    private void DisplayMonthDays(bool refresh = false)
    {
        if (!refresh && m_DisplayDate.IsSameYearMonth(ReferenceDateTime))
        {
            return;
        }

        m_DisplayDate = ReferenceDateTime.DuplicateDate(ReferenceDateTime);

        int monthdays = ReferenceDateTime.DaysInMonth();

        DateTime day_datetime = m_DisplayDate.GetYearMonthStart();

        int dayOffset = (int) day_datetime.DayOfWeek - (int) startDayOfWeek;
        if ((int) day_datetime.DayOfWeek < (int) startDayOfWeek)
        {
            dayOffset = (7 + dayOffset);
        }

        day_datetime = day_datetime.AddDays(-dayOffset);
        for (int i = 0; i < DayToggles.Length; i++)
        {
            SetDayToggle(DayToggles[i], day_datetime);
            day_datetime = day_datetime.AddDays(1);
        }
    }

    void SetDayToggle(DayToggle dayToggle, DateTime toggleDate)
    {
        dayToggle.interactable = ((!ForwardPickOnly || (ForwardPickOnly && !toggleDate.IsPast())) &&
                                  toggleDate.IsSameYearMonth(m_DisplayDate));
        dayToggle.name = String.Format("Day Toggle ({0} {1})", toggleDate.ToString("MMM"), toggleDate.Day);
        dayToggle.SetText(toggleDate.Day.ToString());
        dayToggle.dateTime = toggleDate;

        //dayToggle.IsOn = (SelectedDate1 != null) && ((DateTime) SelectedDate1).IsSameDate(toggleDate);
    }

    public void YearInc_onClick()
    {
        ReferenceDateTime = ReferenceDateTime.AddYears(1);
        DisplayMonthDays(false);

        SelectActiveBlocks();
    }

    public void YearDec_onClick()
    {
        if (!ForwardPickOnly || (!ReferenceDateTime.IsCurrentYear() && !ReferenceDateTime.IsPastYearMonth()))
        {
            ReferenceDateTime = ReferenceDateTime.AddYears(-1);
            DisplayMonthDays(false);

            SelectActiveBlocks();
        }
    }

    public void MonthInc_onClick()
    {
        ReferenceDateTime = ReferenceDateTime.AddMonths(1);
        DisplayMonthDays(false);

        SelectActiveBlocks();
    }

    public void MonthDec_onClick()
    {
        if (!ForwardPickOnly || (!ReferenceDateTime.IsCurrentYearMonth() && !ReferenceDateTime.IsPastYearMonth()))
        {
            ReferenceDateTime = ReferenceDateTime.AddMonths(-1);
            DisplayMonthDays(false);
        }

        SelectActiveBlocks();
    }

    public void SetSelectedDate(DateTime date)
    {
        SelectedDate1 = date;
        SwitchToSelectedDate();
    }

    public void ForceDaySelect(DateTime date1, DateTime date2)
    {
        m_SelectedDate1 = date1;
        m_SelectedDate2 = date2;

        SelectActiveBlocks();

        OnDateSelected?.Invoke(m_SelectedDate1, m_SelectedDate2);
    }

    void OnDaySelected(DateTime? date)
    {
        if (selectedD1 == null)
        {
            SelectedDate1 = date;
            SelectedDate2 = date;

            selectedD1 = true;

            SelectActiveBlocks();
        }
        else
        {
            if ((bool) selectedD1)
            {
                SelectedDate2 = date;
                selectedD1 = false;

                SelectActiveBlocks();
            }
            else
            {
                DeselectAllBlocks();
            }
        }

        Debug.Log(selectedD1);
        Debug.Log(m_SelectedDate1);
        Debug.Log(m_SelectedDate2);

        OnDateSelected?.Invoke(m_SelectedDate1, m_SelectedDate2);
    }

    private void SelectActiveBlocks()
    {
        if (SelectedDate1 < SelectedDate2)
        {
            foreach (var dayToggle in DayToggles)
            {
                dayToggle.SetState(dayToggle.dateTime >= SelectedDate1
                                   && dayToggle.dateTime <= SelectedDate2);
            }
        }
        else
        {
            foreach (var dayToggle in DayToggles)
            {
                dayToggle.SetState(dayToggle.dateTime <= SelectedDate1
                                   && dayToggle.dateTime >= SelectedDate2);
            }
        }
    }

    private void DeselectAllBlocks()
    {
        SelectedDate1 = null;
        SelectedDate2 = null;
        selectedD1 = null;

        foreach (var dayToggle in DayToggles)
        {
            dayToggle.SetState(false);
        }
    }

    public void SwitchToSelectedDate()
    {
        if (SelectedDate1 != null)
        {
            var sd = (DateTime) SelectedDate1;
            if (!sd.IsSameYearMonth(m_DisplayDate))
            {
                ReferenceDateTime = (DateTime) SelectedDate1;
                if (m_dayTogglesGenerated)
                {
                    DisplayMonthDays(false);
                }
            }
        }

        SelectedDate1 = null;
    }

    public void Today_onClick()
    {
        ReferenceDateTime = DateTime.Today;
        DisplayMonthDays(false);
    }
}