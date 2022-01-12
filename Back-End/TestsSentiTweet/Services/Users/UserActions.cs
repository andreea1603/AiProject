using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebAPI.Entities;


namespace TestsSentiTweet.Services.Users
{
    [TestClass]
    public class UserActions
    {
        public const string FIRST_NAME = "my_firstname_123";
        public const string LAST_NAME = "my_lastname_123";
        public const string USERNAME = "my_username_123";
        public const string PASSWORD = "my_password_123";

        [TestMethod]
        public void TestPasswordIsHashingProperly()
        {
            User user = new User()
            {
                FirstName = FIRST_NAME,
                LastName = LAST_NAME,
                Username = USERNAME
            };
        }
    }
}
