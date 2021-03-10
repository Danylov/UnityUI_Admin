using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationAdminPanel : MonoBehaviour
{
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void Register()
    {
        MenuUIManager.Instance.OpenMainPanel();
    }
}
