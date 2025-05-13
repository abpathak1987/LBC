// CapitolareAI.Infrastructure/Data/SeedData.cs
using CapitolareAI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CapitolareAI.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            // Seed Manuscripts
            var manuscripts = new List<Manuscript>
            {
                new Manuscript
                {
                    Id = 1,
                    Title = "Codex Veronensis",
                    Period = "6th Century",
                    Description = "One of the oldest surviving biblical manuscripts, contains rare passages of early Latin translations.",
                    Condition = "Fragile",
                    PreservationCost = 75000
                },
                new Manuscript
                {
                    Id = 2,
                    Title = "Archimedes Palimpsest",
                    Period = "10th Century",
                    Description = "Contains previously unknown works of Archimedes, overwritten by later religious texts.",
                    Condition = "Poor",
                    PreservationCost = 120000
                },
                new Manuscript
                {
                    Id = 3,
                    Title = "Dante's Divine Comedy First Edition",
                    Period = "14th Century",
                    Description = "Rare early manuscript of Dante's masterpiece with unique illustrations.",
                    Condition = "Good",
                    PreservationCost = 45000
                },
                new Manuscript
                {
                    Id = 4,
                    Title = "Breviarium Grimani",
                    Period = "15th Century",
                    Description = "Lavishly illustrated Flemish manuscript with exceptional detail and artistry.",
                    Condition = "Fair",
                    PreservationCost = 95000
                },
                new Manuscript
                {
                    Id = 5,
                    Title = "Verona Medical Codex",
                    Period = "12th Century",
                    Description = "Rare medical treatise combining Greek, Arabic and early Italian medical knowledge.",
                    Condition = "Poor",
                    PreservationCost = 85000
                }
            };

            // Seed Manuscript Categories
            var manuscriptCategories = new List<ManuscriptCategory>
            {
                new ManuscriptCategory { Id = 1, ManuscriptId = 1, Category = "Biblical" },
                new ManuscriptCategory { Id = 2, ManuscriptId = 1, Category = "Latin" },
                new ManuscriptCategory { Id = 3, ManuscriptId = 1, Category = "Early Christianity" },
                new ManuscriptCategory { Id = 4, ManuscriptId = 2, Category = "Mathematics" },
                new ManuscriptCategory { Id = 5, ManuscriptId = 2, Category = "Science" },
                new ManuscriptCategory { Id = 6, ManuscriptId = 2, Category = "Ancient Greece" },
                new ManuscriptCategory { Id = 7, ManuscriptId = 3, Category = "Literature" },
                new ManuscriptCategory { Id = 8, ManuscriptId = 3, Category = "Italian Renaissance" },
                new ManuscriptCategory { Id = 9, ManuscriptId = 3, Category = "Poetry" },
                new ManuscriptCategory { Id = 10, ManuscriptId = 4, Category = "Art" },
                new ManuscriptCategory { Id = 11, ManuscriptId = 4, Category = "Religious" },
                new ManuscriptCategory { Id = 12, ManuscriptId = 4, Category = "Illuminated Manuscript" },
                new ManuscriptCategory { Id = 13, ManuscriptId = 5, Category = "Medicine" },
                new ManuscriptCategory { Id = 14, ManuscriptId = 5, Category = "Science" },
                new ManuscriptCategory { Id = 15, ManuscriptId = 5, Category = "Medieval" }
            };

            // Seed Manuscript Story Angles
            var manuscriptStoryAngles = new List<ManuscriptStoryAngle>
            {
                new ManuscriptStoryAngle { Id = 1, ManuscriptId = 1, StoryAngle = "Biblical Heritage" },
                new ManuscriptStoryAngle { Id = 2, ManuscriptId = 1, StoryAngle = "Earliest Christian Writings" },
                new ManuscriptStoryAngle { Id = 3, ManuscriptId = 1, StoryAngle = "Linguistic Evolution" },
                new ManuscriptStoryAngle { Id = 4, ManuscriptId = 2, StoryAngle = "Scientific Discovery" },
                new ManuscriptStoryAngle { Id = 5, ManuscriptId = 2, StoryAngle = "Preservation Technology" },
                new ManuscriptStoryAngle { Id = 6, ManuscriptId = 2, StoryAngle = "Lost Knowledge" },
                new ManuscriptStoryAngle { Id = 7, ManuscriptId = 3, StoryAngle = "Italian Cultural Heritage" },
                new ManuscriptStoryAngle { Id = 8, ManuscriptId = 3, StoryAngle = "Literary Milestone" },
                new ManuscriptStoryAngle { Id = 9, ManuscriptId = 3, StoryAngle = "Artistic Collaboration" },
                new ManuscriptStoryAngle { Id = 10, ManuscriptId = 4, StoryAngle = "Artistic Excellence" },
                new ManuscriptStoryAngle { Id = 11, ManuscriptId = 4, StoryAngle = "Religious Devotion" },
                new ManuscriptStoryAngle { Id = 12, ManuscriptId = 4, StoryAngle = "Cultural Exchange" },
                new ManuscriptStoryAngle { Id = 13, ManuscriptId = 5, StoryAngle = "Medical History" },
                new ManuscriptStoryAngle { Id = 14, ManuscriptId = 5, StoryAngle = "Cross-Cultural Knowledge" },
                new ManuscriptStoryAngle { Id = 15, ManuscriptId = 5, StoryAngle = "Scientific Preservation" }
            };

            // Seed Donors
            var donors = new List<Donor>
            {
                new Donor
                {
                    Id = 1,
                    FirstName = "Eleanor",
                    LastName = "Hughes",
                    Email = "e.hughes@example.com",
                    Location = "Boston, MA",
                    ProfessionalBackground = "Professor of Medieval Literature",
                    EstimatedCapacity = 50000,
                    CreatedDate = new DateTime(2024, 7, 27)
                },
                new Donor
                {
                    Id = 2,
                    FirstName = "Michael",
                    LastName = "Chen",
                    Email = "m.chen@example.com",
                    Location = "San Francisco, CA",
                    ProfessionalBackground = "Tech Executive",
                    EstimatedCapacity = 200000,
                    CreatedDate = new DateTime(2023, 6, 20)
                },
                new Donor
                {
                    Id = 3,
                    FirstName = "Sophia",
                    LastName = "Lombardi",
                    Email = "s.lombardi@example.com",
                    Location = "New York, NY",
                    ProfessionalBackground = "Art Collector",
                    EstimatedCapacity = 150000,
                    CreatedDate = new DateTime(2021, 3, 12)
                },
                new Donor
                {
                    Id = 4,
                    FirstName = "Robert",
                    LastName = "Johnson",
                    Email = "r.johnson@example.com",
                    Location = "Chicago, IL",
                    ProfessionalBackground = "Pharmaceutical Executive",
                    EstimatedCapacity = 100000,
                    CreatedDate = new DateTime(2022, 4, 11)
                },
                new Donor
                {
                    Id = 5,
                    FirstName = "Julia",
                    LastName = "Reed",
                    Email = "j.reed@example.com",
                    Location = "Washington, DC",
                    ProfessionalBackground = "Religious Studies Professor",
                    EstimatedCapacity = 30000,
                    CreatedDate = new DateTime(2023, 1, 12)
                }
            };

            // Seed Donor Interests
            var donorInterests = new List<DonorInterest>
            {
                new DonorInterest { Id = 1, DonorId = 1, Category = "Medieval Literature", StrengthScore = 9 },
                new DonorInterest { Id = 2, DonorId = 1, Category = "Preservation", StrengthScore = 7 },
                new DonorInterest { Id = 3, DonorId = 1, Category = "Italian Culture", StrengthScore = 8 },
                new DonorInterest { Id = 4, DonorId = 2, Category = "Digital Preservation", StrengthScore = 9 },
                new DonorInterest { Id = 5, DonorId = 2, Category = "Ancient Science", StrengthScore = 8 },
                new DonorInterest { Id = 6, DonorId = 2, Category = "Technology History", StrengthScore = 7 },
                new DonorInterest { Id = 7, DonorId = 3, Category = "Italian Renaissance", StrengthScore = 9 },
                new DonorInterest { Id = 8, DonorId = 3, Category = "Art History", StrengthScore = 9 },
                new DonorInterest { Id = 9, DonorId = 3, Category = "Religious Art", StrengthScore = 6 },
                new DonorInterest { Id = 10, DonorId = 4, Category = "Medical History", StrengthScore = 8 },
                new DonorInterest { Id = 11, DonorId = 4, Category = "Ancient Science", StrengthScore = 7 },
                new DonorInterest { Id = 12, DonorId = 4, Category = "Rare Books", StrengthScore = 5 },
                new DonorInterest { Id = 13, DonorId = 5, Category = "Early Christianity", StrengthScore = 9 },
                new DonorInterest { Id = 14, DonorId = 5, Category = "Biblical Studies", StrengthScore = 9 },
                new DonorInterest { Id = 15, DonorId = 5, Category = "Ancient Languages", StrengthScore = 7 }
            };

            // Seed Donor Scores
            var donorScores = new List<DonorScore>
            {
                new DonorScore
                {
                    Id = 1,
                    DonorId = 1,
                    AffinityScore = 8.5m,
                    CapacityScore = 7.2m,
                    EngagementProbability = 0.75m,
                    PredictedDonationAmount = 15000
                },
                new DonorScore
                {
                    Id = 2,
                    DonorId = 2,
                    AffinityScore = 7.8m,
                    CapacityScore = 9.0m,
                    EngagementProbability = 0.65m,
                    PredictedDonationAmount = 25000
                },
                new DonorScore
                {
                    Id = 3,
                    DonorId = 3,
                    AffinityScore = 8.2m,
                    CapacityScore = 8.7m,
                    EngagementProbability = 0.82m,
                    PredictedDonationAmount = 30000
                },
                new DonorScore
                {
                    Id = 4,
                    DonorId = 4,
                    AffinityScore = 7.1m,
                    CapacityScore = 8.3m,
                    EngagementProbability = 0.60m,
                    PredictedDonationAmount = 18000
                },
                new DonorScore
                {
                    Id = 5,
                    DonorId = 5,
                    AffinityScore = 8.9m,
                    CapacityScore = 6.1m,
                    EngagementProbability = 0.88m,
                    PredictedDonationAmount = 12000
                }
            };

            // Seed Manuscript Affinities
            var manuscriptAffinities = new List<ManuscriptAffinity>
            {
                new ManuscriptAffinity { Id = 1, DonorScoreId = 1, ManuscriptId = 3, AffinityScore = 9.1m },
                new ManuscriptAffinity { Id = 2, DonorScoreId = 1, ManuscriptId = 1, AffinityScore = 7.8m },
                new ManuscriptAffinity { Id = 3, DonorScoreId = 1, ManuscriptId = 4, AffinityScore = 6.5m },
                new ManuscriptAffinity { Id = 4, DonorScoreId = 2, ManuscriptId = 2, AffinityScore = 8.9m },
                new ManuscriptAffinity { Id = 5, DonorScoreId = 2, ManuscriptId = 5, AffinityScore = 7.2m },
                new ManuscriptAffinity { Id = 6, DonorScoreId = 2, ManuscriptId = 1, AffinityScore = 4.3m },
                new ManuscriptAffinity { Id = 7, DonorScoreId = 3, ManuscriptId = 4, AffinityScore = 9.3m },
                new ManuscriptAffinity { Id = 8, DonorScoreId = 3, ManuscriptId = 3, AffinityScore = 8.7m },
                new ManuscriptAffinity { Id = 9, DonorScoreId = 3, ManuscriptId = 2, AffinityScore = 3.5m },
                new ManuscriptAffinity { Id = 10, DonorScoreId = 4, ManuscriptId = 5, AffinityScore = 9.0m },
                new ManuscriptAffinity { Id = 11, DonorScoreId = 4, ManuscriptId = 2, AffinityScore = 6.8m },
                new ManuscriptAffinity { Id = 12, DonorScoreId = 4, ManuscriptId = 1, AffinityScore = 4.1m },
                new ManuscriptAffinity { Id = 13, DonorScoreId = 5, ManuscriptId = 1, AffinityScore = 9.5m },
                new ManuscriptAffinity { Id = 14, DonorScoreId = 5, ManuscriptId = 4, AffinityScore = 7.2m },
                new ManuscriptAffinity { Id = 15, DonorScoreId = 5, ManuscriptId = 3, AffinityScore = 4.8m }
            };

            // Configure entity seeding
            modelBuilder.Entity<Manuscript>().HasData(manuscripts);
            modelBuilder.Entity<ManuscriptCategory>().HasData(manuscriptCategories);
            modelBuilder.Entity<ManuscriptStoryAngle>().HasData(manuscriptStoryAngles);
            modelBuilder.Entity<Donor>().HasData(donors);
            modelBuilder.Entity<DonorInterest>().HasData(donorInterests);
            modelBuilder.Entity<DonorScore>().HasData(donorScores);
            modelBuilder.Entity<ManuscriptAffinity>().HasData(manuscriptAffinities);
        }
    }
}