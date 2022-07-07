using RuleEnginePatternSample.IndividualTaxCalculator.Contracts;
using RuleEnginePatternSample.IndividualTaxCalculator.Entities;

namespace RuleEnginePatternSample.IndividualTaxCalculator.Infra.TaxRules;

public class IncomeRule : ITaxRule
{
    public TaxPayer CalculateTaxAmount(TaxPayer taxPayer, double currentPercentage)
    {
        taxPayer.TaxedAmount = taxPayer.GrossIncome < 40000
            ? 0
            : taxPayer.TaxedAmount + (taxPayer.GrossIncome - 40000) * .1;
        return taxPayer;
    }
}