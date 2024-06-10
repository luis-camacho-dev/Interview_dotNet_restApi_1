﻿using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class RecordQuery : IRequest<Result<List<Domain.Entity.Record>>>
    {
    }
}
