using InterestCalc.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalc.Core.Interfaces.Services
{
	public interface ICompoundInterestService
	{
		decimal CompoundInterestCalc(CompoundInterestModel model);
	}
}
