using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmoDTO.DTO
{
    public class HmoMemberDTO
    {
        public int Id { get; set; }

        public int IdCivil { get; set; }

        public string FullName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public int? Phone { get; set; }

        public int Mobile { get; set; }

        public int? CountVaccin { get; set; }

       // public virtual ICollection<Sick> Sicks { get; set; } = new List<Sick>();

       // public virtual ICollection<Vaccinated> Vaccinateds { get; set; } = new List<Vaccinated>();
    }
}
