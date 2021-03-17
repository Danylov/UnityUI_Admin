using System.Collections;
using System.Collections.Generic;
using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

public class UnloadButton : MonoBehaviour
{
    public int studentDbId;
    [SerializeField] private UserStudentBlock userStudentBlock; 
    [SerializeField] private Button button;
    private GameObject StudentsPanel;
    StudentsPanel studentsPanel;
    private 
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(UnloadButtonClick);  
        StudentsPanel = GameObject.Find("StudentsPanel");
        studentsPanel = StudentsPanel.GetComponent<StudentsPanel>();
    }
    private void UnloadButtonClick()
    {
        var studentsDB = new StudentsDB();
        studentsDB.deleteStudentById(studentDbId);
        studentsDB.close();
        studentsPanel.SpawnStudents();
    }
}
