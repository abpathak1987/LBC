// CapitolareAI.Core/Interfaces/IDonorRepository.cs
using CapitolareAI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapitolareAI.Core.Interfaces
{
    public interface IDonorRepository : IRepository<Donor>
    {
        Task<IEnumerable<Donor>> GetTopProspectsAsync(int count, int? manuscriptId = null);
    }
}