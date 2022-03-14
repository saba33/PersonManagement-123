using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Domain.POCO;
using PersonManagement.Services.Models;
using PersonManagement.Services.Models.User;
using PersonManagement.Web.Models.DTO;
using PersonManagement.Web.Models.Requests;
using PersonManagement.Web.Models.Requests.Account;

namespace PersonManagement.Web.Infrastracture.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection service)
        {
           

            
            TypeAdapterConfig<PersonDTO, PersonServiceModel>
           .NewConfig()
           .Map(dest => dest.City, src => new CityServiceModel { Name = src.CityName })
           .Map(dest => dest.PersonIdentifier, src => src.Identifier);

          
            TypeAdapterConfig<PersonServiceModel, PersonDTO>
            .NewConfig()
            .Map(dest => dest.CityName, src => src.City.Name)
            .Map(dest => dest.Identifier, src => src.PersonIdentifier);


            TypeAdapterConfig<CreatePersonRequest, PersonServiceModel>
           .NewConfig()
           .Map(dest => dest.City, src => new CityServiceModel { Name = src.City })
           .Map(dest => dest.PersonIdentifier, src => src.Identifier);


            TypeAdapterConfig<PersonServiceModel, Person>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<UserServiceModel, User>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<AccountCreateRequest, UserServiceModel>
            .NewConfig()
            .TwoWays();

        }
    }
}
