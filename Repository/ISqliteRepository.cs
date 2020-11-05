using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Repository
{
    public interface ISqliteRepository
    {
        Task<PersonTable> GetPerson(int id);
        Task<List<PersonTable>> GetAllPerson();
        Task SavePerson(PersonTable person);
        Task UpdatePerosn(PersonTable person);
        Task DeletePerson(int id);
    }
}