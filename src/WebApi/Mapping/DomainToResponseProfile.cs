using AutoMapper;
using Core.Domain;
using WebApi.Contracts.Responses;

namespace WebApi.Mapping;

public class DomainToResponseProfile : Profile
{
    public DomainToResponseProfile()
    {
        CreateMap<Exercise, ExerciseResponse>();
        CreateMap<Workout, WorkoutResponse>();
    }
}