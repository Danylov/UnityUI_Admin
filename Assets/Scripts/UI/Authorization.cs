using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    [SerializeField] Register register;
    [SerializeField] RectTransform createTask;
    public Button toRegistration;

    // Start is called before the first frame update
    private void Start()
    {
        toRegistration.onClick.AddListener(ToRegistration);
        register.HidePanel();
        createTask.gameObject.SetActive(false);
    }

    private void ToRegistration()
    {
        register.ShowPanel();
        HidePanel();
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}