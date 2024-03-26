using System;
using System.Collections.Generic;

namespace HmoDAL.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Desc { get; set; } = null!;

    public virtual ICollection<Vaccinated> Vaccinateds { get; set; } = new List<Vaccinated>();
}
