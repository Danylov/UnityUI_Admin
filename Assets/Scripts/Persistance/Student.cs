using System.ComponentModel;

public class Student
{
    private int Id;
    private string Name;
    private string Family;
    private string MdlName; 
    private string StudGroup;
    private string Login;
    private string Password;
    private string Ipaddress;
    private int Choosed;

    public Student(string name, string family, string mdlName, string studGroup, string login, string password, string ipaddress, int choosed)
    {
        Name = name;
        Family = family;
        MdlName = mdlName;
        StudGroup = studGroup;
        Login = login;
        Password = password;
        Ipaddress = ipaddress;
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

    public string StudGroup1
    {
        get => StudGroup;
        set => StudGroup = value;
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

    [DefaultValue(0)]
    public int Choosed1
    {
        get => Choosed;
        set => Choosed = value;
    }
}
