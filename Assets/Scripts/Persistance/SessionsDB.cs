using System;
using MySql.Data.MySqlClient;
using UnityEngine;

public class SessionsDB : SessionsDbHelper
{
    private static readonly string connect = MenuUIManager.connect; 

    public SessionsDB() : base(connect)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS `sessions` (`id` int unsigned NOT NULL AUTO_INCREMENT, " + 
                            " `teacherid` int DEFAULT NULL, `studentid` int DEFAULT NULL," + 
                            "`taskid` int DEFAULT NULL," + 
                            "`begtime` datetime DEFAULT NULL, `endtime` datetime DEFAULT NULL," + 
                            "PRIMARY KEY (`id`), KEY `studentid_fk_idx` (`studentid`)," + 
                            "KEY `teacherid_fk_idx` (`teacherid`), KEY `taskid_fk_idx` (`taskid`)," + 
                            "CONSTRAINT `studentid_fk` FOREIGN KEY (`studentid`) REFERENCES `students` (`id`)," + 
                            "CONSTRAINT `teacherid_fk` FOREIGN KEY (`teacherid`) REFERENCES `teachers` (`id`)," + 
                            "CONSTRAINT `taskid_fk` FOREIGN KEY (`taskid`) REFERENCES `tasks` (`id`)" + 
                            ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";
        dbcmd.ExecuteNonQuery();
    }

    public override void addSession(Session session)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "INSERT INTO sessions (teacherid, studentid, taskid, begtime, endtime) VALUES ( '" + 
                            session.Teacherid1 + "', '" + session.Studentid1 + "', '" + session.Taskid1 + 
                            "', '" + session.Begtime1.ToString("yyyy-MM-dd H:mm:ss") + "', '" + 
                            session.Endtime1.ToString("yyyy-MM-dd H:mm:ss") +  "' )";
        dbcmd.ExecuteNonQuery();
    }
   
    public override MySqlDataReader findSessionsByTeacherId(int teacherId)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "SELECT * FROM sessions WHERE teacherid = '" + teacherId + "'";;
        return dbcmd.ExecuteReader();
    }
    
    public override void deleteSessionById(int id)
    {
        MySqlCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "DELETE FROM  sessions WHERE id = '" + id + "'";
        dbcmd.ExecuteNonQuery();
    }

    public override MySqlDataReader getAllSessions()
    {
        return base.getAllSessions("sessions");
    }

    public override void deleteAllSessions()
    {
        base.deleteAllSessions("sessions");
    }
   
    public void close()
    {
        base.close();
    }
}