using HmoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmoDTO.DTO
{
    public class VaccinatedDTO
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public DateOnly VaccinDate { get; set; }

        public int ManufacturerId { get; set; }

        //public virtual Manufacturer Manufacturer { get; set; } = null!;

        //public virtual HmoMember Member { get; set; } = null!;
    }
}
