using System;
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

    [SerializeField] private ToggleAllButtons toggleAllButtons;
    [SerializeField] private UnloadAllChecked unloadAllChecked;
    [SerializeField] private GameObject SLListContent;
    [SerializeField] TMP_InputField SLFindName;
    [SerializeField] GameObject studentPrefab;
    [SerializeField] GameObject teacherPrefab;
    
    public void SpawnStudents()
    {
        SLFindName.onValueChanged.AddListener(currInput => SLFindNameChangedStudents(currInput));
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
        toggleAllButtons.PrefabType = 1;
        toggleAllButtons.AnalizeChecks();
        unloadAllChecked.IsTeacher = false;
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
            userBlockStudent.ToggleButtonUser.userDbId = id;
            userBlockStudent.ToggleButtonUser.toggleAllButtons = toggleAllButtons;
            userBlockStudent.UnloadButton.userDbId = id;
            if (choosed == 1) userBlockStudent.ToggleButtonUser.SetOn();
    }
    
    public void SpawnTeachers()
    {
        SLFindName.onValueChanged.AddListener(currInput => SLFindNameChangedTeachers(currInput));
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
        var teachersDB = new TeachersDB();
        var reader = teachersDB.getAllTeachers();
        var i = 0;
        while (reader.Read())
        {
            SpawnTeacher(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), 
                Convert.ToInt32(reader[9]));
            i++;
        }
        teachersDB.close();
        toggleAllButtons.PrefabType = 0;
        toggleAllButtons.AnalizeChecks();
        unloadAllChecked.IsTeacher = true;
    }

    private void SpawnTeacher(int i, int id, string name, string family, string mdlName, string position, string login, int choosed)
    {
        var spawnLocation = new Vector3(0, 2*i, 0);
        var teacherInfo = Instantiate(teacherPrefab, spawnLocation, Quaternion.identity);
        teacherInfo.transform.SetParent(SLListContent.transform, false);
        var userBlockTeacher = teacherInfo.GetComponent<UserBlockTeacher>();
        userBlockTeacher.NameText.text = family + " " + name + " " + mdlName;
        userBlockTeacher.JobText.text = position;
        userBlockTeacher.LoginText.text = login;
        userBlockTeacher.ToggleButtonUser.userDbId = id;
        userBlockTeacher.ToggleButtonUser.toggleAllButtons = toggleAllButtons;
        userBlockTeacher.UnloadButton.userDbId = id;
        if (choosed == 1) userBlockTeacher.ToggleButtonUser.SetOn();
    }
    public void OpenPanel()
    {
        toggleAllButtons.SLListContent = SLListContent;
        toggleAllButtons.ToggleAllButtonsStart();
        SLFindName.onValueChanged.AddListener(currInput => SLFindNameChangedStudents(currInput));
        SpawnStudents();
        gameObject.SetActive(true);
        }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    private void SLFindNameChangedStudents(string currInput)
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

    private void SLFindNameChangedTeachers(string currInput)
    {
        foreach(Transform child in SLListContent.transform)    Destroy(child.gameObject);
        var teachersDB = new TeachersDB();
        var reader = teachersDB.findTeachersLike(currInput);
        var i = 0;
        while (reader.Read())
        {
            SpawnTeacher(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), 
                Convert.ToInt32(reader[9]));
            i++;
        };
        teachersDB.close();
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
