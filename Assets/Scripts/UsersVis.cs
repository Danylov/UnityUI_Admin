using System;
using System.IO;
using MySql.Data.MySqlClient;
using UI.Blocks;
using UnityEngine;

public class UsersVis : MonoBehaviour
{
    private MainScripts mainScripts;
    private GameObject studentPanelContent;
    public GameObject studentPrefab;
    // public Button usersVisClose;
    
    void Start()
    {
        // usersVisClose.onClick.AddListener(usersVisCloseM);
        mainScripts = GameObject.Find("MainPanel").GetComponent<MainScripts>();
        SpawnStudents();
    }

    public void SpawnStudents()
    {
        studentPanelContent = GameObject.Find("StudentPanelContent");
        foreach(Transform child in studentPanelContent.transform)   Destroy(child.gameObject);
        try 
        { 
            MySqlConnection con = new MySqlConnection(mainScripts.connect); 
            if (con.State.ToString()!="Open")  con.Open(); 
            var query = "SELECT fullname, organiztype, position, persnumber, login, password FROM students;";
            using (con)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var i = 0;
                            SpawnStudent(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                            i++;
                        }
                    }
                }
            }
            con.Close(); 
            con.Dispose();
        }
        catch (IOException ex) 
        { 
            Debug.Log(ex.ToString()); 
        }
    }

    private void SpawnStudent(int i, string fullName, string organizType, string position, string persNumber, string login)
    {
        var spawnLocation = new Vector3(0, 2*i, 0);
        var studentInfo = Instantiate(studentPrefab, spawnLocation, Quaternion.identity);
        studentInfo.transform.SetParent(studentPanelContent.transform, false);
        var stInfoBlock = studentInfo.GetComponent<UserStudentBlock>();
        stInfoBlock.NameText.text = fullName;
        stInfoBlock.OrgTypeText.text = organizType;
        stInfoBlock.JobText.text = position;
        stInfoBlock.TabNumText.text = persNumber;
        stInfoBlock.LoginText.text = login;
    }
        
    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    private void usersVisCloseM()
    {
        
    }
}