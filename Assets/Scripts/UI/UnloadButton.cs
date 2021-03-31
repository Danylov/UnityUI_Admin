using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UnloadButton : MonoBehaviour
{
    public int userDbId;
    [SerializeField] private bool isTeacher;
    [SerializeField] private Button button;
    private GameObject StudentsPanel;
    
        void Start()
    {
        if (isTeacher) button.onClick.AddListener(() => UnloadButtonTeacherClick(userDbId));  
        else button.onClick.AddListener(() => UnloadButtonStudentClick(userDbId));
    }
    public static void UnloadButtonStudentClick(int studentDbId)
    {
        var studentsDB = new StudentsDB();
        var csv = new StringBuilder();
        var reader = studentsDB.findStudentById(studentDbId);
        reader.Read();
        var id = Convert.ToInt32(reader[0]);
        var name = reader[1].ToString();
        var family = reader[2].ToString();
        var mdlName = reader[3].ToString();
        var studGroup = reader[4].ToString();
        var login = reader[5].ToString();
        var password = reader[6].ToString();
        var ipaddress = reader[7].ToString();
        var choosed = Convert.ToInt32(reader[8]);
        var newCsvLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", id, name, family, mdlName, studGroup, login, password, ipaddress, choosed);
        csv.AppendLine(newCsvLine);
        var csvFilePath = "c:\\" + login + "_student.csv";
        File.WriteAllText(csvFilePath, csv.ToString());
        reader.Close();
        studentsDB.close();
    }
    
    public static void UnloadButtonTeacherClick(int teacherDbId)
    {
        var teachersDB = new TeachersDB();
        var csv = new StringBuilder();
        var reader = teachersDB.findTeacherById(teacherDbId);
        reader.Read();
        var id = Convert.ToInt32(reader[0]);
        var name = reader[1].ToString();
        var family = reader[2].ToString();
        var mdlName = reader[3].ToString();
        var position = reader[4].ToString();
        var login = reader[5].ToString();
        var password = reader[6].ToString();
        var ipaddress = reader[7].ToString();
        var regtime = Convert.ToDateTime(reader[8]);
        var choosed = Convert.ToInt32(reader[9]);
        var newCsvLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", id, name, family, mdlName, position, login, password, ipaddress, regtime, choosed);
        csv.AppendLine(newCsvLine);
        var csvFilePath = "c:\\" + login + "_teacher.csv";
        File.WriteAllText(csvFilePath, csv.ToString());
        reader.Close();
        teachersDB.close();
    }

}