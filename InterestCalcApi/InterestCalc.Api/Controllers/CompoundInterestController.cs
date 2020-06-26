using InterestCalc.Core.Interfaces.Services;
using InterestCalc.Core.Models;
using InterestCalc.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace InterestCalc.Api.Controllers
{
    [ApiController]
    public class CompoundInterestController : ControllerBase
    {
        private readonly ICompoundInterestService _iCompoundInterestService;
        private readonly IInterestRateService _interestRateService;

        public CompoundInterestController(ICompoundInterestService compoundInterestService, IInterestRateService interestRateService)
        {
            _iCompoundInterestService = compoundInterestService;
            _interestRateService = interestRateService;
        }

        // GET: api/CompoundInterest
        [HttpPost]
        [Route("consultaJuros")]
        public decimal Post(CompoundInterestRequestModel request)
        {
            float interestRate = _interestRateService.GetInterestRateAsync().Result;

            CompoundInterestModel model = new CompoundInterestModel()
            {
                InitialValue = request.InitialValue,
                TimePeriod = request.Months,
                Interest = interestRate
            };

            return _iCompoundInterestService.CompoundInterestCalc(model);
        }
    }
}
