﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreach_challenge
{
    internal class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonModel(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
