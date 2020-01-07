using System.Threading.Tasks;
using Repository;

namespace Test.Arrange.Features.Pet
{
    public static class ContextHelper
    {
        /// <summary>
        ///     Will insert a pet into the context and save changes. If no pet is provided, it will create a default pet.
        /// </summary>
        /// <param name="context">The connected DbContext.</param>
        /// <param name="pet">Pet to be inserted. Will create a default Pet if left as null.</param>
        /// <returns>Inserted pet with primary key set.</returns>
        public static async Task<Models.Pet> SeedPetAsync(this Context context, Models.Pet pet = null)
        {
            if (pet == null)
            {
                pet = new Models.Pet { Name = "Kitty", Age = 42 };
            }

            await context.Pets.AddAsync(pet);
            await context.SaveChangesAsync();

            return pet;
        }
    }
}
