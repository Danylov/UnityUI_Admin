using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorizationPanel : MonoBehaviour
{
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void LogIn()
    {
        MenuUIManager.Instance.OpenMainPanel();
    }

    public void Registration()
    {
        MenuUIManager.Instance.AuthPanel.OpenRegistrationAdminPanel();
    }
}
