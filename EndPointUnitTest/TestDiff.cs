using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EndPointUnitTest
{
    [TestClass]
    public class TestDiff
    {
        private static HttpClient httpClient;
        private static Guid clientID;
        private const string BaseUrl = "https://localhost:5001";
        private static string leftData;
        private static string rightData;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            clientID = Guid.NewGuid();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            httpClient.Dispose();
        }

        [TestInitialize]
        public async Task TestInitialize()
        {
            leftData = "AAAAAA==";
            rightData = "AQABAQ==";

            StringContent leftContent = EncodeToBase64(leftData);
            HttpResponseMessage leftResponse = await httpClient.PostAsync($"/v1/diff/{clientID}/left", leftContent);
            Assert.IsNotNull(leftResponse);
            Assert.AreEqual(HttpStatusCode.Created, leftResponse.StatusCode);

            StringContent rightContent = EncodeToBase64(rightData);
            HttpResponseMessage rightResponse = await httpClient.PostAsync($"/v1/diff/{clientID}/right", rightContent);
            Assert.IsNotNull(rightResponse);
            Assert.AreEqual(HttpStatusCode.Created, rightResponse.StatusCode);
        }

        [TestMethod]
        public async Task CheckDiff1()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"/v1/diff/{clientID}");
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            string responseBody = await response.Content.ReadAsStringAsync();
        }

        private StringContent EncodeToBase64(string data)
        {
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(data);
            string base64String = Convert.ToBase64String(bytesToEncode);
            StringContent content = new StringContent($"\"{base64String}\"", Encoding.UTF8, "application/json");

            return content;
        }
    }
}
