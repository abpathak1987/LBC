// CapitolareAI.Infrastructure/Repositories/ManuscriptRepository.cs
using CapitolareAI.Core.Entities;
using CapitolareAI.Core.Interfaces;
using CapitolareAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolareAI.Infrastructure.Repositories
{
    public class ManuscriptRepository : Repository<Manuscript>, IManuscriptRepository
    {
        public ManuscriptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Donor>> GetMatchingDonorsAsync(int manuscriptId)
        {
            return await _context.Donors
                .Include(d => d.Score)
                .Include(d => d.Interests)
                .Where(d => d.Score.ManuscriptAffinities
                    .Any(ma => ma.ManuscriptId == manuscriptId))
                .OrderByDescending(d => d.Score.ManuscriptAffinities
                    .First(ma => ma.ManuscriptId == manuscriptId).AffinityScore)
                .ToListAsync();
        }
    }
}