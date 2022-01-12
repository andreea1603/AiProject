using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using WebAPI.Services;


namespace TestsSentiTweet.Services.Users
{
    [TestClass]
    public class PasswordHashing
    {
        public const string PASSWORD = "my_password_123";

        [TestMethod]
        public void TestPasswordIsHashingProperly()
        {
            byte[] passwordHash, passwordSalt;
            UserService.CreatePasswordHash(PASSWORD, out passwordHash, out passwordSalt);

            bool passwordHashProperly = UserService.VerifyPasswordHash(PASSWORD, passwordHash, passwordSalt);
            Assert.IsTrue(
                passwordHashProperly,
                "Password is not hashing properly."
                );
        }
    }
}
