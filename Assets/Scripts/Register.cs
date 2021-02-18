using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public GameObject fullname;
    public GameObject organizType;
    public GameObject position;
    public GameObject persNumber;
    public GameObject login;
    public GameObject passw;
    public GameObject confPassw;
    public Button regButton;

    private string Fullname;
    private string OrganizType;
    private string Position;
    private string PersNumber;
    private string Login;
    private string Passw;
    private string ConfPassw;

    private string form;
    private bool EmailValid = false;
    
    // Start is called before the first frame update
    void Start()
    {
        regButton.onClick.AddListener(RegisterButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (fullname.GetComponent<InputField>().isFocused)  organizType.GetComponent<InputField>().Select();
            if (organizType.GetComponent<InputField>().isFocused)  position.GetComponent<InputField>().Select();
            if (position.GetComponent<InputField>().isFocused)  persNumber.GetComponent<InputField>().Select();
            if (persNumber.GetComponent<InputField>().isFocused)  login.GetComponent<InputField>().Select();
            if (login.GetComponent<InputField>().isFocused)  passw.GetComponent<InputField>().Select();
            if (passw.GetComponent<InputField>().isFocused)  confPassw.GetComponent<InputField>().Select();
            if (confPassw.GetComponent<InputField>().isFocused)  fullname.GetComponent<InputField>().Select();
        }
        
        Fullname = fullname.GetComponent<InputField>().text;
        OrganizType = organizType.GetComponent<InputField>().text;
        Position = position.GetComponent<InputField>().text;
        PersNumber = persNumber.GetComponent<InputField>().text;
        Login = login.GetComponent<InputField>().text;
        Passw = passw.GetComponent<InputField>().text;
        ConfPassw = confPassw.GetComponent<InputField>().text;

        if (Input.GetKeyDown(KeyCode.Return))  RegisterButton();
    }

    public void RegisterButton()
    {
        if ((Fullname != "") && (Login != "") && (Passw != "") && (Passw == ConfPassw)) Debug.Log("Registration successfull");
        else Debug.Log("Fill required field");
    }
}
