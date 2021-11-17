using System;
using AutoMapper;
using Enterprise.Domain;
using Enterprise.Application.Dtos;

namespace Enterprise.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Depto, DeptoDto>().ReverseMap();
        
            CreateMap<Funcionario, FuncionarioDto>().ReverseMap();

        }
    }
}

