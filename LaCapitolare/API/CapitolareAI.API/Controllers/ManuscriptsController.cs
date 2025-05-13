// CapitolareAI.API/Controllers/ManuscriptsController.cs
using CapitolareAI.Core.DTOs;
using CapitolareAI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolareAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManuscriptsController : ControllerBase
    {
        private readonly IManuscriptRepository _manuscriptRepository;

        public ManuscriptsController(IManuscriptRepository manuscriptRepository)
        {
            _manuscriptRepository = manuscriptRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManuscriptDto>>> GetManuscripts()
        {
            var manuscripts = await _manuscriptRepository.GetAllAsync();

            var manuscriptDtos = manuscripts.Select(m => new ManuscriptDto
            {
                Id = m.Id,
                Title = m.Title,
                Period = m.Period,
                Description = m.Description,
                Condition = m.Condition,
                PreservationCost = m.PreservationCost,
                Categories = m.Categories?.Select(c => c.Category),
                StoryAngles = m.StoryAngles?.Select(sa => sa.StoryAngle)
            });

            return Ok(manuscriptDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManuscriptDto>> GetManuscript(int id)
        {
            var manuscript = await _manuscriptRepository.GetByIdAsync(id);

            if (manuscript == null)
            {
                return NotFound();
            }

            var manuscriptDto = new ManuscriptDto
            {
                Id = manuscript.Id,
                Title = manuscript.Title,
                Period = manuscript.Period,
                Description = manuscript.Description,
                Condition = manuscript.Condition,
                PreservationCost = manuscript.PreservationCost,
                Categories = manuscript.Categories?.Select(c => c.Category),
                StoryAngles = manuscript.StoryAngles?.Select(sa => sa.StoryAngle)
            };

            return Ok(manuscriptDto);
        }

        [HttpGet("{id}/matching-donors")]
        public async Task<ActionResult<IEnumerable<DonorMatchDto>>> GetMatchingDonors(int id)
        {
            var donors = await _manuscriptRepository.GetMatchingDonorsAsync(id);

            var donorMatchDtos = donors.Select(d =>
            {
                var manuscriptAffinity = d.Score.ManuscriptAffinities
                    .FirstOrDefault(ma => ma.ManuscriptId == id);

                var primaryInterest = d.Interests
                    .OrderByDescending(i => i.StrengthScore)
                    .FirstOrDefault()?.Category;

                return new DonorMatchDto
                {
                    DonorId = d.Id,
                    Name = $"{d.FirstName} {d.LastName}",
                    Location = d.Location,
                    PrimaryInterest = primaryInterest,
                    MatchScore = manuscriptAffinity?.AffinityScore ?? 0,
                    EstimatedCapacity = d.EstimatedCapacity,
                    PotentialDonation = d.Score.PredictedDonationAmount
                };
            });

            return Ok(donorMatchDtos);
        }
    }
}