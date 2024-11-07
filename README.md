LIST OF WAYS OF IMPROVEMENT
1.	Caching Does not provide any benefits for POST method as response is different. (This is the reason I have not included caching in this project). There is issue in data consistency.
LIST OF ASSUMPTIONS
•	Addition of Logs
•	Addition of Rate limiting
•	Addition of TimeStamp information regarding which user has entered the data and at which date and time
TOTAL TIME SPENT FOR THE TASK: 4 Hours

APPROACHES USED FOR PROJECT
Design of Model: Candidate Information Model 
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

    }Remarks: I have set field IsCallNeeded. This Field is set to true when call is needed and value is set in CallTimeInterval

Serilog is used for logging of the information.
MediatR is used for promoting loose coupling.
Unit testing is done using xUnit. I am not much familiar with Unit Testing but little I tried.

