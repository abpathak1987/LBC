// CapitolareAI.Infrastructure/Repositories/DonorRepository.cs
using CapitolareAI.Core.Entities;
using CapitolareAI.Core.Interfaces;
using CapitolareAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolareAI.Infrastructure.Repositories
{
    public class DonorRepository : Repository<Donor>, IDonorRepository
    {
        public DonorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Donor>> GetTopProspectsAsync(int count, int? manuscriptId = null)
        {
            IQueryable<Donor> query = _context.Donors
                .Include(d => d.Score)
                .Include(d => d.Interests);

            if (manuscriptId.HasValue)
            {
                query = query.Where(d => d.Score.ManuscriptAffinities
                    .Any(ma => ma.ManuscriptId == manuscriptId.Value))
                    .OrderByDescending(d => d.Score.ManuscriptAffinities
                        .First(ma => ma.ManuscriptId == manuscriptId.Value).AffinityScore);
            }
            else
            {
                query = query.OrderByDescending(d => d.Score.AffinityScore);
            }

            return await query.Take(count).ToListAsync();
        }
    }
}
