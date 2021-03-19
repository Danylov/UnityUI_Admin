using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
    
    public static readonly string connect = "Server=localhost;Database=uiadmin;User ID=mysql;Password=mysql;Pooling=true;CharSet=utf8;"; 
    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            Debug.LogError($"More then a single instance of {GetType()}");
        }
    }

    private void CloseAllPanels()
    {
        authPanel.CloseAllPanels();
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
        authPanel.CloseAllPanels();
        mainPanel.gameObject.SetActive(true);
    }
 
    public void OpenCalendar()
    {
        datePicker.gameObject.SetActive(true);
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
        datePicker.gameObject.SetActive(false);
    }

    public void CloseMainPanel()
    {
        mainPanel.gameObject.SetActive(false);
    }

    public void OpenTaskPanel()
    {
        // CloseAllPanels();
        OpenMainPanel();
        taskPanel.OpenPanel();
    }

    public void OpenAuthPanel()
    {
        CloseMainPanel();
        authPanel.OpenAuthorizationPanel();
    }

    public void OpenUserPanel()
    {
        // CloseAllPanels();
        OpenMainPanel();
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
        if (!notificationsPanelState) notificationsPanel.OpenPanel();
        else notificationsPanel.ClosePanel();
        notificationsPanelState = !notificationsPanelState;
    }

    public void CloseNotificationsPanel()
    {
        notificationsPanel.ClosePanel();
        notificationsPanelState = false;
    }

    public void OpenPLSetUpMenu()
    {
        userPanel.ClosePanel();
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

    public static string PasswEncryption(string notEncrPassw)
    {
        MD5 md5 = new MD5CryptoServiceProvider();  
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(notEncrPassw));  
        byte[] result = md5.Hash;  
        StringBuilder strBuilder = new StringBuilder();  
        for (int i = 0; i < result.Length; i++)  strBuilder.Append(result[i].ToString("x2"));  
        return strBuilder.ToString();          
    }

}