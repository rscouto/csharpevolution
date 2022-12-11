using AutoMapper;
using CsharpEvolution.Tests01.Domain.Entities.Messages;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.Domain.Mappers;
public class PerformedOperationMapper : Profile
{
    public PerformedOperationMapper()
    {
        CreateMap<PerformedOperation, GetPerformedOperationResponse>()
            .ForMember(operation => operation.MathOperation, response => response.MapFrom(operation => operation.MathOperation.ToString()));
    }
}

