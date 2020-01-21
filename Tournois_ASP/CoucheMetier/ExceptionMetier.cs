using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournois_ASP.CoucheMetier
{
    public class ExceptionMetier : Exception
    {
        public ExceptionMetier(string msgDetail) : base(msgDetail)
        {
        }
    }
}
