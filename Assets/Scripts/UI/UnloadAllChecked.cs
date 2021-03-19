using System;
using UnityEngine;
using UnityEngine.UI;

public class UnloadAllChecked : MonoBehaviour
{
    [SerializeField] private Button button;
    private UnloadButton unloadButton;
    
    void Start()
    {
        button.onClick.AddListener(UnloadAllCheckedClick);   
    }
    private void UnloadAllCheckedClick()
    {
        var studentsDB = new StudentsDB();
        var reader = studentsDB.getChoosedStudents();
        while (reader.Read())
        {
            UnloadButton.UnloadButtonClick(Convert.ToInt32(reader[0]));
        }
        studentsDB.close();
    }
}
