using System;
using System.Threading.Tasks;
using Application.Features.[Entity];
using RestEase;

namespace Api.Nuget.[Entity]
{
    [Header("User-Agent", "RestEase")]
    [Header("Accept", "application/json")]
    public interface I[Entity]Service
    {
        [Get("/api/v1/[Entity.ToLower]")]
        Task<Get[Entity].Result> GetAll[Entity]Async([Query] int take, [Query] int skip);

        [Get("/api/v1/[Entity.ToLower]/{id}")]
        Task<Get[Entity].Result> Get[Entity]Async([Path] Guid id);

        [Post("/api/v1/[Entity.ToLower]")]
        Task<Create[Entity].Result> Create[Entity]Async([Body] Create[Entity].Command command);

        [Put("/api/v1/[Entity.ToLower]/{id}")]
        Task<Update[Entity].Result> Update[Entity]Async([Path] Guid id, [Body] Update[Entity].Command command);

        [Delete("/api/v1/[Entity.ToLower]/{id}")]
        Task<Delete[Entity].Result> Delete[Entity]Async([Path] Guid id);
    }
}
