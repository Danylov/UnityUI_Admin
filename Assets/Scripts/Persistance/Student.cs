using System.ComponentModel;
using UnityEngine;

public class Student
{
    private int Id;
    private string Fullname;
    private string Organiztype;
    private string Position;
    private int Persnumber;
    private string Login;
    private string Password;
    private int Choosed;

    public Student(string fullname, string organiztype, string position, int persnumber, string login, string password)
    {
        Fullname = fullname;
        Organiztype = organiztype;
        Position = position;
        Persnumber = persnumber;
        Login = login;
        Password = password;
    }

    public int Id1
    {
        get => Id;
        set => Id = value;
    }

    public string Fullname1
    {
        get => Fullname;
        set => Fullname = value;
    }

    public string Organiztype1
    {
        get => Organiztype;
        set => Organiztype = value;
    }

    public string Position1
    {
        get => Position;
        set => Position = value;
    }

    public int Persnumber1
    {
        get => Persnumber;
        set => Persnumber = value;
    }

    public string Login1
    {
        get => Login;
        set => Login = value;
    }

    public string Password1
    {
        get => Password;
        set => Password = value;
    }

    [DefaultValue(0)]
    public int Choosed1
    {
        get => Choosed;
        set => Choosed = value;
    }
}
