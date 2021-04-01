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
        var outputFile = new StringBuilder();
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
        outputFile.AppendLine("");
        outputFile.AppendLine("Студент:");
        outputFile.AppendLine("");
        var newLine = string.Format("Id: {0}", id);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Имя: {0}", name);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Отчество: {0}", mdlName);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Фамилия: {0}", family);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Группа: {0}", studGroup);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Логин: {0}", login);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Пароль (MD5): {0}", password);
        outputFile.AppendLine(newLine);
        newLine = string.Format("IP адрес: {0}", ipaddress);
        outputFile.AppendLine(newLine);
        var outputFileFilePath = "c:\\" + login + "_student.txt";
        File.WriteAllText(outputFileFilePath, outputFile.ToString());
        reader.Close();
        studentsDB.close();
    }
    
    public static void UnloadButtonTeacherClick(int teacherDbId)
    {
        var teachersDB = new TeachersDB();
        var outputFile = new StringBuilder();
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
        outputFile.AppendLine("");
        outputFile.AppendLine("Преподаватель:");
        outputFile.AppendLine("");
        var newLine = string.Format("Id: {0}", id);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Имя: {0}", name);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Отчество: {0}", mdlName);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Фамилия: {0}", family);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Должность: {0}", position);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Логин: {0}", login);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Пароль (MD5): {0}", password);
        outputFile.AppendLine(newLine);
        newLine = string.Format("IP адрес: {0}", ipaddress);
        outputFile.AppendLine(newLine);
        newLine = string.Format("Дата и время регистрации: {0}", regtime);
        outputFile.AppendLine(newLine);
        var outputFileFilePath = "c:\\" + login + "_teacher.txt";
        File.WriteAllText(outputFileFilePath, outputFile.ToString());
        reader.Close();
        teachersDB.close();
    }

}