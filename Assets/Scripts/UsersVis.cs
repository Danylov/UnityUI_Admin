using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.UIElements;

public class UsersVis : MonoBehaviour
{
    private Register register;
    private GameObject botPanelULR;
    public GameObject studentPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        register = GameObject.Find("Registration").GetComponent<Register>();
        SpawnStudents();
    }

    public void SpawnStudents()
    {
        botPanelULR = GameObject.Find("BotPanelULR");
        var query = string.Empty;
        try 
        { 
            MySqlConnection con = new MySqlConnection(register.connect); 
            if (con.State.ToString()!="Open")  con.Open(); 
            query = "SELECT fullname, organiztype, position, persnumber, login, password FROM students;";
            using (con)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var i = 0;
                            SpawnStudent(i, reader);
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

    private void SpawnStudent(int i, MySqlDataReader reader)
    {
        Debug.Log(String.Format("{0}, {1}, {2}, {3}, {4}, {5}", 
            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5])); // Отладка
        var spawnLocation = new Vector3(0, 2*i, 0);
        var studentInfo = Instantiate(studentPrefab, spawnLocation, Quaternion.identity);
        studentInfo.transform.SetParent(botPanelULR.transform, false);
        var stInfoBlock = studentInfo.GetComponent<UserStudentBlock>();
        stInfoBlock.NameText.text = reader[0].ToString();
        stInfoBlock.OrgTypeText.text = reader[1].ToString();
        stInfoBlock.JobText.text = reader[2].ToString();
        stInfoBlock.TabNumText.text = reader[3].ToString();
        stInfoBlock.LoginText.text = reader[4].ToString();
    }
        
    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

}