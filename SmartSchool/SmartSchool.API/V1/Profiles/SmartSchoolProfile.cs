using AutoMapper;
using SmartSchool.API.v1.Dtos;
using SmartSchool.API.Models;
using SmartSchool.API.Helpers;

namespace SmartSchool.API.v1.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                );
            CreateMap<Professor, ProfessorDto>()
           .ForMember(
               dest => dest.Nome,
               opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
           );
            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
        }
    }
} 
