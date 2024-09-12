public class Trophy
{
    public int Id { get; set; }
    public string? Competition { get; set; }
    public int Year { get; set; }


    public override string ToString()
    {
        return $"{Id} + {Competition} + {Year}";
    }

    
    public void ValidateCompetition()
    {
        if (Competition==null)
        {
            throw new ArgumentNullException("Competition cannnot be null");
        }
        if (Competition.Length <= 3)
        {
            throw new ArgumentOutOfRangeException("Competition length must be at least 3");
        }


    }

    public void ValidateYear()
    {
        if (Year <= 1970 || Year >= 2024)
        {
            throw new ArgumentOutOfRangeException("Please select a number in range");
        }


    }

}

