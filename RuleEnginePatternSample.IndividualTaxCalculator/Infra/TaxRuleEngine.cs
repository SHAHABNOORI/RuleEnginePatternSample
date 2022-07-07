using RuleEnginePatternSample.IndividualTaxCalculator.Contracts;
using RuleEnginePatternSample.IndividualTaxCalculator.Entities;

namespace RuleEnginePatternSample.IndividualTaxCalculator.Infra;

public class TaxRuleEngine
{
    private readonly List<ITaxRule> _rules = new();

    public TaxRuleEngine(IEnumerable<ITaxRule> rules) => _rules.AddRange(rules);

    public TaxPayer CalculateTaxAmount(TaxPayer taxPayer)
    {
        foreach (var rule in _rules)
        {
            taxPayer.TaxedAmount += rule.CalculateTaxAmount(taxPayer, taxPayer.TaxedAmount).TaxedAmount;
        }
        return taxPayer;
    }
}
