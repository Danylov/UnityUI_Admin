using MySql.Data.MySqlClient;
using UnityEngine;
using System.Data;

public class TeachersDbHelper
{
    private MySqlConnection db_connection;
    public TeachersDbHelper(string db_connection_string)
    {
        db_connection = new MySqlConnection(db_connection_string);
        db_connection.Open();
    }

    ~TeachersDbHelper()
    {
        db_connection.Close();
    }
    public virtual int addTeacher(Teacher teacher)
    {
        throw null;
    }
    public virtual MySqlDataReader findTeacher(string login)
    {
        throw null;
    }
    public virtual MySqlDataReader findTeachersLike(string currInput)
    {
        throw null;
    }
    public virtual void deleteTeacherByLogin(string login)
    {
        throw null;
    }
    public virtual void deleteTeacherById(int id)
    {
        throw null;
    }    
    public virtual void deleteCheckedTeachers()
    {
        throw null;
    }    
    public virtual MySqlDataReader getAllTeachers()
    {
        throw null;
    }
    public virtual void deleteAllTeachers()
    {
        throw null;
    }
   public MySqlCommand getDbCommand()
    {
        return db_connection.CreateCommand();
    }

    public MySqlDataReader getAllTeachers(string table_name)
    {
        MySqlCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "SELECT * FROM" + " " + table_name;
        MySqlDataReader reader = dbcmd.ExecuteReader();
        return reader;
    }

    public void deleteAllTeachers(string table_name)
    {
        MySqlCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "DROP TABLE IF EXISTS " + table_name;
        dbcmd.ExecuteNonQuery();
    }
    public virtual void checkTeacher(int id, bool isOn)
    {
        throw null;
    }

    public virtual void checkAllTeachers(bool isOn)
    {
        throw null;
    }

    public void close()
    {
        db_connection.Close();
    }
}