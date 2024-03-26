using System;
using System.Collections.Generic;

namespace HmoDAL.Models;

public partial class Vaccinated
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public DateOnly VaccinDate { get; set; }

    public int ManufacturerId { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual HmoMember Member { get; set; } = null!;
}
