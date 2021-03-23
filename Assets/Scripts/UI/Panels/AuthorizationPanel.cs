using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationPanel : MonoBehaviour
{
    [SerializeField] RegistrationAdminPanel registrationAdminPanel;
    [SerializeField] Button toRegistration;
    [SerializeField] TMP_InputField login;
    [SerializeField] TMP_InputField passw;
    [SerializeField] Button enterButton;
    
    void Start()
    {
        toRegistration.onClick.AddListener(ToRegistration);
        enterButton.onClick.AddListener(EnterButton);
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
        var teachersDB = new TeachersDB();
        var currPassword = MenuUIManager.PasswEncryption(passw.text);
        var reader = teachersDB.findTeacher(login.text);
        if (reader.HasRows)
        {
            reader.Read();
            // if (reader[0].ToString() == currPassword)  MenuUIManager.Instance.OpenTaskPanel();
            if (reader[0].ToString() == currPassword)  MenuUIManager.Instance.OpenUserPanel();
            else Debug.Log("Введенные логин и пароль не соответствуют друг другу");
        } else Debug.Log("Введенный логин не найден в БД");
    }

    void ToRegistration()
    {
        MenuUIManager.Instance.AuthPanel.OpenRegistrationAdminPanel();
    }
    
    public void OpenPanel()
    {
        login.text = "";
        passw.text = "";
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}