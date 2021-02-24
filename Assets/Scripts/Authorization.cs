using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    private Register register;
    private CreateTask createTask;
    public Button toRegistration;
    
    // Start is called before the first frame update
    void Start()
    {
        toRegistration.onClick.AddListener(ToRegistration);
        register = GameObject.Find("Registration").GetComponent<Register>();
        createTask = GameObject.Find("CreateTask").GetComponent<CreateTask>();
        register.HidePanel();
        createTask.HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToRegistration()
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

