using HmoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmoDTO.DTO
{
    public class ManufacturerDTO
    {
        public int Id { get; set; }

        public string Desc { get; set; } = null!;

        //public virtual ICollection<Vaccinated> Vaccinateds { get; set; } = new List<Vaccinated>();
    }
}
