using System;
using System.IO;
using MySql.Data.MySqlClient;
using TMPro;
using UI.Blocks;
using UnityEngine;

public class StudentsVis : MonoBehaviour
{
    private MainScripts mainScripts;
    private GameObject SLListContent;
    public TMP_InputField SLFindName;
    public GameObject studentPrefab;
    // public Button studentsVisClose;
    
    void Start()
    {
        // studentsVisClose.onClick.AddListener(studentsVisCloseM);
        mainScripts = GameObject.Find("MainPanel").GetComponent<MainScripts>();
        SLListContent = GameObject.Find("SLListContent");
        SLFindName.onValueChanged.AddListener(SLFindNameChanged);
        SpawnStudents();
    }

    public void SpawnStudents()
    {
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
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
        studentInfo.transform.SetParent(SLListContent.transform, false);
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

    private void SLFindNameChanged(string currInput)
    {
        Debug.Log(currInput); // Отладка
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
        try 
        { 
            MySqlConnection con = new MySqlConnection(mainScripts.connect); 
            if (con.State.ToString()!="Open")  con.Open(); 
            var query = "SELECT fullname, organiztype, position, persnumber, login, password FROM students WHERE fullname LIKE '" + currInput + 
                        "%' OR  login LIKE '" + currInput + "%'";
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
    
    private void studentsVisCloseM()
    {
        
    }
}