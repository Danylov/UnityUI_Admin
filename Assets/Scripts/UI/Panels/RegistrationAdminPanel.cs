using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using TMPro;
using Button = UnityEngine.UI.Button;

public class RegistrationAdminPanel : MonoBehaviour
{
    [SerializeField] TMP_InputField name;
    [SerializeField] TMP_InputField family;
    [SerializeField] TMP_InputField mdlName;
    [SerializeField] TMP_InputField position;
    [SerializeField] TMP_InputField login;
    [SerializeField] TMP_InputField passw;
    [SerializeField] TMP_InputField confPassw;
    [SerializeField] GameObject persDataImage;
    [SerializeField] Button regButton;
    
    private PersDataCheck persDataCheck;
    
    private string Name;
    private string Family;
    private string MdlName;
    private string Position;
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
            if (name.isFocused)  family.Select();
            if (family.isFocused)  mdlName.Select();
            if (mdlName.isFocused)  position.Select();
            if (position.isFocused)  login.Select();
            if (login.isFocused)  passw.Select();
            if (passw.isFocused)  confPassw.Select();
            if (confPassw.isFocused)  name.Select();
        }
        if (Input.GetKeyDown(KeyCode.Return))  RegisterButton();
    }
            
    private void RegisterButton()
    {
        Name = name.text;
        Family = family.text;
        MdlName = mdlName.text;
        Position = position.text;
        Login = login.text;
        Passw = passw.text;
        ConfPassw = confPassw.text;
        Ipaddress = GetLocalIPAddress();
        Regtime = DateTime.Now;
        if ((Name != "") && (Family != "") && (Login != "") && (Passw != "") && (Passw == ConfPassw) && 
            (persDataCheck.persDataAgreed == true))
        {
            MenuUIManager.Instance.SendPopup(3, "Успешная регистрация учителя", () => AddTeacherToDB());
        }
        else MenuUIManager.Instance.SendPopup(3, "Заполните необходимые поля (имя, фамилия, логин, пароль, подтверждение пароля), согласитесь на использование личных данных");
    }
    
    public void OpenPanel()
    {
        name.text = "";
        family.text = "";
        mdlName.text = "";
        position.text = "";
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
        teachersDB.addTeacher(new Teacher(Name, Family, MdlName, Position, Login, Passw, Ipaddress, Regtime, 0));
        teachersDB.close();
        // MenuUIManager.Instance.OpenMainPanel();
        MenuUIManager.Instance.OpenUserPanel();
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
