using System;

public class Session
{
    private int Id;
    private int Teacherid;
    private int Studentid;
    private int Taskid;
    private DateTime Begtime;
    private DateTime Endtime;

    public Session(int id, int teacherid, int studentid, int taskid, DateTime begtime, DateTime endtime)
    {
        Id = id;
        Teacherid = teacherid;
        Studentid = studentid;
        Taskid = taskid;
        Begtime = begtime;
        Endtime = endtime;
        
    }

    public int Id1
    {
        get => Id;
        set => Id = value;
    }

    public int Teacherid1
    {
        get => Teacherid;
        set => Teacherid = value;
    }

    public int Studentid1
    {
        get => Studentid;
        set => Studentid = value;
    }

    public int Taskid1
    {
        get => Taskid;
        set => Taskid = value;
    }

    public DateTime Endtime1
    {
        get => Endtime;
        set => Endtime = value;
    }

    public DateTime Begtime1
    {
        get => Begtime;
        set => Begtime = value;
    }
}