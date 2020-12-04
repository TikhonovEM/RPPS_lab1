using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class HttpClientTest
    {
        [TestMethod]
        public void TestPingCorrect()
        {
            var client = new WebClient.WebClient("tolltech.ru/study");
            Assert.AreEqual(true, client.Ping());
        }

        [TestMethod]
        public void TestPingIncorrect()
        {
            var client = new WebClient.WebClient("tolltech.ru/studyyy");
            Assert.AreEqual(false, client.Ping());
        }

        [TestMethod]
        public void TestGetInputDataCorrect()
        {
            var client = new WebClient.WebClient("tolltech.ru/study");
            var expectedStr = "{\"K\":10,\"Sums\":[1.01,2.02],\"Muls\":[1,4]}";
            Assert.AreEqual(expectedStr, client.GetInputData());
        }

        [TestMethod]
        public void TestGetInputDataIncorrect()
        {
            var client = new WebClient.WebClient("tolltech.ru/study");
            var expectedStr = "{\"K\":10,\"Sums\":[1.01,2.02],\"Muls\"";
            Assert.AreNotEqual(expectedStr, client.GetInputData());
        }

        [TestMethod]
        public void TestWriteAnswerCorrect()
        {
            var answer = "{\"SumResult\":30.30,\"MulResult\":4,\"SortedInputs\":[1.0,1.01,2.02,4.0]}";
            var client = new WebClient.WebClient("tolltech.ru/study", true);
            Assert.AreEqual(HttpStatusCode.OK, client.WriteAnswer(answer));
        }

        [TestMethod]
        public void TestWriteAnswerIncorrect()
        {
            var answer = "{\"SumResult\":30.30,\"MulResult\":4,\"SortedInputs\":[1.0,1.01,2.02,4.0]";
            var client = new WebClient.WebClient("tolltech.ru/study", true);
            Assert.AreNotEqual(HttpStatusCode.OK, client.WriteAnswer(answer));
        }
    }
}
