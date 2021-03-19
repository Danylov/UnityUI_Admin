using System;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
public class RegistrationStudentPanel : MonoBehaviour
{
    [SerializeField] TMP_InputField name;
    [SerializeField] TMP_InputField family;
    [SerializeField] TMP_InputField mdlName;
    [SerializeField] TMP_InputField studGroup;
    [SerializeField] TMP_InputField login;
    [SerializeField] TMP_InputField passw;
    [SerializeField] TMP_InputField confPassw;
    [SerializeField] GameObject persDataImage;
    [SerializeField] Button regButton;
    
    private PersDataCheck persDataCheck;
    
    private string Name;
    private string Family;
    private string MdlName;
    private string StudGroup;
    private string Login;
    private string Passw;
    private string ConfPassw;
    private string Ipaddress;
    
    public void StartRegistrationStudentPanel()
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
            if (mdlName.isFocused)  studGroup.Select();
            if (studGroup.isFocused)  login.Select();
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
        StudGroup = studGroup.text;
        Login = login.text;
        Passw = passw.text;
        ConfPassw = confPassw.text;
        Ipaddress = RegistrationAdminPanel.GetLocalIPAddress();
        if ((Name != "") && (Family != "") && (Login != "") && (Passw != "") && (Passw == ConfPassw) && 
            (persDataCheck.persDataAgreed == true))
        {
            MenuUIManager.Instance.SendPopup(3, "Успешная регистрация студента", () => AddStudentToDB());
        }
        else MenuUIManager.Instance.SendPopup(3, "Заполните необходимые поля (имя, фамилия, логин, пароль, подтверждение пароля), согласитесь на использование личных данных");
    }
    
    public void OpenPanel()
    {
        name.text = "";
        family.text = "";
        mdlName.text = "";
        studGroup.text = "";
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

    void AddStudentToDB() 
    { 
        var studentsDB = new StudentsDB();
        studentsDB.addStudent(new Student(Name, Family, MdlName, StudGroup, Login, Passw, Ipaddress, 0));
        studentsDB.close();
        // MenuUIManager.Instance.OpenMainPanel();
        MenuUIManager.Instance.OpenUserPanel();
    }
}
