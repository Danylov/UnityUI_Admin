﻿using MySql.Data.MySqlClient;

public class StudentsDbHelper
{
    private MySqlConnection db_connection;
    public StudentsDbHelper(string db_connection_string)
    {
        db_connection = new MySqlConnection(db_connection_string);
        db_connection.Open();
    }

    ~StudentsDbHelper()
    {
        db_connection.Close();
    }
    public virtual void addStudent(Student student)
    {
        throw null;
    }
    public virtual MySqlDataReader findStudentById(int id)
    {
        throw null;
    }
    public virtual MySqlDataReader findStudentsLike(string currInput)
    {
        throw null;
    }
    public virtual void deleteStudentByLogin(string login)
    {
        throw null;
    }
    public virtual void deleteStudentById(int id)
    {
        throw null;
    }    
    public virtual MySqlDataReader getChoosedStudents()
    {
        throw null;
    }    
    public virtual MySqlDataReader getAllStudents()
    {
        throw null;
    }
    public virtual int getNumberRegisteredStudents()
    {
        throw null;
    }
    public virtual bool isAllStudentsChoosed()
    {
        throw null;
    }    
    public virtual void deleteAllStudents()
    {
        throw null;
    }
   public MySqlCommand getDbCommand()
    {
        return db_connection.CreateCommand();
    }

    public MySqlDataReader getAllStudents(string table_name)
    {
        MySqlCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "SELECT * FROM" + " " + table_name;
        MySqlDataReader reader = dbcmd.ExecuteReader();
        return reader;
    }

    public void deleteAllStudents(string table_name)
    {
        MySqlCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "DROP TABLE IF EXISTS " + table_name;
        dbcmd.ExecuteNonQuery();
    }
    public virtual void checkStudent(int id, bool isOn)
    {
        throw null;
    }

    public virtual void checkAllStudents(bool isOn)
    {
        throw null;
    }

    public void close()
    {
        db_connection.Close();
    }
}