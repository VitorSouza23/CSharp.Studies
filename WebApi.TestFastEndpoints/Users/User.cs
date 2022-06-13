namespace TestFestEndpoints.Users;

public class User
{
    public User(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string FullName => FirstName + " " + LastName;

    public bool IsOver18() => Age > 18;
}