﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournois_ASP.CoucheAccesBD
{
    public class ExceptionAccesBD : Exception
    {
        public ExceptionAccesBD(string msgDetail) : base(msgDetail)
        {
        }
    }
}
