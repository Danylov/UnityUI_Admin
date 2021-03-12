using System;
using System.IO;
using MySql.Data.MySqlClient;
using TMPro;
using UI;
using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

public class StudentsPanel : MonoBehaviour
{
    [SerializeField] private GameObject SLListContent;
    [SerializeField] Button SLTickButton;
    private ToggleAllButtons toggleAllButtons;
    public TMP_InputField SLFindName;
    public GameObject studentPrefab;
    // public Button studentsPanelClose;
    
   public void SpawnStudents()
    {
        Debug.Log("In StudentsPanel.OpenPanel():2"); // Отладка
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
        Debug.Log("In StudentsPanel.OpenPanel():3"); // Отладка
        var studentsDB = new StudentsDB();
        var reader = studentsDB.getAllStudents();
        var i = 0;
        while (reader.Read())
        {
            SpawnStudent(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[7]));
            i++;
        }
        studentsDB.close();
        Debug.Log("In StudentsPanel.OpenPanel():4"); // Отладка
        toggleAllButtons.AnalizeChecks();
        Debug.Log("In StudentsPanel.OpenPanel():5"); // Отладка
    }

    private void SpawnStudent(int i, int id, string fullName, string organizType, string position, string persNumber, string login, int choosed)
    {
        var spawnLocation = new Vector3(0, 2*i, 0);
        var studentInfo = Instantiate(studentPrefab, spawnLocation, Quaternion.identity);
        studentInfo.transform.SetParent(SLListContent.transform, false);
        var userStudentBlock = studentInfo.GetComponent<UserStudentBlock>();
        userStudentBlock.NameText.text = fullName;
        userStudentBlock.OrgTypeText.text = organizType;
        userStudentBlock.JobText.text = position;
        userStudentBlock.TabNumText.text = persNumber;
        userStudentBlock.LoginText.text = login;
        userStudentBlock.ToggleButton.studentDbId = id;
        userStudentBlock.UnloadButton.studentDbId = id;
        userStudentBlock.UnloadButton.userStudentBlock = userStudentBlock;
        if (choosed == 1) userStudentBlock.ToggleButton.SetOn();
    }
        
    public void OpenPanel()
    {
        toggleAllButtons = SLTickButton.GetComponent<ToggleAllButtons>();
        toggleAllButtons.ToggleAllButtonsStart();
        SLFindName.onValueChanged.AddListener(SLFindNameChanged);
        Debug.Log("In StudentsPanel.OpenPanel():1"); // Отладка
        MenuUIManager.Instance.StudentsPanel.SpawnStudents();
        Debug.Log("In StudentsPanel.OpenPanel():6"); // Отладка
        gameObject.SetActive(true);
        Debug.Log("In StudentsPanel.OpenPanel():7"); // Отладка
    }

    public void ClosePanel()
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
            SpawnStudent(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[7]));
            i++;
        };
        studentsDB.close();
    }
    
    private void studentsPanelCloseM()
    {
        
    }
}