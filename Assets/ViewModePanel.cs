using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModePanel : MonoBehaviour
{
    [SerializeField] private RectTransform viewModePanel;
    [SerializeField] private RectTransform concreteViewPanel;

    public void CloseAllPanels()
    {
        viewModePanel.gameObject.SetActive(false);
        concreteViewPanel.gameObject.SetActive(false);
    }

    public void OpenViewModePanel()
    {
        CloseAllPanels();
        viewModePanel.gameObject.SetActive(true);
    }

    public void OpenConcreteViewPanel()
    {
        CloseAllPanels();
        concreteViewPanel.gameObject.SetActive(true);
    }
}