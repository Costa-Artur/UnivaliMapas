using AutoMapper;
using UnivaliMapas.Api.Entities;


using UnivaliMapas.Api.Models;
using UnivaliMapas.Features.Aulas.Queries.GetAulaByStudent;
using UnivaliMapas.Features.Blocos.Commands.CreateBloco;
using UnivaliMapas.Features.Blocos.Commands.UpdateBloco;
using UnivaliMapas.Features.Blocos.Queries.GetBloco;


namespace UnivaliMapas.Api.Profiles;

public class BlocoProfile : Profile
{
    public BlocoProfile()
    {
        CreateMap<Bloco, BlocoDto>();
        CreateMap<BlocoDto, Bloco>();
        CreateMap<GetBlocoWithSalaDetailDto,Bloco>();
        CreateMap<Bloco, GetBlocoWithSalaDetailDto>();

        //CQRS
        CreateMap<Bloco, CreateBlocoDto>();
        
        CreateMap<Bloco, GetBlocoDetailDto>();
        CreateMap<Bloco, GetBlocoWithSalaDetailDto>();

        CreateMap<BlocoForCreationDto, Bloco>();
        CreateMap<UpdateBlocoCommand, Bloco>();
        CreateMap<Bloco, UpdateBlocoDto>();

        CreateMap<Aula, GetAulaByStudentDto>();
        
        CreateMap<Materia, MateriaDto>();

        CreateMap<Usuario, ProfessorDto>();
        
        
        CreateMap<ProfessorDto, Usuario>();
    }
}