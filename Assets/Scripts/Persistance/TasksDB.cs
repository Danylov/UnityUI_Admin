using MySql.Data.MySqlClient;

public class TasksDB : TasksDbHelper
{
    private static readonly string connect = MenuUIManager.connect; 

    public TasksDB() : base(connect)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS tasks (`id` int NOT NULL AUTO_INCREMENT, " + 
                            "`code` varchar(45) DEFAULT NULL, `description` varchar(450) DEFAULT NULL, " + 
                            "`path` varchar(45) DEFAULT NULL,  PRIMARY KEY (`id`) ) " + 
                            "ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
        dbcmd.ExecuteNonQuery();
    }

    public override void addTask(Task task)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "INSERT INTO tasks (code, description, path) VALUES ( '" + 
                            task.Code1 + "', '" + task.Description1 + "', '" + task.Path1 + "' )";
        dbcmd.ExecuteNonQuery();
        }
   
    public override MySqlDataReader findTaskById(int id)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM tasks WHERE id = '" + id + "'";;
        return dbcmd.ExecuteReader();
    }
    
    public override void deleteTaskById(int id)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM  tasks WHERE id = '" + id + "'";
        dbcmd.ExecuteNonQuery();
    }

    public override void deleteAllTasks()
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DROP TABLE IF EXISTS tasks";
        dbcmd.ExecuteNonQuery();}

    public override void getTask(int id)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM tasks WHERE id = '" + id + "'";
        dbcmd.ExecuteNonQuery();
    }

    public override MySqlDataReader getAllTasks()
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM tasks";
        MySqlDataReader reader = dbcmd.ExecuteReader();
        return reader;
    }
   
    public void close()
    {
        base.close();
    }
}