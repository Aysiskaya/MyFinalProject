﻿using Coree.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics )
        {
            foreach ( var logic in logics )
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
