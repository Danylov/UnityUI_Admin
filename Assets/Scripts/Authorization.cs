using System;
using System.IO;
using MySql.Data.MySqlClient;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    private MainScripts mainScripts;
    private GameObject SLTickButton;
    private ToggleAllButtons toggleAllButtons;
    public TMP_InputField login;
    public TMP_InputField passw;
    public Button enterButton;
    public Button toRegistration;
    
    // Start is called before the first frame update
    void Start()
    {
        mainScripts = GameObject.Find("MainPanel").GetComponent<MainScripts>();
        mainScripts.StartMainScript();
        SLTickButton = GameObject.Find("SLTickButton");
        toggleAllButtons = SLTickButton.GetComponent<ToggleAllButtons>();
        toggleAllButtons.ToggleAllButtonsStart();
        toRegistration.onClick.AddListener(ToRegistration);
        enterButton.onClick.AddListener(EnterButton);
        mainScripts.ShowAuthorizationPanel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (login.isFocused)  passw.Select();
            if (passw.isFocused)  login.Select();
        }
    }

    void EnterButton()
    {
        var studentsDB = new StudentsDB();
        var currPassword = MainScripts.PasswEncryption(passw.text);
        var reader = studentsDB.findStudent(login.text);
        if (reader.HasRows)
        {
            reader.Read();
            if (reader[0].ToString() == currPassword)  mainScripts.ShowStudentsListPanel();
            else Debug.Log("Введенные логин и пароль не соответствуют друг другу");
        } else Debug.Log("Введенный логин не найден в БД");
    }

    void ToRegistration()
    {
        mainScripts.ShowRegistrationPanel();
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