using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform taskPanel;
    [SerializeField] private RectTransform userPanel;
    [SerializeField] private RectTransform viewModePanel;
    [SerializeField] private RectTransform notificationsPanel;
    [SerializeField] private RectTransform statsPanel;

    private bool notificationsPanelState = false;

    private void DeactivateAllPanels()
    {
        taskPanel.gameObject.SetActive(false);
        userPanel.gameObject.SetActive(false);
        viewModePanel.gameObject.SetActive(false);
        statsPanel.gameObject.SetActive(false);
    }

    public void OpenTaskPanel()
    {
        DeactivateAllPanels();
        taskPanel.gameObject.SetActive(true);
    }

    public void OpenUserPanel()
    {
        DeactivateAllPanels();
        userPanel.gameObject.SetActive(true);
    }

    public void OpenViewModePanel()
    {
        DeactivateAllPanels();
        viewModePanel.gameObject.SetActive(true);
    }

    public void OpenNotificationsPanel()
    {
        notificationsPanelState = true;
        notificationsPanel.gameObject.SetActive(notificationsPanelState);
    }

    public void CloseNotificationsPanel()
    {
        notificationsPanelState = false;
        notificationsPanel.gameObject.SetActive(notificationsPanelState);
    }

    public void OpenStatsPanel()
    {
        DeactivateAllPanels();
        statsPanel.gameObject.SetActive(true);
    }

    public void SwitchNotificationsPanelState()
    {
        if (notificationsPanelState)
            CloseNotificationsPanel();
        else
            OpenNotificationsPanel();
    }
}