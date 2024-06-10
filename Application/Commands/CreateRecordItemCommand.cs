using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateRecordItemCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }

      
    }
}
