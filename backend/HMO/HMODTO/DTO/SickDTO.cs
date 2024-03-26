using HmoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmoDTO.DTO
{
    public class SickDTO
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public DateOnly PssitiveDate { get; set; }

        public DateOnly? RecoveryDate { get; set; }

       // public virtual HmoMember Member { get; set; } = null!;
    }
}
