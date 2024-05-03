using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Blocos.Commands.UpdateBloco;

public class UpdateBlocoCommandHandler : IRequestHandler<UpdateBlocoCommand, UpdateBlocoDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public UpdateBlocoCommandHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateBlocoDto> Handle(UpdateBlocoCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var blocoFromDatabase = await _repository.GetBlocoByIdAsync(request.BlocoID);

        if(blocoFromDatabase == null)
        {
            return new UpdateBlocoDto {Success = false};
        }
        _mapper.Map(request, blocoFromDatabase);

        await _repository.SaveChangesAsync();

        return new UpdateBlocoDto { Success = success };
    }
}