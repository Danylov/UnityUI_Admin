using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationPanel : MonoBehaviour
{
    [SerializeField] RegistrationAdminPanel registrationAdminPanel;
    public Button toRegistration;

    // Start is called before the first frame update
    private void Start()
    {
        toRegistration.onClick.AddListener(ToRegistration);
        registrationAdminPanel.ClosePanel();
    }

    private void ToRegistration()
    {
        registrationAdminPanel.OpenPanel();
        ClosePanel();
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
