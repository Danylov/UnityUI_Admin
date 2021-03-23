﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private AuthPanel authPanel;
    [SerializeField] private TaskPanel taskPanel;
    [SerializeField] private UserPanel userPanel;
    [SerializeField] private ViewModePanel viewModePanel;
    [SerializeField] private NotificationsPanel notificationsPanel;
    [SerializeField] private StatsMenu statsPanel;
    [SerializeField] private HelpPanel helpPanel;
    [SerializeField] private LabDescPanel labDescPanel;
    public AuthPanel AuthPanel => authPanel;
    public TaskPanel TaskPanel => taskPanel;
    public UserPanel UserPanel => userPanel;
    public ViewModePanel ViewModePanel => viewModePanel;
    public NotificationsPanel NotificationsPanel => notificationsPanel;
    public StatsMenu StatsPanel => statsPanel;
    public HelpPanel HelpPanel => helpPanel;
    public LabDescPanel LabDescPanel => labDescPanel;

    [SerializeField] private RectTransform mainPanel;
    [SerializeField] private RectTransform plSetUpMenu;

    [Space(10)] [Header("PopupProps")] [SerializeField]
    private Image popupImage;

    [SerializeField] private TextMeshProUGUI popupText;

    [Space(10)] [Header("Calendar")] [SerializeField]
    DatePicker datePicker;

    public DatePicker DatePicker => datePicker;

    private bool notificationsPanelState = false;

    public const float DefaultStretchSpeed = .15f;

    public static MenuUIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);

            Debug.LogError($"More then a single instance of {GetType()}");
        }
    }

    private void CloseAllPanels()
    {
        authPanel.ClosePanel();
        taskPanel.ClosePanel();
        userPanel.ClosePanel();
        viewModePanel.ClosePanel();
        statsPanel.ClosePanel();
        helpPanel.ClosePanel();
        labDescPanel.ClosePanel();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenMainPanel()
    {
        AuthPanel.ClosePanel();
        mainPanel.gameObject.SetActive(true);
    }

    public void OpenCalendar(Vector2 position)
    {
        datePicker.GetComponent<RectTransform>().anchoredPosition = position;
        datePicker.Activate();
    }

    public void OpenHelpPanel()
    {
        helpPanel.OpenPanel();
    }

    public void CloseHelpPanel()
    {
        helpPanel.ClosePanel();
    }

    public void OpenLabDescPanel()
    {
        labDescPanel.OpenPanel();
    }

    public void CloseLabDescPanel()
    {
        labDescPanel.ClosePanel();
    }

    public void CloseCalendar()
    {
        datePicker.Deactivate();
    }

    public void CloseMainPanel()
    {
        mainPanel.gameObject.SetActive(false);
    }

    public void OpenTaskPanel()
    {
        CloseAllPanels();
        taskPanel.OpenPanel();
    }

    public void OpenAuthPanel()
    {
        CloseMainPanel();
        authPanel.OpenPanel();
    }

    public void OpenUserPanel()
    {
        CloseAllPanels();
        userPanel.OpenPanel();
    }

    public void OpenViewModePanel()
    {
        CloseAllPanels();
        viewModePanel.OpenPanel();
    }

    public void OpenStatsPanel()
    {
        CloseAllPanels();
        statsPanel.OpenPanel();
    }

    public void SwitchNotificationsPanelState()
    {
        if (!notificationsPanelState)
            notificationsPanel.OpenPanel();
        else
            notificationsPanel.ClosePanel();

        notificationsPanelState = !notificationsPanelState;
    }

    public void CloseNotificationsPanel()
    {
        notificationsPanel.ClosePanel();

        notificationsPanelState = false;
    }

    public void OpenPLSetUpMenu()
    {
        userPanel.gameObject.SetActive(false);
        plSetUpMenu.gameObject.SetActive(true);
    }

    public void ClosePLSetUpMenu()
    {
        OpenUserPanel();
        plSetUpMenu.gameObject.SetActive(false);
    }

    public void SendPopup(float time, string text, Action onComplete = null)
    {
        StopAllCoroutines();

        StartCoroutine(PopUp(time, text, onComplete));
    }

    private IEnumerator PopUp(float time, string text, Action onComplete)
    {
        popupImage.gameObject.SetActive(true);

        popupText.text = text;

        popupImage.color = new Color32(255, 255, 255, 0);
        popupImage.color = new Color32(255, 255, 255, 0);

        popupImage.DOFade(1f, time / 3f);
        popupText.DOFade(1f, time / 3f);

        yield return new WaitForSeconds(time / 3f);

        yield return new WaitForSeconds(time / 3f);

        popupImage.DOFade(0f, time / 3f);
        popupText.DOFade(0f, time / 3f).OnComplete(() =>
        {
            popupImage.gameObject.SetActive(false);
            onComplete?.Invoke();
        });
    }
}