using MySql.Data.MySqlClient;
using UnityEngine;
using System.Data;

public class SessionsDbHelper
{
    private MySqlConnection db_connection;
    public SessionsDbHelper(string db_connection_string)
    {
        db_connection = new MySqlConnection(db_connection_string);
        db_connection.Open();
    }

    ~SessionsDbHelper()
    {
        db_connection.Close();
    }
    public virtual void addSession(Session session)
    {
        throw null;
    }

    public virtual MySqlDataReader findSessionsByTeacherId(int teacherId)
    {
        throw null;
    }
    public virtual void deleteSessionById(int id)
    {
        throw null;
    }    
    public virtual MySqlDataReader getAllSessions()
    {
        throw null;
    }
    public virtual void deleteAllSessions()
    {
        throw null;
    }
    public MySqlCommand getDbCommand()
    {
        return db_connection.CreateCommand();
    }

    public MySqlDataReader getAllSessions(string table_name)
    {
        MySqlCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "SELECT * FROM" + " " + table_name;
        MySqlDataReader reader = dbcmd.ExecuteReader();
        return reader;
    }

    public void deleteAllSessions(string table_name)
    {
        MySqlCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText = "DROP TABLE IF EXISTS " + table_name;
        dbcmd.ExecuteNonQuery();
    }
    public void close()
    {
        db_connection.Close();
    }
}