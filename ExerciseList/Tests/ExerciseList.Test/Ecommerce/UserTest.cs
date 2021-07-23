using System;
using ExerciseList.DTO.Enum;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;
using Xunit;

namespace ExerciseList.Test.Ecommerce
{
    public class UserTest
    {
        private IUserService userService;


        [Theory]
        [InlineData("Gustavo", EnumCep.Tarabai)]
        [InlineData("GabrielA", EnumCep.MaringaJC)]
        [InlineData("Jose", EnumCep.PresidentePrudente)]
        public void MustLoginCorrectly(string name, EnumCep cep)
        {
            //Given
            userService = new UserService();

            //When
            var user = userService.SignIn(name);

            //Then
            Assert.NotNull(user);
            Assert.Equal(name.ToUpper(), user.Name.ToUpper());
            Assert.Equal(cep, user.Cep);
        }

        [Theory]
        [InlineData("Gustavoy")]
        [InlineData("GabrielAz")]
        [InlineData("Josex")]
        public void IyMustNotLoginCorrectly(string name)
        {
            //Given
            userService = new UserService();

            //When
            var user = userService.SignIn(name);

            //Then
            Assert.Null(user);
        }

    }
}