using Application.Repositories;
using Domain.Entity;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class RecordQueryHandler : IRequestHandler<RecordQuery, Result<List<Domain.Entity.Record>>>
    {
        private IRecordRepository _recordRepository;
        public RecordQueryHandler(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public Task<Result<List<Record>>> Handle(RecordQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_recordRepository.GetAllRecords());
        }
    }
}
