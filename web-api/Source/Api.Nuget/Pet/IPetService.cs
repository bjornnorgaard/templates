using System;
using System.Threading.Tasks;
using Application.Features.Pet;
using RestEase;

namespace Api.Nuget.Pet
{
    [Header("User-Agent", "RestEase")]
    [Header("Accept", "application/json")]
    public interface IPetService
    {
        [Get("/api/v1/pet")]
        Task<GetPet.Result> GetAllPetAsync([Query] int take, [Query] int skip);

        [Get("/api/v1/pet/{id}")]
        Task<GetPet.Result> GetPetAsync([Path] Guid id);

        [Post("/api/v1/pet")]
        Task<CreatePet.Result> CreatePetAsync([Body] CreatePet.Command command);

        [Put("/api/v1/pet/{id}")]
        Task<UpdatePet.Result> UpdatePetAsync([Path] Guid id, [Body] UpdatePet.Command command);

        [Delete("/api/v1/pet/{id}")]
        Task<DeletePet.Result> DeletePetAsync([Path] Guid id);
    }
}
