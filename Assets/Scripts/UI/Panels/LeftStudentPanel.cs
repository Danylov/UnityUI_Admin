using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class LeftStudentPanel : MonoBehaviour
{
    // [SerializeField] private Transform contentTransform;
    // [SerializeField] private GameObject studentBlockPrefab;
    // private List<LeftPanelStudentBlock> trackedBlocks = new List<LeftPanelStudentBlock>();

    [SerializeField] private GameObject SLListContentL;
    [SerializeField] TMP_InputField SLFindNameL;
    [SerializeField] GameObject studentPrefabL;

    public void SpawnStudentsL()
    {
        foreach(Transform child in SLListContentL.transform)   Destroy(child.gameObject);
        var studentsDB = new StudentsDB();
        var reader = studentsDB.getAllStudents();
        var i = 0;
        while (reader.Read())
        {
            SpawnStudentL(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[8]));
            i++;
        }
        studentsDB.close();
    }

    
    private void SpawnStudentL(int i, int id, string fullName, string organizType, string position, string persNumber, string login, int choosed)
    {
        var spawnLocation = new Vector3(0, 2*i, 0);
        var studentInfoL = Instantiate(studentPrefabL, spawnLocation, Quaternion.identity);
        studentInfoL.transform.SetParent(SLListContentL.transform, false);
        var leftPanelStudentBlock = studentInfoL.GetComponent<LeftPanelStudentBlock>();
        leftPanelStudentBlock.StudentNameText.text = fullName;
        leftPanelStudentBlock.LabCodeText.text = "0";
        leftPanelStudentBlock.LabTimer.text = "00:00";
        leftPanelStudentBlock.PcNumText.text = "-";
    }

    private void SLFindNameChangedL(string currInput)
    {
foreach(Transform child in SLListContentL.transform)   Destroy(child.gameObject); 
        var studentsDB = new StudentsDB();
        var reader = studentsDB.findStudentsLike(currInput);
        var i = 0;
        while (reader.Read())
        {
            SpawnStudentL(i, Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[8]));
            i++;
        };
        studentsDB.close();
    }

    public void OpenPanel()
    {
        SLFindNameL.onValueChanged.AddListener(currInput => SLFindNameChangedL(currInput));
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
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
