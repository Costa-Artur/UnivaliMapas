using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Usuarios.Queries.GetUsersDetail;

public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, GetUserDetailDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;
    
    public GetUserDetailQueryHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<GetUserDetailDto> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        var userFromDatabase = await _repository.GetUserByCodigoAsync(request.CodigoPessoa);
        return _mapper.Map<GetUserDetailDto>(userFromDatabase);
    }
}