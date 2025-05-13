// CapitolareAI.API/Controllers/DonorsController.cs
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
    public class DonorsController : ControllerBase
    {
        private readonly IDonorRepository _donorRepository;

        public DonorsController(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorDto>>> GetDonors()
        {
            var donors = await _donorRepository.GetAllAsync();

            var donorDtos = donors.Select(d => new DonorDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                Location = d.Location,
                ProfessionalBackground = d.ProfessionalBackground,
                EstimatedCapacity = d.EstimatedCapacity,
                Interests = d.Interests?.Select(i => i.Category)
            });

            return Ok(donorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DonorDto>> GetDonor(int id)
        {
            var donor = await _donorRepository.GetByIdAsync(id);

            if (donor == null)
            {
                return NotFound();
            }

            var donorDto = new DonorDto
            {
                Id = donor.Id,
                FirstName = donor.FirstName,
                LastName = donor.LastName,
                Email = donor.Email,
                Location = donor.Location,
                ProfessionalBackground = donor.ProfessionalBackground,
                EstimatedCapacity = donor.EstimatedCapacity,
                Interests = donor.Interests?.Select(i => i.Category)
            };

            return Ok(donorDto);
        }

        [HttpGet("top-prospects")]
        public async Task<ActionResult<IEnumerable<DonorDto>>> GetTopProspects([FromQuery] int count = 10, [FromQuery] int? manuscriptId = null)
        {
            var donors = await _donorRepository.GetTopProspectsAsync(count, manuscriptId);

            var donorDtos = donors.Select(d => new DonorDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                Location = d.Location,
                ProfessionalBackground = d.ProfessionalBackground,
                EstimatedCapacity = d.EstimatedCapacity,
                Interests = d.Interests?.Select(i => i.Category)
            });

            return Ok(donorDtos);
        }

        [HttpGet("{id}/score")]
        public async Task<ActionResult<DonorScoreDto>> GetDonorScore(int id)
        {
            var donor = await _donorRepository.GetByIdAsync(id);

            if (donor == null || donor.Score == null)
            {
                return NotFound();
            }

            var bestManuscriptAffinity = donor.Score.ManuscriptAffinities
                .OrderByDescending(ma => ma.AffinityScore)
                .FirstOrDefault();

            var donorScoreDto = new DonorScoreDto
            {
                Id = donor.Score.Id,
                DonorId = donor.Id,
                DonorName = $"{donor.FirstName} {donor.LastName}",
                AffinityScore = donor.Score.AffinityScore,
                CapacityScore = donor.Score.CapacityScore,
                EngagementProbability = donor.Score.EngagementProbability,
                PredictedDonationAmount = donor.Score.PredictedDonationAmount,
                BestManuscriptMatch = bestManuscriptAffinity?.Manuscript?.Title,
                ManuscriptAffinities = donor.Score.ManuscriptAffinities?.Select(ma => new ManuscriptAffinityDto
                {
                    ManuscriptId = ma.ManuscriptId,
                    ManuscriptTitle = ma.Manuscript?.Title,
                    AffinityScore = ma.AffinityScore
                })
            };

            return Ok(donorScoreDto);
        }
    }
}