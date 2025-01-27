﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteTechSchoolERP.Models.ViewModels
{
    public class SubAdminEditViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CNICNumber { get; set; }
        public string CampusName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Status { get; set; }
    }
}
