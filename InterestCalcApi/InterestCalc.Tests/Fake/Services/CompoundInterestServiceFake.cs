using InterestCalc.Core.Interfaces.Services;
using InterestCalc.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalc.Tests.Fake.Services
{
	public class CompoundInterestServiceFake : ICompoundInterestService
	{
		public decimal CompoundInterestCalc(CompoundInterestModel model)
		{
			double initialValue = Convert.ToDouble(model.InitialValue);
			double value = initialValue * Math.Pow(1 + model.Interest, model.TimePeriod);

			return Convert.ToDecimal(string.Format("{0:F2}", value));
		}
	}
}
