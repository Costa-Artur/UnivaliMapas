using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Api.Repositories;

public interface IUnivaliRepository
{
    Task<Sala?> GetSalaByIdAsync(int blocoID, int salaId);
    
    void DeleteSala(Sala sala);
    void AddSala(Sala sala);
    Task<bool> SaveChangesAsync();
    void UpdateSala(Sala sala, SalaForUpdateDto salaForUpdateDto);
    Task<Bloco?> GetBlocoByIdAsync(int blocoId);
    Task<Bloco?> GetBlocoWithSalaByIdAsync(int blocoId);
    void AddBloco (Bloco bloco);
    void DeleteBloco(Bloco bloco);
    void UpdateBloco(Bloco bloco, BlocoForUpdateDto blocoForUpdate);
}