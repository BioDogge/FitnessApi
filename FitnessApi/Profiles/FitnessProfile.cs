using AutoMapper;
using FitnessApi.Dtos.GendersDto;
using FitnessApi.Dtos.UsersDto;
using FitnessApi.Models;

namespace FitnessApi.Profiles
{
	public class FitnessProfile : Profile
	{
        public FitnessProfile()
        {
			#region Mapping the users dto objects
			CreateMap<User, UserShortInfoReadDto>();
            CreateMap<User, UserFullInfoReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
			#endregion

			CreateMap<Gender, GenderReadDto>();
        }
    }
}