using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13TravelsEF
{
    public class Train //Owner
    {
        public int Id { get; set; }
        [Range(1, 999)]
        public int Number { get; set; } // train number e.g. 678 range 1-999        
        public DateTime Date { get; set; } // date only, time is irrelevant
        public virtual ICollection<Passenger> PassengersCollection { get; set; }

        public override string ToString()
        {
            return $"Train({Id}): {Number} {Date}"; 
        }
    }
}
