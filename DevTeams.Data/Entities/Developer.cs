//POCO -> Plain Old C# Object
public class Developer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Developer()
    {

    }
    public Developer(int id, string firstName, string lastName, bool hasPluralsight)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        HasPluralsight = hasPluralsight;
    }

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
    public bool HasPluralsight { get; set; }
}