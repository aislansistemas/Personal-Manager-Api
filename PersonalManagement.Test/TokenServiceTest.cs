using FluentAssertions;
using PersonalManagement.Api.Enums;
using PersonalManagement.Api.Models;
using PersonalManagement.Api.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PersonalManagement.Test
{
    public class TokenServiceTest
    {
        [Fact]
        public void GenerateTokenTest()
        {
            var user = new UserAccount() { 
                UserName = "aislanhouse10@gmail.com",
                PasswordHash = "12345678",
                Role = UserRoleEnum.Admin,
                Name = "Aislan",
                Id = "13122312adasdasdas-=12312dasd"
            };

            var token = TokenService.GenerateToken(user);

            token.Should().BeOfType<string>();
        }

        [Theory]
        [InlineData("bm5mZ2Zqa3Ryc2xyaW92eGRhLnNhZGFzXGRhd3dxZXcuL2FzZGE+KjNkPz5zd2RkLiUyM2Rhc2ExMjIxLi8=")]
        public void SecretTokenTest(string secretMock)
        {
            var secretToken = TokenService.GetSecretToken();

            secretMock.Should().Be(secretMock);
            secretToken.Should().Be(secretToken);
            secretMock.Should().Equals(secretToken);
        }
    }
}
