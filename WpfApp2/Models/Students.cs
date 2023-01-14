using System;
using System.Collections.Generic;

namespace WpfApp2.Models;

public class Students
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public DateTime Birthday { get; set; }

    public double Rating { get; set; }
    public string Description { get; set; }
}

public class Group
{
    public string Name { get; set; }

    public ICollection<Students> StudentsCount { get; set; }
    
}