namespace Peerly.Gateway.Hosting.Auth.Data;

public static class Role
{
    public static readonly string[] AllRoles = [Admin, Student, Teacher];
    public static readonly string[] EditorRoles = [Admin, Teacher];

    public const string Admin = "Admin";
    public const string Student = "Student";
    public const string Teacher = "Teacher";
}
