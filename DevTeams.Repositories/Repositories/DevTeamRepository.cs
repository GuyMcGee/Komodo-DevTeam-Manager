public class DevTeamRepository
{
    private readonly List<DevTeam> _devTeamsDb = new List<DevTeam>();

    private int _count;
    private int _idCount;

    public DevTeamRepository()
    {
        _idCount = 0;
    }

    public void Add(DevTeam devteam)
    {
        _idCount = _idCount + 1;
        devteam.Id = _idCount;
        _devTeamsDb.Add(devteam);
    }

    public List<DevTeam> Read()
    {
        return _devTeamsDb;
    }

    public bool Update(int devTeamId, Developer developer)
    {
        foreach (DevTeam devteam in _devTeamsDb)
        {
            if (devTeamId == devteam.Id)
            {
                devteam.Add(developer);
                return true;
            }
        }
        return false;
    }

    public bool DeleteMember(int devTeamId, int devId)
    {
        foreach (DevTeam devteam in _devTeamsDb)
        {
            if (devTeamId == devteam.Id)
            {
                return devteam.Delete(devId);
            }
        }
        return false;
    }


}
