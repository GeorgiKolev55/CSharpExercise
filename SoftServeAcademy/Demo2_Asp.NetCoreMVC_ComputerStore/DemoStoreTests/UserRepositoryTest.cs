using DemoStore.Data;
using DemoStore.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace DemoStoreTests
{
    class UserRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DemoStoreContext>()
            .UseInMemoryDatabase(databaseName: "UserListDatabase")
            .Options;

            using (var context = new DemoStoreContext(options))
            {

                context.Users.Add(new User { Id = 1, Username = "user1", Password = "password1", Role = "user" });
                context.Users.Add(new User { Id = 2, Username = "user2", Password = "password2", Role = "user" });
                context.Users.Add(new User { Id = 3, Username = "user3", Password = "password3", Role = "user" });
                context.Users.Add(new User { Id = 4, Username = "user4", Password = "password4", Role = "user" });

                context.SaveChanges();
            }

            this.Oprions = options;
        }
        private DbContextOptions<DemoStoreContext> Oprions { get; set; }
       
        [Test]
        public void FindUser_WithTheSameName_ReturnTrue()
        {
            var mockStoreContext = new DemoStoreContext(this.Oprions);

            IUserRepository userRepository = new UserRepository(mockStoreContext);

            var expectedUser = new User() { Username = "user3" };
            var actualUser = userRepository.FindUser(expectedUser);

            Assert.AreEqual("user3", actualUser.Username);
        }

        [Test]
        public void FindUser_WithNoSuchName_ReturnNull()
        {
            var mockStoreContext = new DemoStoreContext(this.Oprions);

            IUserRepository userRepository = new UserRepository(mockStoreContext);
           
            var user = new User() { Username = "user5" };
            var actualUser = userRepository.FindUser(user);

            Assert.IsNull(actualUser);
        }
       
    }
}
