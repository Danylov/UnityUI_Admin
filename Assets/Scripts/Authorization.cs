using System.IO;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    private MainScripts mainScripts;
    public TMP_InputField login;
    public TMP_InputField passw;
    public Button enterButton;
    public Button toRegistration;
    
    // Start is called before the first frame update
    void Start()
    {
        mainScripts = GameObject.Find("MainPanel").GetComponent<MainScripts>();
        mainScripts.StartMainScript();
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
        try 
        { 
            MySqlConnection con = new MySqlConnection(mainScripts.connect); 
            if (con.State.ToString()!="Open")  con.Open();
            var enteredLogin = login.text;
            var query = "SELECT password FROM students WHERE login = '" + enteredLogin + "'";
            using (con)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if (reader[0].ToString() == mainScripts.PasswEncryption(passw.text))  mainScripts.ShowStudentsListPanel();
                        else Debug.Log("Введенные логин и пароль не соответствуют друг другу");
                    }}
            }
            con.Close(); 
            con.Dispose();
        }
        catch (IOException ex) 
        { 
            Debug.Log(ex.ToString()); 
        }
 
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