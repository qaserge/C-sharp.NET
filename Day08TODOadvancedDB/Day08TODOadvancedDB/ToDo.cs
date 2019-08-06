using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08TODOadvancedDB
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
        public string DueDate { get; set; }

        public override string ToString()
        {
            return $"{Id} {Task} {Status} {DueDate}";
        }
    }
}
