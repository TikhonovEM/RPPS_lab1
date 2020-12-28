using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPPS_lab1._1;

namespace UnitTests
{
    [TestClass]
    public class SerializerTest
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

        [TestMethod]
        public void TestJSON1()
        {
            var input = new Input()
            {
                K = 10,
                Sums = new decimal[] { (decimal)1.01, (decimal)2.02 },
                Muls = new int[] { 1, 4 }
            };
            var serializer = new JSONSerializer();
            var inputStr = serializer.Serialize(input);
            var newInput = serializer.Deserialize<Input>(inputStr);
            var output = newInput.GetOutput();
            var outputStr = serializer.Serialize(output);
            var newOutput = serializer.Deserialize<Output>(outputStr);
            var expected = new Output()
            {
                MulResult = 4,
                SumResult = (decimal)30.30,
                SortedInputs = new decimal[] { 1, (decimal)1.01, (decimal)2.02, 4 }
            };
            Assert.AreEqual(newOutput.MulResult, expected.MulResult);
            Assert.AreEqual(newOutput.SumResult, expected.SumResult);
            Assert.AreEqual(newOutput.SortedInputs.Length, expected.SortedInputs.Length);
        }

        [TestMethod]
        public void TestXML1()
        {
            var input = new Input()
            {
                K = 10,
                Sums = new decimal[] { (decimal)1.01, (decimal)2.02 },
                Muls = new int[] { 1, 4 }
            };
            var serializer = new XMLSerializer();
            var inputStr = serializer.Serialize(input);
            var newInput = serializer.Deserialize<Input>(inputStr);
            var output = newInput.GetOutput();
            var outputStr = serializer.Serialize(output);
            var newOutput = serializer.Deserialize<Output>(outputStr);
            var expected = new Output()
            {
                MulResult = 4,
                SumResult = (decimal)30.30,
                SortedInputs = new decimal[] { 1, (decimal)1.01, (decimal)2.02, 4 }
            };
            Assert.AreEqual(newOutput.MulResult, expected.MulResult);
            Assert.AreEqual(newOutput.SumResult, expected.SumResult);
            Assert.AreEqual(newOutput.SortedInputs.Length, expected.SortedInputs.Length);
        }
    }
}
