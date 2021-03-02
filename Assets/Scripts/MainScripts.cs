using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class MainScripts : MonoBehaviour
{
    private Authorization authorization;
    private Register register;
    private UsersVis usersVis;
    private CreateTask createTask;
    
    public string connect = "Server=localhost;Database=uiadmin;User ID=mysql;Password=mysql;Pooling=true;CharSet=utf8;"; 

    public string PasswEncryption(string notEncrPassw)
    {
        MD5 md5 = new MD5CryptoServiceProvider();  
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(notEncrPassw));  
        byte[] result = md5.Hash;  
        StringBuilder strBuilder = new StringBuilder();  
        for (int i = 0; i < result.Length; i++)  strBuilder.Append(result[i].ToString("x2"));  
        return strBuilder.ToString();          
    }

    public void StartMainScript()
    {
        authorization = GameObject.Find("Authorization").GetComponent<Authorization>();
        register = GameObject.Find("Registration").GetComponent<Register>();
        usersVis = GameObject.Find("UsersList").GetComponent<UsersVis>();
        createTask = GameObject.Find("CreateTask").GetComponent<CreateTask>();
    }

    private void HideAllPanels()
    {
        authorization.HidePanel();
        register.HidePanel();
        usersVis.HidePanel();
        createTask.HidePanel();
    }

    public void ShowAuthorizationPanel()
    {
        HideAllPanels();
        authorization.ShowPanel();

    }

    public void ShowRegistrationPanel()
    {
        HideAllPanels();
        register.ShowPanel();
    }

    public void ShowUsersListPanel()
    {
        HideAllPanels();
        usersVis.ShowPanel();
    }

    public void ShowCreateTaskPanel()
    {
        HideAllPanels();
        createTask.ShowPanel();
    }
}
