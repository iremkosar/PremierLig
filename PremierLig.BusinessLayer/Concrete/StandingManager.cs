using PremierLig.BusinessLayer.Abstract;
using PremierLig.DataAccessLayer.Context;
using PremierLig.DtoLayer.StandingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.BusinessLayer.Concrete
{
    public class StandingManager:IStandingService
    {
        private readonly PremierLigContext _context;

        public StandingManager(PremierLigContext context)
        {
            _context = context;
        }

        public List<ResultStandingDto> GetStandings()
        {
            var finishedFixtures = _context.Fixtures
                .Where(f => f.Status == 2)
                .ToList();

            var teams = _context.Teams.ToList();

            var standings = teams.Select(team =>
            {
                var homeMatches = finishedFixtures.Where(f => f.HomeTeamId == team.TeamId).ToList();
                var awayMatches = finishedFixtures.Where(f => f.AwayTeamId == team.TeamId).ToList();

                int played = homeMatches.Count + awayMatches.Count;

                int won = homeMatches.Count(f => f.HomeScore > f.AwayScore) +
                          awayMatches.Count(f => f.AwayScore > f.HomeScore);

                int drawn = homeMatches.Count(f => f.HomeScore == f.AwayScore) +
                            awayMatches.Count(f => f.AwayScore == f.HomeScore);

                int lost = played - won - drawn;

                int goalsFor = homeMatches.Sum(f => f.HomeScore ?? 0) +
                               awayMatches.Sum(f => f.AwayScore ?? 0);

                int goalsAgainst = homeMatches.Sum(f => f.AwayScore ?? 0) +
                                   awayMatches.Sum(f => f.HomeScore ?? 0);

                int points = (won * 3) + drawn;
                int goalDiff = goalsFor - goalsAgainst;

                var allMatches = finishedFixtures
                    .Where(f => f.HomeTeamId == team.TeamId || f.AwayTeamId == team.TeamId)
                    .OrderByDescending(f => f.MatchDate)
                    .Take(5)
                    .ToList();

                var form = allMatches.Select(f =>
                {
                    if (f.HomeTeamId == team.TeamId)
                        return f.HomeScore > f.AwayScore ? "W" : f.HomeScore == f.AwayScore ? "D" : "L";
                    else
                        return f.AwayScore > f.HomeScore ? "W" : f.AwayScore == f.HomeScore ? "D" : "L";
                }).ToList();

                return new ResultStandingDto
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    ShortName = team.ShortName,
                    LogoUrl = team.LogoUrl,
                    Played = played,
                    Won = won,
                    Drawn = drawn,
                    Lost = lost,
                    GoalsFor = goalsFor,
                    GoalsAgainst = goalsAgainst,
                    GoalDiff = goalDiff,
                    Points = points,
                    Form = form
                };
            })
            .OrderByDescending(x => x.Points)
            .ThenByDescending(x => x.GoalDiff)
            .ThenByDescending(x => x.GoalsFor)
            .ToList();

            return standings;
        }
    }
}
