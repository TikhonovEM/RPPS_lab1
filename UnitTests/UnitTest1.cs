using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPPS_lab1._1;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestJSON()
        {
            var entity = new Entity()
            {
                Id = 1,
                Name = "Object1",
                Description = "Test Description1",
                Price = 15499
            };
            entity.Options.Add("FirstOption1", 3);
            entity.Options.Add("SecondOption1", "qwerty");
            var serializer = new JSONSerializer();
            var entityStr = serializer.Serialize(entity);
            var newEntity = serializer.Deserialize<Entity>(entityStr);
            Assert.AreEqual(entity.Id, newEntity.Id);
            Assert.AreEqual(entity.Name, newEntity.Name);
            Assert.AreEqual(entity.Description, newEntity.Description);
            Assert.AreEqual(entity.Price, newEntity.Price);
            Assert.AreEqual(entity.Options.Count, newEntity.Options.Count);
        }

        [TestMethod]
        public void TestXML()
        {
            var entity = new Entity()
            {
                Id = 1,
                Name = "Object1",
                Description = "Test Description1",
                Price = 15499
            };
            entity.Options.Add("FirstOption1", 3);
            entity.Options.Add("SecondOption1", "qwerty");
            var serializer = new XMLSerializer();
            var entityStr = serializer.Serialize(entity);
            var newEntity = serializer.Deserialize<Entity>(entityStr);
            Assert.AreEqual(entity.Id, newEntity.Id);
            Assert.AreEqual(entity.Name, newEntity.Name);
            Assert.AreEqual(entity.Description, newEntity.Description);
            Assert.AreEqual(entity.Price, newEntity.Price);
            Assert.AreEqual(entity.Options.Count, newEntity.Options.Count);
        }
    }
}
