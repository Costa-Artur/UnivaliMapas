using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Models;

namespace UnivaliMapas.Api.Repositories;

public interface IUnivaliRepository
{
    Task<Sala?> GetSalaByIdAsync(int salaId);
    Task<Bloco?> GetBlocoByIdAsync(int blocoId);
    Task<Bloco?> GetBlocoWithSalaByIdAsync(int blocoId);
    void DeleteSala(Sala sala);
    void AddSala(Sala sala);
    Task<bool> SaveChangesAsync();
    void UpdateSala(Sala sala, SalaForUpdateDto salaForUpdateDto);
}