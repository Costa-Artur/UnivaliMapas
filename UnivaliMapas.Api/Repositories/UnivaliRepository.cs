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
    
    public async Task<Sala?> GetSalaByIdAsync(int blocoId, int salaId)
    {
        var blocoFromDatabase = await GetBlocoWithSalaByIdAsync(blocoId);
        var salaFromDatabase = blocoFromDatabase
            ?.Salas
            .FirstOrDefault(s => s.SalaId == salaId);

        return salaFromDatabase;
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
   
    public async Task<Bloco?> GetBlocoByIdAsync(int blocoId) {
        return await _context.Blocos
            .FirstOrDefaultAsync(b => b.BlocoID == blocoId);
    }

    public async Task<Bloco?> GetBlocoWithSalaByIdAsync(int blocoId) {
        return await _context.Blocos
            .Include(b => b.Salas)
            .FirstOrDefaultAsync(b => b.BlocoID == blocoId);
    }
    
    public void AddBloco(Bloco bloco) {
        _context.Blocos.Add(bloco);
    }

    public void DeleteBloco(Bloco bloco)
    {
        _context.Blocos.Remove(bloco);
    }

    public void UpdateBloco(Bloco bloco, BlocoForUpdateDto blocoForUpdateDto)
    {
        _mapper.Map(blocoForUpdateDto, bloco);
    }
}