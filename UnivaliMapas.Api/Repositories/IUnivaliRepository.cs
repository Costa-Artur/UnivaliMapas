using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Api.Repositories;

public interface IUnivaliRepository
{
    Task<Sala?> GetSalaByIdAsync(int salaId);
    void AddSala(Sala sala);
    Task<bool> SaveChangesAsync();
}