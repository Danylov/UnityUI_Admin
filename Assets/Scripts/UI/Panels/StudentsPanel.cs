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
    private GameObject SLListContent;
    [SerializeField] Button SLTickButton;
    public ToggleAllButtons toggleAllButtons;
    public TMP_InputField SLFindName;
    public GameObject studentPrefab;
    // public Button studentsPanelClose;
    
    void Start()
    {
        // studentsPanelClose.onClick.AddListener(studentsPanelCloseM);
        toggleAllButtons = SLTickButton.GetComponent<ToggleAllButtons>();
        SLListContent = GameObject.Find("SLListContent");
        SLFindName.onValueChanged.AddListener(SLFindNameChanged);
    }

    public void SpawnStudents()
    {
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
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
        toggleAllButtons.AnalizeChecks();
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
        gameObject.SetActive(true);
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