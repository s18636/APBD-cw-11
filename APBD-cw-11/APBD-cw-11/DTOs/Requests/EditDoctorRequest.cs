﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw_11.DTOs.Requests
{
    public class EditDoctorRequest
    {
        public int IdDoctor { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
