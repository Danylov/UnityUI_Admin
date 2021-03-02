using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class MainScripts : MonoBehaviour
{
    private Authorization authorization;
    private Register register;
    private StudentsVis studentsVis;
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
        studentsVis = GameObject.Find("StudentsList").GetComponent<StudentsVis>();
        createTask = GameObject.Find("CreateTask").GetComponent<CreateTask>();
    }

    private void HideAllPanels()
    {
        authorization.HidePanel();
        register.HidePanel();
        studentsVis.HidePanel();
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

    public void ShowStudentsListPanel()
    {
        HideAllPanels();
        studentsVis.ShowPanel();
    }

    public void ShowCreateTaskPanel()
    {
        HideAllPanels();
        createTask.ShowPanel();
    }
}
