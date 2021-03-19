using MySql.Data.MySqlClient;

public class TasksDbHelper
{
    private MySqlConnection db_connection;
    public TasksDbHelper(string db_connection_string)
    {
        db_connection = new MySqlConnection(db_connection_string);
        db_connection.Open();
    }

    ~TasksDbHelper()
    {
        db_connection.Close();
    }
    public virtual void addTask(Task task)
    {
        throw null;
    }
    public virtual MySqlDataReader findTaskById(int id)
    {
        throw null;
    }
    public virtual void deleteTaskById(int id)
    {
        throw null;
    }    
    public virtual void deleteAllTasks()
    {
        throw null;
    }
   public virtual void getTask(int id)
    {
        throw null;
    }
    public virtual MySqlDataReader getAllTasks()
    {
        throw null;   
    }

   public MySqlCommand getDbCommand()
    {
        return db_connection.CreateCommand();
    }
    public void close()
    {
        db_connection.Close();
    }
}