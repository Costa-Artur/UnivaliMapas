using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.DbContexts;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Api.Repositories;

public class UnivaliRepository : IUnivaliRepository
{
    
    //Injeção de dependência
    private readonly UnivaliContext _context;
    private readonly IMapper _mapper;
    private IUnivaliRepository _univaliRepositoryImplementation;

    public UnivaliRepository(UnivaliContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Sala?> GetSalaByIdAsync(int salaId)
    {
        return await _context.Salas.FirstOrDefaultAsync(s => s.SalaId == salaId);
    }

    public async void AddSala(Sala sala)
    {
        _context.Salas.Add(sala);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public void DeleteSala(Sala sala)
    {
        _context.Salas.Remove(sala);
    }
    
   public void UpdateSala(Sala sala, SalaForUpdateDto salaForUpdateDto) {
        _mapper.Map(salaForUpdateDto, sala);
    }
}