public class DevTeam
{
    public int Id;
    public string Name;

    private readonly List<Developer> _members = new List<Developer>();

    private int _count;

    public DevTeam()
    {

    }

    public void Add(Developer developer) // Change this to add by id and not by developer object.
    {
        // Prevent the same developer from being added to a team more than once. HINT: Use the Id field on Developer to do this.
        _members.Add(developer);
    }
    // add multiple Developers to a team at once, rather than one by one.

    public void AddMultiple(List<Developer> developers)
    {
        foreach (Developer developer in developers)
        {
            _members.Add(developer);
        }
    }

    public List<Developer> Read()
    {
        return _members;
    }

    public bool Delete(int id)
    {
        foreach (Developer developer in _members)
        {
            if (id == developer.Id)
            {
                _members.Remove(developer);
                return true;
            }
        }
        return false;
    }
}
