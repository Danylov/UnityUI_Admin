using System;
using MySql.Data.MySqlClient;
using UnityEngine;

public class TeachersDB : TeacherDbHelper
{
    private static readonly string connect = MenuUIManager.connect; 

    public TeachersDB() : base(connect)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS teachers (`id` int NOT NULL AUTO_INCREMENT, " + 
                            "`fullname` varchar(45) DEFAULT NULL, `organiztype` varchar(45) DEFAULT NULL, " + 
                            "`position` varchar(45) DEFAULT NULL, `persnumber` int DEFAULT NULL, " + 
                            "`login` varchar(45) DEFAULT NULL, `password` varchar(45) DEFAULT NULL, " + 
                            "`choosed` tinyint(1) NOT NULL DEFAULT '0', PRIMARY KEY (`id`) ) " + 
                            "ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
        dbcmd.ExecuteNonQuery();
    }

    public void addTeacher(Teacher teacher)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "INSERT INTO teachers (fullname, organiztype, position, persnumber, login, password, ipaddress, choosed) VALUES ( '" + 
                            teacher.Fullname1 + "', '" + teacher.Organiztype1 + "', '" + teacher.Position1 + "', '" + 
                            teacher.Persnumber1 + "', '" + teacher.Login1 + "', '" + MenuUIManager.PasswEncryption(teacher.Password1) + 
                            "', '" + teacher.Ipaddress1 + "', '" + teacher.Choosed1 + "' )";
        dbcmd.ExecuteNonQuery();
    }
   
    public override MySqlDataReader findTeacher(string login)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT password FROM teachers WHERE login = '" + login + "'";;
        return dbcmd.ExecuteReader();
    }
    
    public override MySqlDataReader findTeachersLike(string currInput)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM teachers WHERE fullname LIKE '" +
                            currInput + "%' OR  login LIKE '" + currInput + "%'";
        return dbcmd.ExecuteReader();
    }
    
    public override void deleteTeacherByLogin(string login)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM  teachers WHERE login = '" + login + "'";
        dbcmd.ExecuteNonQuery();
    }
    
    public override void deleteTeacherById(int id)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM  teachers WHERE id = '" + id + "'";
        dbcmd.ExecuteNonQuery();
    }
    
    public override void deleteCheckedTeachers()
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM  teachers WHERE choosed = 1";
        dbcmd.ExecuteNonQuery();
    }

    public override MySqlDataReader getAllTeachers()
    {
        return base.getAllTeachers("Teachers");
    }

    public override void deleteAllTeachers()
    {
        base.deleteAllTeachers("Teachers");
    }

    public override void checkTeacher(int id, bool isOn)
    {
        int isOnInt = isOn ? 1 : 0;
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "UPDATE teachers SET choosed = '" + isOnInt + "' WHERE id = '" + id + "'";
        dbcmd.ExecuteNonQuery();
    }
 
    public override void checkAllTeachers(bool isOn)
    {
        int isOnInt = isOn ? 1 : 0;
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "UPDATE teachers SET choosed = '" + isOnInt + "' WHERE id>=0";
        dbcmd.ExecuteNonQuery();
    }
   
    public void close()
    {
        base.close();
    }
}