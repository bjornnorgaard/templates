using System;
using Application.Features.Pet;

namespace Test.Arrange.Features.Pet
{
    public static class UpdatePetHelper
    {
        public static UpdatePet.Command Valid(this UpdatePet.Command command, Guid id)
        {
            return new UpdatePet.Command { Id = id, Name = "Updated Kitty", Age = 201 };
        }

        public static UpdatePet.Command Invalid(this UpdatePet.Command command, Guid id)
        {
            return new UpdatePet.Command { Id = id, Name = "Attempted Update Kitty" };
        }
    }
}
