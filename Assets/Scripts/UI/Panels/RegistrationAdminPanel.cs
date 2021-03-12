using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using TMPro;
using Button = UnityEngine.UI.Button;

public class RegistrationAdminPanel : MonoBehaviour
{
    private PersDataCheck persDataCheck;
    
    public TMP_InputField fullname;
    public TMP_InputField organizType;
    public TMP_InputField position;
    public TMP_InputField persNumber;
    public TMP_InputField login;
    public TMP_InputField passw;
    public TMP_InputField confPassw;
    public Button regButton;
    
    private string Fullname;
    private string OrganizType;
    private string Position;
    private string PersNumber;
    private string Login;
    private string Passw;
    private string ConfPassw;
    private string Ipaddress;
    
    void Start()
    {
        persDataCheck = GameObject.Find("PersDataImage").GetComponent<PersDataCheck>();
        regButton.onClick.AddListener(RegisterButton);
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
        if (Input.GetKeyDown(KeyCode.Return))  RegisterButton();
    }
            
    private void RegisterButton()
    {
        Fullname = fullname.text;
        OrganizType = organizType.text;
        Position = position.text;
        PersNumber = persNumber.text;
        Login = login.text;
        Passw = passw.text;
        ConfPassw = confPassw.text;
        Ipaddress = GetLocalIPAddress();
        if ((Fullname != "") && (Login != "") && (Passw != "") && (Passw == ConfPassw) && (persDataCheck.persDataAgreed == true))
        {
            AddTeacherToDB();
            Debug.Log("Регистрация успешная");
        }
        else Debug.Log("Заполните необходимые поля (имя, логин, пароль, подтверждение пароля), согласитесь на использование личных данных");
    }
    
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    void AddTeacherToDB() 
    { 
        Debug.Log("Ipaddress = " + Ipaddress); // Отладка
        var teachersDB = new TeachersDB();
        teachersDB.addTeacher(new Teacher(Fullname, OrganizType, Position, Int32.Parse(PersNumber), Login, Passw, Ipaddress, 0));
        teachersDB.close();
        // MenuUIManager.Instance.OpenMainPanel();
        MenuUIManager.Instance.OpenStudentsPanel();
    }
    
    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)  return ip.ToString();
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
}
