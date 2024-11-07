﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataModel
{
    public class Candidate :CandidateVM
    {
        [Key]
        public int CandidateID { get; set; }
        public bool IsCallNeeded { get; set; }
    }
    // View Model for Candidate Model
    public class CandidateVM
    {
      
        [Required]
        [DisplayName("First name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 characters.")]

        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Phone number")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Phone Number must be between 5 and 20 characters.")]

        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        //public bool IsCallNeeded { get; set; }
        //Assuming when IsCallNeeded is false, call time interval will be set to 0
        [DisplayName("Time interval when it’s better to call ")]
        public int CallTimeInterval { get; set; }
        [DisplayName("LinkedIn profile URL ")]
        public string LinkedInProfileUrl { get; set; }
        [DisplayName("GitHub profile URL ")]
        public string GithubProfileUrl { get; set; }
        [Required]
        [DisplayName("Free text comment ")]
        public string Remarks { get; set; }

    }
}
