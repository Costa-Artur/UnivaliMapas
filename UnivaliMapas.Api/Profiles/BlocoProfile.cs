using AutoMapper;
using UnivaliMapas.Api.Entities;


using UnivaliMapas.Api.Models;
using UnivaliMapas.Features.Blocos.Queries.GetBloco;


namespace UnivaliMapas.Api.Profiles;

public class BlocoProfile : Profile
{
    public BlocoProfile()
    {
        CreateMap<Bloco, BlocoDto>();
        CreateMap<BlocoDto, Bloco>();
        
        //CQRS
        /*CreateMap<SalaForCreationDto, Sala>();
        CreateMap<Bloco, CreateBlocoDto>();

        CreateMap<Bloco, GetBlocoDetailDto>();

        CreateMap<SalaForCreationDto, Sala>();
        CreateMap<UpdateSalaCommand, Sala>();
        CreateMap<Sala, UpdateSalaCommandDto>();*/
    }
}