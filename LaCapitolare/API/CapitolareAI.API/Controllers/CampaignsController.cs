// CapitolareAI.API/Controllers/CampaignsController.cs
using CapitolareAI.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapitolareAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        [HttpPost("simulate")]
        public ActionResult<SimulationResultDto> SimulateCampaign(SimulationParametersDto parameters)
        {
            // This would normally use a service to run the simulation
            // For our pretotype, we'll generate simulated data

            var random = new Random();

            // Create simulated weekly donations
            var weeklyDonations = new List<decimal>();
            var weeksCount = (int)Math.Ceiling(parameters.Duration / 7.0);

            var baseWeeklyAmount = parameters.GoalAmount / weeksCount;

            // Simulate AI optimization improvement
            var optimizationFactor = parameters.UseAiOptimization ? 1.35m : 1.0m;

            // Simulate different weekly patterns
            for (int i = 0; i < weeksCount; i++)
            {
                // Early weeks have less donations, middle weeks peak, late weeks taper
                var weekPosition = (float)i / weeksCount;
                var weekFactor = (float)Math.Sin(weekPosition * Math.PI) * 1.5f + 0.5f;

                var weekAmount = baseWeeklyAmount * (decimal)weekFactor * optimizationFactor;

                // Add some randomness
                weekAmount *= (decimal)(0.9 + random.NextDouble() * 0.2);

                weeklyDonations.Add(Math.Round(weekAmount, 2));
            }

            // Calculate totals
            var totalDonations = weeklyDonations.Sum();

            // Segment distribution
            var segmentDistribution = new Dictionary<string, decimal>();

            if (parameters.SegmentFocus == "all")
            {
                segmentDistribution.Add("Academics", Math.Round(totalDonations * 0.25m, 2));
                segmentDistribution.Add("Art Collectors", Math.Round(totalDonations * 0.2m, 2));
                segmentDistribution.Add("Religious Scholars", Math.Round(totalDonations * 0.15m, 2));
                segmentDistribution.Add("Medical Professionals", Math.Round(totalDonations * 0.1m, 2));
                segmentDistribution.Add("Tech Leaders", Math.Round(totalDonations * 0.3m, 2));
            }
            else
            {
                // If a specific segment is focused, it gets the majority
                segmentDistribution.Add(parameters.SegmentFocus, Math.Round(totalDonations * 0.7m, 2));
                segmentDistribution.Add("Other Segments", Math.Round(totalDonations * 0.3m, 2));
            }

            // Simulate conversion rate based on AI optimization
            var baseConversionRate = 0.03m;
            var conversionRate = parameters.UseAiOptimization
                ? baseConversionRate * 1.5m
                : baseConversionRate;

            // Simulate ROI based on goal amount and duration
            var campaignCost = parameters.GoalAmount * 0.1m;
            var roi = totalDonations / campaignCost;

            // Determine average donation
            var donorCount = (int)(totalDonations / 250);
            var avgDonation = totalDonations / donorCount;

            // AI insights based on parameters
            var contentStrategy = GetContentStrategy(parameters);
            var timingStrategy = GetTimingStrategy(parameters);
            var topSegment = GetTopSegment(parameters);
            var followupStrategy = GetFollowupStrategy(parameters);

            var result = new SimulationResultDto
            {
                TotalDonations = totalDonations,
                AverageDonation = Math.Round(avgDonation, 2),
                ConversionRate = conversionRate,
                RoiRatio = Math.Round(roi, 1),
                WeeklyDonations = weeklyDonations,
                SegmentDistribution = segmentDistribution,
                Insights = new SimulationInsightsDto
                {
                    ContentStrategy = contentStrategy,
                    TimingStrategy = timingStrategy,
                    TopSegment = topSegment,
                    FollowupStrategy = followupStrategy
                }
            };

            return Ok(result);
        }

        private string GetContentStrategy(SimulationParametersDto parameters)
        {
            if (parameters.ContentApproach == "story")
            {
                return "Focus on storytelling that connects donors emotionally to the manuscripts. Emphasize the historical journey and cultural significance.";
            }
            else if (parameters.ContentApproach == "research")
            {
                return "Highlight the academic and research value of the manuscripts. Include testimonials from scholars about their significance.";
            }
            else if (parameters.ContentApproach == "preservation")
            {
                return "Emphasize the urgent preservation needs. Include before/after examples of restoration work and the risks of deterioration.";
            }
            else
            {
                return "Create content that balances historical significance with the transformative impact of preservation on future generations.";
            }
        }

        private string GetTimingStrategy(SimulationParametersDto parameters)
        {
            if (parameters.Duration <= 30)
            {
                return "For this short campaign, frontload communications with high-impact messaging in the first 10 days to build momentum.";
            }
            else if (parameters.Duration <= 60)
            {
                return "Implement a three-phase approach with launch, mid-campaign boost, and final push. Schedule major donor outreach during weeks 2-4.";
            }
            else
            {
                return "For this extended campaign, pace communications with weekly updates. Schedule targeted follow-ups every 14 days to maintain engagement.";
            }
        }

        private string GetTopSegment(SimulationParametersDto parameters)
        {
            if (parameters.ManuscriptFocus == 1 || parameters.ManuscriptFocus == 4)
            {
                return "Religious Scholars showed highest response rate (8.2%). Target follow-up communications to this segment with Biblical heritage messaging.";
            }
            else if (parameters.ManuscriptFocus == 2 || parameters.ManuscriptFocus == 5)
            {
                return "Academic and Medical professionals showed highest engagement (7.5%). Focus on research value and historical significance.";
            }
            else
            {
                return "Tech Leaders showed unexpectedly strong interest (9.1%). Their giving capacity makes them ideal for major gift cultivation.";
            }
        }

        private string GetFollowupStrategy(SimulationParametersDto parameters)
        {
            return "Personalized thank-you messages within 48 hours of donation. For donations over $500, offer virtual tour of manuscript preservation process. Schedule update on progress at campaign midpoint.";
        }
    }
}