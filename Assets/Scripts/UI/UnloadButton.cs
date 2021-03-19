using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UnloadButton : MonoBehaviour
{
    public int studentDbId;
    [SerializeField] private Button button;
    private GameObject StudentsPanel;
    private 
    
        void Start()
    {
        button.onClick.AddListener(() => UnloadButtonClick(studentDbId));  
    }
    public static void UnloadButtonClick(int studentDbId)
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
        var csvFilePath = "c:\\" + login + ".csv";
        File.WriteAllText(csvFilePath, csv.ToString());
        studentsDB.close();
    }
}