using InterestCalc.Core.Interfaces.Services;
using InterestCalc.Tests.Fake.Services;
using NUnit.Framework;

namespace InterestCalc.Tests.UnitTests.Services
{
	[TestFixture]
	public class InterestRateServiceTests
	{
		private IInterestRateService _interestRateService;

		[SetUp]
		public void Setup()
		{
			_interestRateService = new InterestRateServiceFake();
		}

		[Test]
		public void GetInterestRate_WhenCalled_ReturnsTheInterestRate()
		{
			float result = _interestRateService.GetInterestRateAsync().Result;

			Assert.That(result - 0.01F == 0);
		}
	}
}
