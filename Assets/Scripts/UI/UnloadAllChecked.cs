using System.Collections;
using System.Collections.Generic;
using UI.Blocks;
using UnityEngine;
using UnityEngine.UI;

public class UnloadAllChecked : MonoBehaviour
{
    [SerializeField] private StudentsPanel studentsPanel;
    [SerializeField] private Button button;
    private StudentsPanel StudentsPanel => studentsPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(UnloadAllCheckedClick);   
    }
    private void UnloadAllCheckedClick()
    {
        var studentsDB = new StudentsDB();
        studentsDB.deleteCheckedStudents();
        studentsDB.close();
        studentsPanel.SpawnStudents();
    }
}
