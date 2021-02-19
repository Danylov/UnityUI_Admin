using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Toggle = UnityEngine.UI.Toggle;

public class Register : MonoBehaviour
{
    private PersDataCheck persDataCheck;
    
    public GameObject fullname;
    public GameObject organizType;
    public GameObject position;
    public GameObject persNumber;
    public GameObject login;
    public GameObject passw;
    public GameObject confPassw;
    public GameObject PersData;
    public Button regButton;
    
    private Toggle persDataToggle;
    private string Fullname;
    private string OrganizType;
    private string Position;
    private string PersNumber;
    private string Login;
    private string Passw;
    private string ConfPassw;

    private string form;
    // private bool EmailValid = false;
    
    void Start()
    {
        persDataCheck = GameObject.Find("PersDataImage").GetComponent<PersDataCheck>();
        regButton.onClick.AddListener(RegisterButton);
        persDataToggle = PersData.GetComponent<Toggle>();
        persDataToggle.onValueChanged.AddListener((x) => Invoke("toggleChanged", 0f));
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
            
    private void RegisterButton()
    {
        if ((Fullname != "") && (Login != "") && (Passw != "") && (Passw == ConfPassw)) Debug.Log("Registration successfull");
        else Debug.Log("Fill required field");
    }
            
    private void toggleChanged()
    {
        persDataCheck.changeSprite();
    }
}