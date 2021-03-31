using System;
using UnityEngine;
using UnityEngine.UI;

public class UnloadAllChecked : MonoBehaviour
{
    [SerializeField] private Button button;
    private UnloadButton unloadButton;
    private bool isTeacher;
    
    public bool IsTeacher
    {
        get => isTeacher;
        set => isTeacher = value;
    }
    
    void Start()
    {
        button.onClick.AddListener(UnloadAllCheckedClick);   
    }
    private void UnloadAllCheckedClick()
    {
        if (isTeacher)
        {
            var  teachersDB = new TeachersDB();
            var reader =  teachersDB.getChoosedTeachers();
            while (reader.Read())  UnloadButton.UnloadButtonTeacherClick(Convert.ToInt32(reader[0]));
            teachersDB.close();
        } else {
            var studentsDB = new StudentsDB();
            var reader = studentsDB.getChoosedStudents();
            while (reader.Read())  UnloadButton.UnloadButtonStudentClick(Convert.ToInt32(reader[0]));
            studentsDB.close();
        }
    }
}