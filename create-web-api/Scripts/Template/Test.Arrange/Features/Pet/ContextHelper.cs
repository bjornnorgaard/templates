using System;
using System.Threading.Tasks;
using Repository;

namespace Test.Arrange.Features.[Entity]
{
    public static class ContextHelper
    {
        public static async Task<Models.[Entity]> Seed[Entity]Async(this TmpContext context, Models.[Entity] model = null)
        {
            if (model == null)
            {
                // TODO: Assign model with new valid entity.
                throw new NotImplementedException();
            }

            await context.[Entity]s.AddAsync(model);
            await context.SaveChangesAsync();

            return model;
        }
    }
}
