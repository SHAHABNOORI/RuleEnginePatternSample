using RuleEnginePatternSample.IndividualTaxCalculator.Entities;
using RuleEnginePatternSample.IndividualTaxCalculator.Services;

namespace RuleEnginePatternSample.IndividualTaxCalculator.Test
{
    public class IndividualTaxCalculatorTest
    {
        private readonly TaxCalculatorService _taxCalculatorService = new();

        [Fact]
        public void Income_For_Single_TaxPayer()
        {
            //Arrange

            var taxPayer = new TaxPayer()
            {
                GrossIncome = 300000,
                IsSingle = true,
                HasHealthInsurance = true,
                HealthInsuranceAnnualPremium = 3000,
                IsResidentOrCitizen = true
            };

            //Act

            var result = _taxCalculatorService.CalculateTaxAmount(taxPayer);

            //Assert

            Assert.Equal(78000, result.TaxedAmount);

        }
    }
}