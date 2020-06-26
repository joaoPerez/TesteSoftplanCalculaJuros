using InterestCalc.Core.Interfaces.Services;
using InterestCalc.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalc.Services
{
	public class CompoundInterestService : ICompoundInterestService
	{
		public decimal CompoundInterestCalc(CompoundInterestModel model)
		{
			double initialValue = Convert.ToDouble(model.InitialValue);
			double value = initialValue * Math.Pow(1 + model.Interest, model.TimePeriod);

			return Convert.ToDecimal(string.Format("{0:F2}", value));
		}
	}
}
