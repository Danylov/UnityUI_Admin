using System;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
public class RegistrationStudentPanel : MonoBehaviour
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
            AddStudentToDB();
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

    void AddStudentToDB() 
    { 
        var studentsDB = new StudentsDB();
        studentsDB.addStudent(new Student(Fullname, OrganizType, Position, Int32.Parse(PersNumber), Login, Passw));
        studentsDB.close();
        // MenuUIManager.Instance.OpenMainPanel();
        MenuUIManager.Instance.OpenUserPanel();
    }
}
