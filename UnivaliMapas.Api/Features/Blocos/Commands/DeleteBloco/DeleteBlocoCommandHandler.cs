using AutoMapper;
using MediatR;
using UnivaliMapas.Api.Repositories;

namespace UnivaliMapas.Features.Blocos.Commands.DeleteBloco;

public class DeleteBlocoCommandHandler : IRequestHandler<DeleteBlocoCommand, DeleteBlocoDto>
{
    private readonly IUnivaliRepository _repository;
    private readonly IMapper _mapper;

    public DeleteBlocoCommandHandler(IUnivaliRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DeleteBlocoDto> Handle(DeleteBlocoCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var blocoFromDatabase = await _repository.GetBlocoByIdAsync(request.BlocoID);

        if (blocoFromDatabase != null) {
            _repository.DeleteBloco(blocoFromDatabase);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new DeleteBlocoDto { Success = success };
    }
}