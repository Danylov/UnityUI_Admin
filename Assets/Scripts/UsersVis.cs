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
    public GameObject studentPrefab;
    // Start is called before the first frame update
    void Start()
    {
        register = GameObject.Find("Registration").GetComponent<Register>();
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
        var spawnLocation = new Vector3(30, 15*i, 0);
        Instantiate(studentPrefab, spawnLocation, studentPrefab.transform.rotation);
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