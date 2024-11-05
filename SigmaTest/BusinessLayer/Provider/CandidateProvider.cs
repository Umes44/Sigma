using BusinessLayer.Interface;
using DataModel;
using DataModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Provider
{
    public class CandidateProvider : ICandidateInformation
    {
        private DatabaseContext _context;
        public CandidateProvider(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse> UpdateCreateCandidate(Candidate model)
        {
            var message = string.Empty;
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var checkemail = _context.Candidates.Where(x => x.Email == model.Email).FirstOrDefault();
                    if (checkemail == null)
                    {
                        checkemail = new Candidate();
                    }
                    //Following Below Methods can also be done using mapper
                    checkemail.FirstName = model.FirstName;
                    checkemail.LastName = model.LastName;
                    checkemail.PhoneNumber = model.PhoneNumber;
                    checkemail.Email = model.Email;
                    checkemail.CallTimeInterval = model.CallTimeInterval;
                    if (model.CallTimeInterval == 0)
                    {
                        checkemail.IsCallNeeded = false;
                    }
                    checkemail.LinkedInProfileUrl = model.LinkedInProfileUrl;
                    checkemail.GithubProfileUrl = model.GithubProfileUrl;
                    checkemail.Remarks = model.Remarks;
                    if (checkemail.CandidateID == 0)
                    {
                        _context.Candidates.Add(checkemail);
                        _context.SaveChanges();
                        message = "Candidate Information has been Added";
                    }
                    else
                    {
                        _context.Entry(checkemail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                        message = "Candidate Information has been Updated";
                    }
                    return new ApiResponse
                    {
                        Success = true,
                        StatusCode = 200,
                        Message = message,
                        DataSet = checkemail
                    };
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                    return new ApiResponse
                    {
                        Success = false,
                        StatusCode = 500,
                        Message = ex.Message,
                    };
                }
            }
        }
    }
}
