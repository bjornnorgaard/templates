using Application.Features.Pet;

namespace Test.Arrange.Features.Pet
{
    public static class CreatePetHelper
    {
        public static CreatePet.Command Valid(this CreatePet.Command command)
        {
            return new CreatePet.Command { Name = "Kitty", Age = 42 };
        }

        public static CreatePet.Command Invalid(this CreatePet.Command command)
        {
            return new CreatePet.Command { Name = "Kitty" };
        }
    }
}
