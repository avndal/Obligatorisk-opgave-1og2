
using System.ComponentModel;

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



    public void Get(int? yearAfter = null, string? includes = null, string? orderby = null)
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





    public int? GetById(int id)
    {
        if (id == null)
        { return null; }
        if (_trophies.FirstOrDefault<>(t => t.id == id))
        { return null; }
        throw new ArgumentException("could not find an object with maching id");
    }

    public Trophy Add(int id)
    {
        Trophy trophyExample = new Trophy() { Id = id };
        _trophies.Add(trophyExample);
        return trophyExample;
    }

    public Trophy Remove(int id)
    {
        if (id == null)
        { return null}
        if (id == null)
        {
            _trophies.Remove(_trophies)
            }




    }
