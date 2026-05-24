using AutoMapper;
using GoalZonePremierLig.Web.Api.Dtos.TeamsDto;
using GoalZonePremierLig.Web.Api.Dtos.PlayersDto;
using GoalZonePremierLig.Web.Api.Entities;
using GoalZonePremierLig.Web.Api.Dtos.StandingDto;
using GoalZonePremierLig.Web.Api.Dtos.MatchDto;
using GoalZonePremierLig.Web.Api.Dtos.MatchEventsDto;
using GoalZonePremierLig.Web.Api.Dtos.FixtureDtos;

namespace GoalZonePremierLig.Web.Api.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Team, ResultTeamDto>();
            CreateMap<Team, GetByIdTeamDto>();

            CreateMap<Player, ResultPlayerDto>();

            CreateMap<Standing, ResultStandingDto>()
                .ForMember(d => d.TeamName, s => s.MapFrom(x => x.Team.Name))
                .ForMember(d => d.ShortName, s => s.MapFrom(x => x.Team.ShortName))
                .ForMember(d => d.LogoUrl, s => s.MapFrom(x => x.Team.LogoUrl));

            CreateMap<Standing, GetByIdStandingDto>()
                .ForMember(d => d.TeamName, s => s.MapFrom(x => x.Team.Name))
                .ForMember(d => d.LogoUrl, s => s.MapFrom(x => x.Team.LogoUrl));

            CreateMap<Fixture, ResultMatchDto>()
                .ForMember(d => d.HomeTeam, s => s.MapFrom(x => x.HomeTeam.Name))
                .ForMember(d => d.AwayTeam, s => s.MapFrom(x => x.AwayTeam.Name))
                .ForMember(d => d.HomeTeamLogoUrl, s => s.MapFrom(x => x.HomeTeam.LogoUrl))
                .ForMember(d => d.AwayTeamLogoUrl, s => s.MapFrom(x => x.AwayTeam.LogoUrl));

            CreateMap<Fixture, GetByIdMatchDto>()
                .ForMember(d => d.HomeTeam, s => s.MapFrom(x => x.HomeTeam.Name))
                .ForMember(d => d.AwayTeam, s => s.MapFrom(x => x.AwayTeam.Name))
                .ForMember(d => d.HomeTeamLogoUrl, s => s.MapFrom(x => x.HomeTeam.LogoUrl))
                .ForMember(d => d.AwayTeamLogoUrl, s => s.MapFrom(x => x.AwayTeam.LogoUrl));

            CreateMap<Fixture, ResultDetailMatchDto>()
                .ForMember(d => d.HomeTeam, s => s.MapFrom(x => x.HomeTeam.Name))
                .ForMember(d => d.AwayTeam, s => s.MapFrom(x => x.AwayTeam.Name))
                .ForMember(d => d.HomeTeamLogoUrl, s => s.MapFrom(x => x.HomeTeam.LogoUrl))
                .ForMember(d => d.AwayTeamLogoUrl, s => s.MapFrom(x => x.AwayTeam.LogoUrl));


            CreateMap<MatchEvents, ResultEventsDto>()
                .ForMember(d => d.TeamName, s => s.MapFrom(x => x.Team.Name))
                .ForMember(d => d.TeamLogoUrl, s => s.MapFrom(x => x.Team.LogoUrl))
                .ForMember(d => d.PlayerName, s => s.MapFrom(x => x.Player.NameSurname))
                .ForMember(d => d.PlayerImageUrl, s => s.MapFrom(x => x.Player.ImageUrl));

            CreateMap<MatchEvents, GetByIdMatchEventsDto>();

            CreateMap<Fixture, ResultFixtureDto>()
                .ForMember(d => d.HomeTeam, s => s.MapFrom(x => x.HomeTeam.Name))
                .ForMember(d => d.HomeLogoUrl, s => s.MapFrom(x => x.HomeTeam.LogoUrl))
                .ForMember(d => d.AwayTeam, s => s.MapFrom(x => x.AwayTeam.Name))
                .ForMember(d => d.AwayLogoUrl, s => s.MapFrom(x => x.AwayTeam.LogoUrl));

            CreateMap<Fixture, FeaturedDto>()
                .ForMember(d => d.HomeTeam, s => s.MapFrom(x => x.HomeTeam.Name))
                .ForMember(d => d.HomeLogoUrl, s => s.MapFrom(x => x.HomeTeam.LogoUrl))
                .ForMember(d => d.AwayTeam, s => s.MapFrom(x => x.AwayTeam.Name))
                .ForMember(d => d.AwayLogoUrl, s => s.MapFrom(x => x.AwayTeam.LogoUrl));

            CreateMap<Fixture, ResultFixtureLiveDto>()
                .ForMember(d => d.HomeTeam, s => s.MapFrom(x => x.HomeTeam.Name))
                .ForMember(d => d.AwayTeam, s => s.MapFrom(x => x.AwayTeam.Name))
                .ForMember(d => d.HomeScore, s => s.MapFrom(x => x.HomeScore ?? 0))
                .ForMember(d => d.AwayScore, s => s.MapFrom(x => x.AwayScore ?? 0));
        }

    }
}

