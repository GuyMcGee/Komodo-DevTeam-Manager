public class DeveloperRepository
{
    //Fake database
    private readonly List<Developer> _devsDb = new List<Developer>();
    private int _count;

    private int _idCount;

    public DeveloperRepository()
    {
        _idCount = 0;
    }

    public void Add(Developer developer)
    {
        _idCount = _idCount + 1;
        developer.Id = _idCount;
        _devsDb.Add(developer);
    }

    public List<Developer> Read()
    {
        return _devsDb;
    }

    public Developer Find(int id)
    {
        foreach (Developer dev in _devsDb)
        {
            if (dev.Id == id)
            {
                return dev;
            }
        }

        return null;
    }

    public bool Delete(int id)
    {
        foreach (Developer developer in _devsDb)
        {
            if (id == developer.Id)
            {
                _devsDb.Remove(developer);
                return true;
            }
        }
        return false;
    }
}