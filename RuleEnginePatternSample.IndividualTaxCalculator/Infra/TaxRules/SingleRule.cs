using RuleEnginePatternSample.IndividualTaxCalculator.Contracts;
using RuleEnginePatternSample.IndividualTaxCalculator.Entities;

namespace RuleEnginePatternSample.IndividualTaxCalculator.Infra.TaxRules;

public class SingleRule : ITaxRule
{
    public TaxPayer CalculateTaxAmount(TaxPayer taxPayer, double currentPercentage)
    {
        if (taxPayer.IsSingle)
            taxPayer.TaxedAmount += (taxPayer.GrossIncome - 40000) * .1;

        return taxPayer;
    }
}