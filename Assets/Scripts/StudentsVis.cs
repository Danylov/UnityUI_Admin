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
        var studentsDB = new StudentsDB();
        var reader = studentsDB.getAllStudents();
        var i = 0;
        while (reader.Read())
        {
            SpawnStudent(i, reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), 
                reader[4].ToString(), reader[5].ToString());
            i++;
        }
        studentsDB.close();
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
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
        var studentsDB = new StudentsDB();
        var reader = studentsDB.findStudentsLike(currInput);
        var i = 0;
        while (reader.Read())
        {
            SpawnStudent(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString());
            i++;
        };
        studentsDB.close();
    }
    
    private void studentsVisCloseM()
    {
        
    }
}