
using System.ComponentModel;
using System.ComponentModel.Design;

public class TrophiesRepository : Trophy
{

    private int _nextId = 1;
    private readonly List<Trophy> _trophies = new();

    public void TrophiesRepositoryList()
    {
        _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Football", Year = 1992 });
        _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Golf", Year = 2000 });
        _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Swimning", Year = 2024 });
        _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Hockey", Year = 1970 });
        _trophies.Add(new Trophy() { Id = _nextId++, Competition = "Basketball", Year = 2016 });

    }



    public IEnumerable<Trophy> Get(int? yearAfter = null, string? includes = null, string? orderby = null)
    {
        IEnumerable<Trophy> trophies = _trophies;
        //Filtering
        if (yearAfter != null)
        {
            trophies = trophies.Where(t => t.Year > yearAfter);
        }

        //Sorting
        if (orderby != null)
        {
            orderby = orderby.ToLower();
            switch (orderby)
            {
                case "Year in order":
                    trophies = trophies.OrderBy(t => t.Year); break;
                case "Competition in order":
                    trophies = trophies.OrderBy(t => t.Competition); break;
            }
        }
        return trophies;
    }

    public Trophy? GetById(int id)
    {
        if (id == 0) return null;

        return _trophies.Find(t => t.Id == id);
        //else return null

        //Mangler Exeption
    }


    public Trophy Add(Trophy trophy)
    {
        trophy.ValidateYear();
        trophy.Id = _nextId++;
        _trophies.Add(trophy);
        return trophy;
    }

    public Trophy Remove(int id)
    {
        Trophy? trophy = GetById(id);
        if (trophy == null)
        {
            return null;
        }
        _trophies.Remove(trophy);
        return trophy;
    }

    public Trophy? Update(int id, Trophy values)
    {
        values.ValidateYear();
        Trophy? existingTrophy = GetById(id);
        if (existingTrophy == null)
        {
            return null;
        }
        existingTrophy.Competition = values.Competition;
        existingTrophy.Year = values.Year;
        return existingTrophy;
    }
}
