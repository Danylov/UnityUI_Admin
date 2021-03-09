using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthPanel : MonoBehaviour
{
    [SerializeField] private AuthorizationPanel authoriaztionPanel;
    [SerializeField] private RegistrationAdminPanel registrationAdminPanel;
    [SerializeField] private RegistrationStudentPanel registrationStudentPanel;

    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    private void CloseAllPanels()
    {
        authoriaztionPanel.ClosePanel();
        registrationAdminPanel.ClosePanel();
        registrationStudentPanel.ClosePanel();
    }

    public void OpenAuthorizationPanel()
    {
        CloseAllPanels();
        authoriaztionPanel.OpenPanel();
    }

    public void OpenRegistrationAdminPanel()
    {
        CloseAllPanels();
        registrationAdminPanel.OpenPanel();
    }

    public void OpenRegistrationStudentPanel()
    {
        CloseAllPanels();
        registrationStudentPanel.OpenPanel();
    }
}