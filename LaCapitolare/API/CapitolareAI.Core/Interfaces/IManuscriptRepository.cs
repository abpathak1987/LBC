// CapitolareAI.Core/Interfaces/IManuscriptRepository.cs
using CapitolareAI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapitolareAI.Core.Interfaces
{
    public interface IManuscriptRepository : IRepository<Manuscript>
    {
        Task<IEnumerable<Donor>> GetMatchingDonorsAsync(int manuscriptId);
    }
}