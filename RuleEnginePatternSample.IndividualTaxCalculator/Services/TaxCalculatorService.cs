using RuleEnginePatternSample.IndividualTaxCalculator.Contracts;
using RuleEnginePatternSample.IndividualTaxCalculator.Entities;
using RuleEnginePatternSample.IndividualTaxCalculator.Infra;

namespace RuleEnginePatternSample.IndividualTaxCalculator.Services;

public class TaxCalculatorService
{
    public TaxPayer CalculateTaxAmount(TaxPayer taxPayer)
    {
        var ruleType = typeof(ITaxRule);
        IEnumerable<ITaxRule> rules = GetType().Assembly.GetTypes()
            .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
            .Select(r => Activator.CreateInstance(r) as ITaxRule)!;

        var engine = new TaxRuleEngine(rules);

        return engine.CalculateTaxAmount(taxPayer);
    }
}