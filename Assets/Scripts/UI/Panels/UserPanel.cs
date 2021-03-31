﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

public class UserPanel : MonoBehaviour
{
    // [SerializeField] private Transform contentTransform;
    // [SerializeField] private GameObject userBlockTeacherPrefab;
    // [SerializeField] private GameObject userBlockStudentPrefab;
    private List<LabBlock> trackedBlocks = new List<LabBlock>();

    private ToggleAllButtons toggleAllButtons;
    [SerializeField] private GameObject SLListContent;
    [SerializeField] Button SLTickButton;
    [SerializeField] TMP_InputField SLFindName;
    [SerializeField] GameObject studentPrefab;
    
    public void SpawnStudents()
    {
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
        var studentsDB = new StudentsDB();
        var reader = studentsDB.getAllStudents();
        var i = 0;
        while (reader.Read())
        {
            SpawnStudent(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), 
                reader[6].ToString(), Convert.ToInt32(reader[8]));
            i++;
        }
        studentsDB.close();
        toggleAllButtons.AnalizeChecks();
    }

    private void SpawnStudent(int i, int id, string name, string family, string mdlName, string studGroup, string login, string password, int choosed)
    {
        var spawnLocation = new Vector3(0, 2*i, 0);
            var studentInfo = Instantiate(studentPrefab, spawnLocation, Quaternion.identity);
            studentInfo.transform.SetParent(SLListContent.transform, false);
            var userBlockStudent = studentInfo.GetComponent<UserBlockStudent>();
            userBlockStudent.NameText.text = family + " " + name + " " + mdlName;
            userBlockStudent.GroupText.text = studGroup;
            userBlockStudent.LoginText.text = login;
            userBlockStudent.PasswText.text = password;
            userBlockStudent.ToggleButtonUser.studentDbId = id;
            userBlockStudent.UnloadButton.studentDbId = id;
            if (choosed == 1) userBlockStudent.ToggleButtonUser.SetOn();
    }
        
    public void OpenPanel()
    {
        toggleAllButtons = SLTickButton.GetComponent<ToggleAllButtons>();
        toggleAllButtons.ToggleAllButtonsStart();
        SLFindName.onValueChanged.AddListener(currInput => SLFindNameChanged(currInput));
        SpawnStudents();
        gameObject.SetActive(true);
        }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    private void SLFindNameChanged(string currInput)
    {
        foreach(Transform child in SLListContent.transform)    Destroy(child.gameObject);
        var studentsDB = new StudentsDB();
        var reader = studentsDB.findStudentsLike(currInput);
        var i = 0;
        while (reader.Read())
        {
            SpawnStudent(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), 
                reader[6].ToString(), Convert.ToInt32(reader[8]));
            i++;
        };
        studentsDB.close();
    }

    public void ShowRegistrationStudentPanel()
    {
        MenuUIManager.Instance.AuthPanel.OpenRegistrationStudentPanel();
    }   
    private void ShowCaseMethod()
    {
        // fetch data from database
        
        // do it for each fetched student
        
        /*
        GameObject studentBlockGo = Instantiate(studentBlockPrefab, contentTransform);
        var studentBlock = studentBlockGo.GetComponent<LeftPanelStudentBlock>();

        studentBlock.SetData(-класс-модель-);
        */
    }
    
}
