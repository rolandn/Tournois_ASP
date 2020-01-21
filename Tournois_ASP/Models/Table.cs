using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournois_ASP.Models
{
    public class Table
    {
        public int Idt { get; set; }
        public int Position { get; set; }

        public Table (int idt, int position)
        {
            Idt = idt;
            Position = position;
        }
    }
}
