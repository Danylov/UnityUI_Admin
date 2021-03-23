using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModePanel : MonoBehaviour
{
    [SerializeField] private ViewsPanel viewModePanel;
    [SerializeField] private ConcreteViewPanel concreteViewPanel;
    [SerializeField] private HardModesPanel hardModesMenu;

    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        
        if (LauncherSettings.Current.ResetPanelStates)
        {
            CloseAllPanels();
            OpenViewModePanel();
        }
    }

    private void CloseAllPanels()
    {
        viewModePanel.ClosePanel();
        hardModesMenu.ClosePanel();
        concreteViewPanel.ClosePanel();
    }

    public void OpenHardModesPanel()
    {
        CloseAllPanels();
        hardModesMenu.OpenPanel();
    }

    public void OpenViewModePanel()
    {
        CloseAllPanels();
        viewModePanel.OpenPanel();
    }

    public void OpenConcreteViewPanel()
    {
        CloseAllPanels();
        concreteViewPanel.OpenPanel();
    }
}