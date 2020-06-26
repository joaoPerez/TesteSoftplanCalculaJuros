using InterestCalc.Core.Interfaces.Services;
using InterestCalc.Core.Models;
using InterestCalc.Tests.Fake.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalc.Tests.UnitTests.Services
{
	[TestFixture]
	public class CompoundInterestServiceTests
	{
		private ICompoundInterestService _compoundInterestService;
		private CompoundInterestModel compoundInterestModel;

		[SetUp]
		public void Setup()
		{
			_compoundInterestService = new CompoundInterestServiceFake();

			compoundInterestModel = new CompoundInterestModel()
			{
				InitialValue = 100M,
				Interest = 0.01F,
				TimePeriod = 5
			};
		}

		[Test]
		public void CompoundInterestCalc_Calculating_ReturnsTheRightValue()
		{
			decimal result = _compoundInterestService.CompoundInterestCalc(compoundInterestModel);

			Assert.That(result - 105.10M == 0);
		}
	}
}
