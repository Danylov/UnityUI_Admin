using System;
using TMPro;
using UI;
using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

public class StudentsPanel : MonoBehaviour
{
    private ToggleAllButtons toggleAllButtons;
    [SerializeField] private GameObject SLListContentL;
    [SerializeField] private GameObject SLListContent;
    [SerializeField] Button SLTickButton;
    [SerializeField] TMP_InputField SLFindName;
    [SerializeField] TMP_InputField SLFindNameL;
    [SerializeField] GameObject studentPrefabL;
    [SerializeField] GameObject studentPrefab;
    // public Button studentsPanelClose;
    
    public void SpawnStudents()
    {
        foreach(Transform child in SLListContentL.transform)   Destroy(child.gameObject);
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
        var studentsDB = new StudentsDB();
        var reader = studentsDB.getAllStudents();
        var i = 0;
        while (reader.Read())
        {
            SpawnStudent(0, i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[8]));
            SpawnStudent(1, i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[8]));
            i++;
        }
        studentsDB.close();
        toggleAllButtons.AnalizeChecks();
    }

    private void SpawnStudent(int NumPanel, int i, int id, string fullName, string organizType, string position, string persNumber, string login, int choosed)
    {
        var spawnLocation = new Vector3(0, 2*i, 0);
        if (NumPanel == 0) {
            var studentInfoL = Instantiate(studentPrefabL, spawnLocation, Quaternion.identity);
            studentInfoL.transform.SetParent(SLListContentL.transform, false);
            var studentBlock = studentInfoL.GetComponent<StudentBlock>();
            studentBlock.NameText.text = fullName;
            studentBlock.TaskText.text = "Нет задач";
        }
        if (NumPanel == 1)
        {
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
            if (choosed == 1) userStudentBlock.ToggleButton.SetOn();
        }
    }
        
    public void OpenPanel()
    {
        toggleAllButtons = SLTickButton.GetComponent<ToggleAllButtons>();
        toggleAllButtons.ToggleAllButtonsStart();
        SLFindNameL.onValueChanged.AddListener(currInput => SLFindNameChanged(currInput, 0));
        SLFindName.onValueChanged.AddListener(currInput => SLFindNameChanged(currInput, 1));
        MenuUIManager.Instance.StudentsPanel.SpawnStudents();
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    private void SLFindNameChanged(string currInput, int NumPanel)
    {
        switch (NumPanel)
        {
            case 0: foreach(Transform child in SLListContentL.transform)   Destroy(child.gameObject); break;
            case 1: foreach(Transform child in SLListContent.transform)    Destroy(child.gameObject); break;
            default: foreach(Transform child in SLListContentL.transform)   Destroy(child.gameObject); 
                foreach(Transform child in SLListContent.transform)    Destroy(child.gameObject); 
                break;
        }
        var studentsDB = new StudentsDB();
        var reader = studentsDB.findStudentsLike(currInput);
        var i = 0;
        while (reader.Read())
        {
            SpawnStudent(NumPanel, i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[8]));
            i++;
        };
        studentsDB.close();
    }

    public void ShowRegistrationStudentPanel()
    {
        MenuUIManager.Instance.AuthPanel.OpenRegistrationStudentPanel();
    }
    
    private void studentsPanelCloseM()
    {
        
    }
}