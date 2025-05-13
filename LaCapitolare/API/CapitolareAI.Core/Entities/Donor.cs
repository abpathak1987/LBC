using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CapitolareAI.Core/Entities/Donor.cs
namespace CapitolareAI.Core.Entities
{
    public class Donor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ProfessionalBackground { get; set; }
        public decimal EstimatedCapacity { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public ICollection<DonorInterest> Interests { get; set; }
        public DonorScore Score { get; set; }
    }
}

// CapitolareAI.Core/Entities/DonorInterest.cs
namespace CapitolareAI.Core.Entities
{
    public class DonorInterest
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string Category { get; set; }
        public int StrengthScore { get; set; }

        // Navigation properties
        public Donor Donor { get; set; }
    }
}

// CapitolareAI.Core/Entities/Manuscript.cs
namespace CapitolareAI.Core.Entities
{
    public class Manuscript
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal PreservationCost { get; set; }

        // Navigation properties
        public ICollection<ManuscriptCategory> Categories { get; set; }
        public ICollection<ManuscriptStoryAngle> StoryAngles { get; set; }
        public ICollection<ManuscriptAffinity> DonorAffinities { get; set; }
    }
}

// CapitolareAI.Core/Entities/ManuscriptCategory.cs
namespace CapitolareAI.Core.Entities
{
    public class ManuscriptCategory
    {
        public int Id { get; set; }
        public int ManuscriptId { get; set; }
        public string Category { get; set; }

        // Navigation property
        public Manuscript Manuscript { get; set; }
    }
}

// CapitolareAI.Core/Entities/ManuscriptStoryAngle.cs
namespace CapitolareAI.Core.Entities
{
    public class ManuscriptStoryAngle
    {
        public int Id { get; set; }
        public int ManuscriptId { get; set; }
        public string StoryAngle { get; set; }

        // Navigation property
        public Manuscript Manuscript { get; set; }
    }
}

// Additional entity classes for categories, story angles, etc.

// CapitolareAI.Core/Entities/DonorScore.cs
namespace CapitolareAI.Core.Entities
{
    public class DonorScore
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public decimal AffinityScore { get; set; }
        public decimal CapacityScore { get; set; }
        public decimal EngagementProbability { get; set; }
        public decimal PredictedDonationAmount { get; set; }

        // Navigation properties
        public Donor Donor { get; set; }
        public ICollection<ManuscriptAffinity> ManuscriptAffinities { get; set; }
    }
}

// CapitolareAI.Core/Entities/ManuscriptAffinity.cs
namespace CapitolareAI.Core.Entities
{
    public class ManuscriptAffinity
    {
        public int Id { get; set; }
        public int DonorScoreId { get; set; }
        public int ManuscriptId { get; set; }
        public decimal AffinityScore { get; set; }

        // Navigation properties
        public DonorScore DonorScore { get; set; }
        public Manuscript Manuscript { get; set; }
    }
}
