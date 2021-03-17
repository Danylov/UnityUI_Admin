using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using TMPro;
using Button = UnityEngine.UI.Button;

public class RegistrationAdminPanel : MonoBehaviour
{
    [SerializeField] TMP_InputField fullname;
    [SerializeField] TMP_InputField organizType;
    [SerializeField] TMP_InputField position;
    [SerializeField] TMP_InputField persNumber;
    [SerializeField] TMP_InputField login;
    [SerializeField] TMP_InputField passw;
    [SerializeField] TMP_InputField confPassw;
    [SerializeField] GameObject persDataImage;
    [SerializeField] Button regButton;
    
    private PersDataCheck persDataCheck;
    
    private string Fullname;
    private string OrganizType;
    private string Position;
    private string PersNumber;
    private string Login;
    private string Passw;
    private string ConfPassw;
    private string Ipaddress;
    private DateTime Regtime;
    
    public void StartRegistrationAdminPanel()
    {
        persDataCheck = persDataImage.GetComponent<PersDataCheck>();
        persDataCheck.persDataCheckStart();
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
        Regtime = DateTime.Now;
        if ((Fullname != "") && (Login != "") && (Passw != "") && (Passw == ConfPassw) && (persDataCheck.persDataAgreed == true))
        {
            MenuUIManager.Instance.SendPopup(5, "Успешная регистрация учителя", () => AddTeacherToDB());
        }
        else Debug.Log("Заполните необходимые поля (имя, логин, пароль, подтверждение пароля), согласитесь на использование личных данных");
    }
    
    public void OpenPanel()
    {
        fullname.text = "";
        organizType.text = "";
        position.text = "";
        persNumber.text = "";
        login.text = "";
        passw.text = "";
        confPassw.text = "";
        persDataCheck.ToNotAgreed();
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    void AddTeacherToDB() 
    { 
        var teachersDB = new TeachersDB();
        teachersDB.addTeacher(new Teacher(Fullname, OrganizType, Position, Int32.Parse(PersNumber), Login, Passw, Ipaddress, Regtime, 0));
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
