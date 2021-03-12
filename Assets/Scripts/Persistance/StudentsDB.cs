using System;
using MySql.Data.MySqlClient;
using UnityEngine;

public class StudentsDB : StudentDbHelper
{
    private static readonly string connect = MenuUIManager.connect; 

    public StudentsDB() : base(connect)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS students (`id` int NOT NULL AUTO_INCREMENT, " + 
                            "`fullname` varchar(45) DEFAULT NULL, `organiztype` varchar(45) DEFAULT NULL, " + 
                            "`position` varchar(45) DEFAULT NULL, `persnumber` int DEFAULT NULL, " + 
                            "`login` varchar(45) DEFAULT NULL, `password` varchar(45) DEFAULT NULL, " + 
                            "`choosed` tinyint(1) NOT NULL DEFAULT '0', PRIMARY KEY (`id`) ) " + 
                            "ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
        dbcmd.ExecuteNonQuery();
    }

    public void addStudent(Student student)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "INSERT INTO students (fullname, organiztype, position, persnumber, login, password, ipaddress, choosed) VALUES ( '" + 
                            student.Fullname1 + "', '" + student.Organiztype1 + "', '" + student.Position1 + "', '" + 
                            student.Persnumber1 + "', '" + student.Login1 + "', '" + MenuUIManager.PasswEncryption(student.Password1) + 
                            "', '" + student.Ipaddress1 + "', '" + student.Choosed1 + "' )";
        dbcmd.ExecuteNonQuery();
    }
   
    public override MySqlDataReader findStudent(string login)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT password FROM students WHERE login = '" + login + "'";;
        return dbcmd.ExecuteReader();
    }
    
    public override MySqlDataReader findStudentsLike(string currInput)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM students WHERE fullname LIKE '" +
                            currInput + "%' OR  login LIKE '" + currInput + "%'";
        return dbcmd.ExecuteReader();
    }
    
    public override void deleteStudentByLogin(string login)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM  students WHERE login = '" + login + "'";
        dbcmd.ExecuteNonQuery();
    }
    
    public override void deleteStudentById(int id)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM  students WHERE id = '" + id + "'";
        dbcmd.ExecuteNonQuery();
    }
    
    public override void deleteCheckedStudents()
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM  students WHERE choosed = 1";
        dbcmd.ExecuteNonQuery();
    }

    public override MySqlDataReader getAllStudents()
    {
        return base.getAllStudents("Students");
    }

    public override void deleteAllStudents()
    {
        base.deleteAllStudents("Students");
    }

    public override void checkStudent(int id, bool isOn)
    {
        int isOnInt = isOn ? 1 : 0;
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "UPDATE students SET choosed = '" + isOnInt + "' WHERE id = '" + id + "'";
        dbcmd.ExecuteNonQuery();
    }
 
    public override void checkAllStudents(bool isOn)
    {
        int isOnInt = isOn ? 1 : 0;
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "UPDATE students SET choosed = '" + isOnInt + "' WHERE id>=0";
        dbcmd.ExecuteNonQuery();
    }
   
    public void close()
    {
        base.close();
    }
}