using MySql.Data.MySqlClient;
using UnityEngine;

public class StudentsDB : StudentsDbHelper
{
    private static readonly string connect = MenuUIManager.connect; 

    public StudentsDB() : base(connect)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS students (`id` int NOT NULL AUTO_INCREMENT, " + 
                            "`name` varchar(45) DEFAULT NULL, `family` varchar(45) DEFAULT NULL, " + 
                            "`mdlname` varchar(45) DEFAULT NULL, `studgroup` varchar(45) DEFAULT NULL, " + 
                            "`login` varchar(45) DEFAULT NULL, `password` varchar(45) DEFAULT NULL, " + 
                            "`choosed` tinyint(1) NOT NULL DEFAULT '0', PRIMARY KEY (`id`) ) " + 
                            "ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
        dbcmd.ExecuteNonQuery();
    }

    public override void addStudent(Student student)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "INSERT INTO students (name, family, mdlname, studgroup, login, password, ipaddress, choosed) VALUES ( '" + 
                            student.Name1 + "', '" + student.Family1 + "', '" + student.MdlName1 + "', '" + 
                            student.StudGroup1 + "', '" + student.Login1 + "', '" + MenuUIManager.PasswEncryption(student.Password1) + 
                            "', '" + student.Ipaddress1 + "', '" + student.Choosed1 + "' )";
        dbcmd.ExecuteNonQuery();
    }
   
    public override MySqlDataReader findStudentById(int id)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM students WHERE id = '" + id + "'";;
        return dbcmd.ExecuteReader();
    }
    
    public override MySqlDataReader findStudentsLike(string currInput)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM students WHERE family LIKE '" +
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
    
    public override MySqlDataReader getChoosedStudents()
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM  students WHERE choosed = 1";
        MySqlDataReader reader = dbcmd.ExecuteReader();
        return reader;
    }

    public override MySqlDataReader getAllStudents()
    {
        return base.getAllStudents("students");
    }

    public override int getNumberRegisteredStudents()
    {
        var reader = getAllStudents();
        int numRegStudents = 0;
        while (reader.Read()) numRegStudents++;
        reader.Close();
        return numRegStudents;
    }

    public override bool isAllStudentsChoosed()
    {
        var numRegStudents = getNumberRegisteredStudents();
        var reader = getChoosedStudents();
        int numChoosedStudents = 0;
        while (reader.Read()) numChoosedStudents++;
        reader.Close();
        bool isAllStudChoosed = (numRegStudents == numChoosedStudents);
        return isAllStudChoosed;
    }    

    public override void deleteAllStudents()
    {
        base.deleteAllStudents("students");
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