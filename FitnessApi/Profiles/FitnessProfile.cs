using AutoMapper;
using FitnessApi.Dtos.ActivitiesDto;
using FitnessApi.Dtos.EatingsDto;
using FitnessApi.Dtos.ExercisesDto;
using FitnessApi.Dtos.FoodsDto;
using FitnessApi.Dtos.GendersDto;
using FitnessApi.Dtos.UsersDto;
using FitnessApi.Dtos.VitaminsDto;
using FitnessApi.Models;
using System.Runtime.CompilerServices;

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

            CreateMap<Activity, ActivityReadDto>();

			#region Mapping the exercises dto objects
			CreateMap<Exercise, ExerciseReadDto>();
            CreateMap<ExerciseCreateDto, Exercise>();
			#endregion

			#region Mapping the foods dto objects
			CreateMap<Food, FoodWithoutVitaminsReadDto>();
            CreateMap<Food, FoodWithVitaminsReadDto>();
			#endregion

			CreateMap<FoodEating, FoodEatingReadDto>();

			//HACK: May be this mapping will change
			CreateMap<Eating, EatingReadDto>()
				.ForMember(dest => dest.FoodsAndPortion, opts => opts.MapFrom(y => y.FoodEatings.Where(f => f.EatingId == y.Id)));

			CreateMap<Vitamin, VitaminReadDto>();
		}
	}
}