using System;
using System.Collections.Generic;

namespace HmoDAL.Models;

public partial class Sick
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public DateOnly PssitiveDate { get; set; }

    public DateOnly? RecoveryDate { get; set; }

    public virtual HmoMember Member { get; set; } = null!;
}
