using InterestCalc.Api;
using InterestCalc.Core.Models.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalc.Tests.IntegrationTests
{
	[TestFixture]
	public class InterestCalcIntegrationTests
	{
		private HttpClient _client;
		private StringContent httpContent;

		[SetUp]
		public void Setup()
		{
			WebApplicationFactory<Startup> webAppFactory = new WebApplicationFactory<Startup>();
			_client = webAppFactory.CreateClient();

			CompoundInterestRequestModel compoundInterestRequestModel = new CompoundInterestRequestModel() { InitialValue = 100, Months = 5 };
			httpContent = new StringContent(JsonConvert.SerializeObject(compoundInterestRequestModel), Encoding.Default, "application/json");
		}

		[Test]
		public async Task Post_WhenCalled_ReturnStatusOK()
		{
			var response = await _client.PostAsync(requestUri: "/consultaJuros", httpContent);
			response.EnsureSuccessStatusCode();
		}

		[Test]
		public async Task Post_WhenCalled_IsNotNegative()
		{
			var response = await _client.PostAsync(requestUri: "/consultaJuros", httpContent);
			
			string value = await response.Content.ReadAsStringAsync();

			Assert.GreaterOrEqual(decimal.Parse(value), 0);
		}

		[Test]
		public async Task Post_WhenCalled_ReturnsDecimal()
		{
			var response = await _client.PostAsync(requestUri: "/consultaJuros", httpContent);
			string value = await response.Content.ReadAsStringAsync();

			Assert.IsTrue(decimal.TryParse(value, out _));
		}

		[Test]
		public async Task Post_WhenCalled_ReturnsTheRightValue()
		{
			var response = await _client.PostAsync(requestUri: "/consultaJuros", httpContent);
			string value = await response.Content.ReadAsStringAsync();

			Assert.That(decimal.Parse(value) - 105.10M == 0);
		}
	}
}
