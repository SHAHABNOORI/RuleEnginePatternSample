using RuleEnginePatternSample.IndividualTaxCalculator.Entities;

namespace RuleEnginePatternSample.IndividualTaxCalculator.Contracts;

public interface ITaxRule
{
    TaxPayer CalculateTaxAmount(TaxPayer taxPayer, double currentPercentage);
}