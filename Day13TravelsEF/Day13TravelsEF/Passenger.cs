using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13TravelsEF
{
    public class Passenger //Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } // 1-50 characters

        public string Gender { get; set; }

        public virtual Train Train { get; set; } // may be null
        
        //      [NotMapped] // you may not need this computed property
        //      TrainDesc {
		//get { // handle when train is Null
		//	return $"{Train.Number} on {Train.Date}"
		//}

        public override string ToString()
        {
            string trainStr = Train == null ? "null" : Train.ToString();
            return $"Passenger({Id}): {Name}, {Gender} train: {trainStr}";
        }

    }
}
