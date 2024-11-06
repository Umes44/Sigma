using BusinessLayer.Interface;
using DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MediatR
{
    public class UpdateCreateCandidateHandler : IRequestHandler<UpdateCreateCandidateCommand, ApiResponse>
    {
        private readonly ICandidateInformation _candidate;

        public UpdateCreateCandidateHandler(ICandidateInformation candidate)
        {
            _candidate = candidate;
        }

        public async Task<ApiResponse> Handle(UpdateCreateCandidateCommand request, CancellationToken cancellationToken)
        {
            return await _candidate.UpdateCreateCandidate(request.Model);
        }
    }
}
