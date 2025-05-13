// CapitolareAI.Core/DTOs/DonorDto.cs
namespace CapitolareAI.Core.DTOs
{
    public class DonorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Location { get; set; }
        public string ProfessionalBackground { get; set; }
        public decimal EstimatedCapacity { get; set; }
        public IEnumerable<string> Interests { get; set; }
    }
}

// CapitolareAI.Core/DTOs/DonorScoreDto.cs
namespace CapitolareAI.Core.DTOs
{
    public class DonorScoreDto
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string DonorName { get; set; }
        public decimal AffinityScore { get; set; }
        public decimal CapacityScore { get; set; }
        public decimal EngagementProbability { get; set; }
        public decimal PredictedDonationAmount { get; set; }
        public string BestManuscriptMatch { get; set; }
        public IEnumerable<ManuscriptAffinityDto> ManuscriptAffinities { get; set; }
    }
}

// CapitolareAI.Core/DTOs/ManuscriptAffinityDto.cs
namespace CapitolareAI.Core.DTOs
{
    public class ManuscriptAffinityDto
    {
        public int ManuscriptId { get; set; }
        public string ManuscriptTitle { get; set; }
        public decimal AffinityScore { get; set; }
    }
}

// CapitolareAI.Core/DTOs/ManuscriptDto.cs
namespace CapitolareAI.Core.DTOs
{
    public class ManuscriptDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal PreservationCost { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> StoryAngles { get; set; }
    }
}

// CapitolareAI.Core/DTOs/DonorMatchDto.cs
namespace CapitolareAI.Core.DTOs
{
    public class DonorMatchDto
    {
        public int DonorId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PrimaryInterest { get; set; }
        public decimal MatchScore { get; set; }
        public decimal EstimatedCapacity { get; set; }
        public decimal PotentialDonation { get; set; }
    }
}

// CapitolareAI.Core/DTOs/SimulationParametersDto.cs
namespace CapitolareAI.Core.DTOs
{
    public class SimulationParametersDto
    {
        public string CampaignName { get; set; }
        public decimal GoalAmount { get; set; }
        public int Duration { get; set; }
        public string SegmentFocus { get; set; }
        public int? ManuscriptFocus { get; set; }
        public string ContentApproach { get; set; }
        public bool UseAiOptimization { get; set; }
    }
}

// CapitolareAI.Core/DTOs/SimulationResultDto.cs
namespace CapitolareAI.Core.DTOs
{
    public class SimulationResultDto
    {
        public decimal TotalDonations { get; set; }
        public decimal AverageDonation { get; set; }
        public decimal ConversionRate { get; set; }
        public decimal RoiRatio { get; set; }
        public IEnumerable<decimal> WeeklyDonations { get; set; }
        public Dictionary<string, decimal> SegmentDistribution { get; set; }
        public SimulationInsightsDto Insights { get; set; }
    }
}

// CapitolareAI.Core/DTOs/SimulationInsightsDto.cs
namespace CapitolareAI.Core.DTOs
{
    public class SimulationInsightsDto
    {
        public string ContentStrategy { get; set; }
        public string TimingStrategy { get; set; }
        public string TopSegment { get; set; }
        public string FollowupStrategy { get; set; }
    }
}