using System;

public class Session
{
    private int Id;
    private int Teacherid;
    private int Studentid;
    private DateTime Begtime;
    private DateTime Endtime;
    private string Taskname;

    public Session(int id, int teacherid, int studentid, DateTime begtime, DateTime endtime, string taskname)
    {
        Id = id;
        Teacherid = teacherid;
        Studentid = studentid;
        Begtime = begtime;
        Endtime = endtime;
        Taskname = taskname;
    }

    public int Id1
    {
        get => Id;
        set => Id = value;
    }

    public string Taskname1
    {
        get => Taskname;
        set => Taskname = value;
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

    public int Studentid1
    {
        get => Studentid;
        set => Studentid = value;
    }

    public int Teacherid1
    {
        get => Teacherid;
        set => Teacherid = value;
    }
}