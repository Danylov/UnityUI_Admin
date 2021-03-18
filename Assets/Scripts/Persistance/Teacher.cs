using System;
using System.ComponentModel;

public class Teacher
{
    private int Id;
    private string Name;
    private string Family;
    private string MdlName; 
    private string Position;
    private string Login;
    private string Password;
    private string Ipaddress;
    private DateTime Regtime;
    private int Choosed;

    public Teacher(string name, string family, string mdlName, string position, string login, string password, string ipaddress, DateTime regtime, int choosed)
    {
        Name = name;
        Family = family;
        MdlName = mdlName;
        Position = position;
        Login = login;
        Password = password;
        Ipaddress = ipaddress;
        Regtime = regtime;
        Choosed = choosed;
    }

    public int Id1
    {
        get => Id;
        set => Id = value;
    }

    public string Name1
    {
        get => Name;
        set => Name = value;
    }

    public string Family1
    {
        get => Family;
        set => Family = value;
    }

    public string MdlName1
    {
        get => MdlName;
        set => MdlName = value;
    }

    public string Position1
    {
        get => Position;
        set => Position = value;
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

    public string Ipaddress1
    {
        get => Ipaddress;
        set => Ipaddress = value;
    }

    
    public DateTime Regtime1 
    { 
        get => Regtime;
        set => Regtime = value;
}

    [DefaultValue(0)]
    public int Choosed1
    {
        get => Choosed;
        set => Choosed = value;
    }
}
