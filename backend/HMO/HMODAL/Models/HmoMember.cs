using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HmoDAL.Models;

public partial class HmoMember
{
    

    public int Id { get; set; }

    public int IdCivil { get; set; }

    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }

    public int? Phone { get; set; }

    public int Mobile { get; set; }

    public int? CountVaccin { get; set; } = 0;

    public virtual ICollection<Sick> Sicks { get; set; } = new List<Sick>();

    public virtual ICollection<Vaccinated> Vaccinateds { get; set; } = new List<Vaccinated>();
}
