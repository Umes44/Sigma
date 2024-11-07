using DataModel.DataModel;
using DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MediatR
{
    public record UpdateCreateCandidateCommand(CandidateVM Model) : IRequest<ApiResponse>;
}
