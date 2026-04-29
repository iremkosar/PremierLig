using AutoMapper;
using PremierLig.DtoLayer.FixtureDtos;
using PremierLig.DtoLayer.LeagueDto;
using PremierLig.DtoLayer.MatchDetailDtos;
using PremierLig.DtoLayer.MatchStatisticDtos;
using PremierLig.DtoLayer.SeasonDtos;
using PremierLig.DtoLayer.StadiumDto;
using PremierLig.DtoLayer.TeamDtos;
using PremierLig.EntityLayer.Entities;

namespace PremierLig.BusinessLayer.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Team, ResultTeamDto>().ReverseMap();
            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();
            CreateMap<Team, GetByIdTeamDto>().ReverseMap();

          
            CreateMap<Fixture, ResultFixtureDto>().ReverseMap();
            CreateMap<Fixture, CreateFixtureDto>().ReverseMap();
            CreateMap<Fixture, UpdateFixtureDto>().ReverseMap();
            CreateMap<Fixture, GetByIdFixtureDto>().ReverseMap();

           
            CreateMap<MatchDetail, ResultMatchDetailDto>().ReverseMap();
            CreateMap<MatchDetail, CreateMatchDetailDto>().ReverseMap();
            CreateMap<MatchDetail, UpdateMatchDetailDto>().ReverseMap();
            CreateMap<MatchDetail, GetByIdMatchDetailDto>().ReverseMap();

           
            CreateMap<MatchStatistic, ResultMatchStatisticDto>().ReverseMap();
            CreateMap<MatchStatistic, CreateMatchStatisticDto>().ReverseMap();
            CreateMap<MatchStatistic, UpdateMatchStatisticDto>().ReverseMap();
            CreateMap<MatchStatistic, GetByIdMatchStatisticDto>().ReverseMap();
            
            CreateMap<League, ResultLeagueDto>().ReverseMap();
            CreateMap<League, CreateLeagueDto>().ReverseMap();
            CreateMap<League, UpdateLeagueDto>().ReverseMap();

          
            CreateMap<Stadium, ResultStadiumDto>().ReverseMap();
            CreateMap<Stadium, CreateStadiumDto>().ReverseMap();
            CreateMap<Stadium, UpdateStadiumDto>().ReverseMap();

           
            CreateMap<Season, ResultSeasonDto>().ReverseMap();
            CreateMap<Season, CreateSeasonDto>().ReverseMap();
            CreateMap<Season, UpdateSeasonDto>().ReverseMap();
        }
    }
}
