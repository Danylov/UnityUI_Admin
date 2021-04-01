using System;
using TMPro;
using UI;
using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

public class StatsStudentsPanel : MonoBehaviour
{
    [SerializeField] private ToggleAllButtons toggleAllButtons;
    [SerializeField] private UnloadAllChecked unloadAllChecked;
    [SerializeField] private GameObject SLListContent;
    [SerializeField] TMP_InputField SLFindName;
    [SerializeField] GameObject studentStatPrefab;

    public void SpawnStudentsS()
    {
        SLFindName.onValueChanged.AddListener(currInput => SLFindNameChangedStudentsS(currInput));
        foreach(Transform child in SLListContent.transform)   Destroy(child.gameObject);
        var studentsDB = new StudentsDB();
        var reader = studentsDB.getAllStudents();
        var i = 0;
        while (reader.Read())
        {
            SpawnStudentS(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), 
                reader[6].ToString(), Convert.ToInt32(reader[8]));
            i++;
        }
        studentsDB.close();
        toggleAllButtons.PrefabType = 2;
        unloadAllChecked.IsTeacher = false;
        toggleAllButtons.AnalizeChecks();
    }

    private void SpawnStudentS(int i, int id, string name, string family, string mdlName, string studGroup, string login, string password, int choosed)
    {
        var spawnLocation = new Vector3(0, 2*i, 0);
        var studentInfo = Instantiate(studentStatPrefab, spawnLocation, Quaternion.identity);
        studentInfo.transform.SetParent(SLListContent.transform, false);
        var statsStudentBlock = studentInfo.GetComponent<StatsStudentBlock>();
        statsStudentBlock.NameText.text = family + " " + name + " " + mdlName;
        statsStudentBlock.GroupText.text = studGroup;
        statsStudentBlock.ToggleButtonUser.userDbId = id;
        statsStudentBlock.ToggleButtonUser.toggleAllButtons = toggleAllButtons;
        statsStudentBlock.UnloadButton.userDbId = id;
        if (choosed == 1) statsStudentBlock.ToggleButtonUser.SetOn();
    }

    private void SLFindNameChangedStudentsS(string currInput)
    {
        foreach(Transform child in SLListContent.transform)    Destroy(child.gameObject);
        var studentsDB = new StudentsDB();
        var reader = studentsDB.findStudentsLike(currInput);
        var i = 0;
        while (reader.Read())
        {
            SpawnStudentS(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), 
                reader[6].ToString(), Convert.ToInt32(reader[8]));
            i++;
        };
        studentsDB.close();
    }

    public void OpenPanel()
    {
        toggleAllButtons.SLListContent = SLListContent;
        toggleAllButtons.ToggleAllButtonsStart();
        SLFindName.onValueChanged.AddListener(currInput => SLFindNameChangedStudentsS(currInput));
        SpawnStudentsS();
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

}
