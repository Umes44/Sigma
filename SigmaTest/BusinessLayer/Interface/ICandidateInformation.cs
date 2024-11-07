using DataModel;
using DataModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICandidateInformation
    {//Creation of Interface which handles both create and update operation for CandidateData
        Task<ApiResponse> UpdateCreateCandidate(CandidateVM model);
    }
}
