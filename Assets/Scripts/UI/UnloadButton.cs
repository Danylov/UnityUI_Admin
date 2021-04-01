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
        csv.AppendLine("");
        csv.AppendLine("Студент:");
        csv.AppendLine("");
        var newCsvLine = string.Format("Id: {0}", id);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Имя: {0}", name);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Отчество: {0}", mdlName);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Фамилия: {0}", family);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Группа: {0}", studGroup);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Логин: {0}", login);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Пароль (MD5): {0}", password);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("IP адрес: {0}", ipaddress);
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
        csv.AppendLine("");
        csv.AppendLine("Преподаватель:");
        csv.AppendLine("");
        var newCsvLine = string.Format("Id: {0}", id);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Имя: {0}", name);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Отчество: {0}", mdlName);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Фамилия: {0}", family);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Должность: {0}", position);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Логин: {0}", login);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Пароль (MD5): {0}", password);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("IP адрес: {0}", ipaddress);
        csv.AppendLine(newCsvLine);
        newCsvLine = string.Format("Дата и время регистрации: {0}", regtime);
        csv.AppendLine(newCsvLine);
        var csvFilePath = "c:\\" + login + "_teacher.csv";
        File.WriteAllText(csvFilePath, csv.ToString());
        reader.Close();
        teachersDB.close();
    }

}