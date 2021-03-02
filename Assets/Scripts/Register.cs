﻿using System.IO;
using TMPro;
using UnityEngine;
using MySql.Data.MySqlClient;
using Button = UnityEngine.UI.Button;
using Toggle = UnityEngine.UI.Toggle;

public class Register : MonoBehaviour
{
    private MainScripts mainScripts;
    private PersDataCheck persDataCheck;
    private StudentsVis studentsVis;
    
    public TMP_InputField fullname;
    public TMP_InputField organizType;
    public TMP_InputField position;
    public TMP_InputField persNumber;
    public TMP_InputField login;
    public TMP_InputField passw;
    public TMP_InputField confPassw;
    public Toggle PersData;
    public Button regButton;
    
    private string Fullname;
    private string OrganizType;
    private string Position;
    private string PersNumber;
    private string Login;
    private string Passw;
    private string ConfPassw;
    
    void Start()
    {
        mainScripts = GameObject.Find("MainPanel").GetComponent<MainScripts>();
        persDataCheck = GameObject.Find("PersDataImage").GetComponent<PersDataCheck>();
        regButton.onClick.AddListener(RegisterButton);
        PersData.onValueChanged.AddListener((x) => Invoke("toggleChanged", 0f));
        studentsVis = GameObject.Find("StudentsList").GetComponent<StudentsVis>();
        }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (fullname.isFocused)  organizType.Select();
            if (organizType.isFocused)  position.Select();
            if (position.isFocused)  persNumber.Select();
            if (persNumber.isFocused)  login.Select();
            if (login.isFocused)  passw.Select();
            if (passw.isFocused)  confPassw.Select();
            if (confPassw.isFocused)  fullname.Select();
        }
                    
        Fullname = fullname.text;
        OrganizType = organizType.text;
        Position = position.text;
        PersNumber = persNumber.text;
        Login = login.text;
        Passw = passw.text;
        ConfPassw = confPassw.text;
            
        if (Input.GetKeyDown(KeyCode.Return))  RegisterButton();
    }
            
    private void RegisterButton()
    {
        if ((Fullname != "") && (Login != "") && (Passw != "") && (Passw == ConfPassw) && (persDataCheck.persDataAgreed == true))
        {
            InsertEntries();
            studentsVis.SpawnStudents();
            Debug.Log("Регистрация успешная");
        }
        else Debug.Log("Заполните необходимые поля (имя, логин, пароль, подтверждение пароля), согласитесь на использование личных данных");
    }
            
    private void toggleChanged()
    {
        persDataCheck.changeSprite();
    }
    
    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    void InsertEntries() 
    { 
        var query = string.Empty; 
        try 
        { 
            MySqlConnection con = new MySqlConnection(mainScripts.connect); 
            if (con.State.ToString()!="Open")  con.Open(); 
            query = "INSERT INTO students (fullname, organiztype, position, persnumber, login, password) VALUES (?fullname, ?organiztype, ?position, ?persnumber, ?login, ?password)";
            using (con) 
            {
                    using (MySqlCommand cmd = new MySqlCommand(query, con)) 
                    { 
                        MySqlParameter oParam1 = cmd.Parameters.Add("?fullname", MySqlDbType.VarChar); 
                        oParam1.Value = Fullname; 
                        MySqlParameter oParam2 = cmd.Parameters.Add("?organiztype", MySqlDbType.VarChar); 
                        oParam2.Value = OrganizType; 
                        MySqlParameter oParam3 = cmd.Parameters.Add("?position", MySqlDbType.VarChar); 
                        oParam3.Value = Position; 
                        MySqlParameter oParam4 = cmd.Parameters.Add("?persnumber", MySqlDbType.Int32); 
                        oParam4.Value = PersNumber; 
                        MySqlParameter oParam5 = cmd.Parameters.Add("?login", MySqlDbType.VarChar); 
                        oParam5.Value = Login; 
                        MySqlParameter oParam6 = cmd.Parameters.Add("?password", MySqlDbType.VarChar); 
                        oParam6.Value = mainScripts.PasswEncryption(Passw); 
                        cmd.ExecuteNonQuery(); 
                    }
            }
            con.Close(); 
            con.Dispose();
            mainScripts.ShowStudentsListPanel();
        }
        catch (IOException ex) 
        { 
            Debug.Log(ex.ToString()); 
        }
    }
}