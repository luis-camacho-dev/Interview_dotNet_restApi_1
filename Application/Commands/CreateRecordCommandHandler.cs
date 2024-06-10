using Application.Repositories;
using Domain.Entity;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateRecordCommandHandler : IRequestHandler<CreateRecordItemCommand, Result<int>>
    {
        private IRecordRepository _recordRepository;
        public CreateRecordCommandHandler(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public Task<Result<int>> Handle(CreateRecordItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Record
            {
                Name = request.Name
            };
            var insertResult = _recordRepository.CreateRecord(item);
            return Task.FromResult(insertResult);
        }
    }
}
