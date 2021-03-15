using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthPanel : MonoBehaviour
{
    [SerializeField] private AuthorizationPanel authoriaztionPanel;
    [SerializeField] private RegistrationAdminPanel registrationAdminPanel;
    [SerializeField] private RegistrationStudentPanel registrationStudentPanel;

    void Start()
    {
        registrationAdminPanel.StartRegistrationAdminPanel();
        registrationStudentPanel.StartRegistrationStudentPanel();
    }

    public void CloseAllPanels()
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