//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/jmalek/src/mmecalculator/src/Grammar/DefaultParser.g4 by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace PracticeFusion.MmeCalculator.Core.Parsers.Generated {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="DefaultParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface IDefaultParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.sig"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSig([NotNull] DefaultParser.SigContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.dosage"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDosage([NotNull] DefaultParser.DosageContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.dosageSeparator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDosageSeparator([NotNull] DefaultParser.DosageSeparatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.doseDeliveryMethod"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoseDeliveryMethod([NotNull] DefaultParser.DoseDeliveryMethodContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.ambiguousDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAmbiguousDose([NotNull] DefaultParser.AmbiguousDoseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.doseVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoseVal([NotNull] DefaultParser.DoseValContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.dose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDose([NotNull] DefaultParser.DoseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.doseUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoseUnit([NotNull] DefaultParser.DoseUnitContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.formExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFormExpression([NotNull] DefaultParser.FormExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.formRoute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFormRoute([NotNull] DefaultParser.FormRouteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.form"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForm([NotNull] DefaultParser.FormContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.doseUnitOfMeasure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoseUnitOfMeasure([NotNull] DefaultParser.DoseUnitOfMeasureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.route"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRoute([NotNull] DefaultParser.RouteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.routeInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRouteInstruction([NotNull] DefaultParser.RouteInstructionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.routeEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRouteEnum([NotNull] DefaultParser.RouteEnumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.frequencies"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFrequencies([NotNull] DefaultParser.FrequenciesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.frequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFrequency([NotNull] DefaultParser.FrequencyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.specialFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSpecialFrequency([NotNull] DefaultParser.SpecialFrequencyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.basicFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBasicFrequency([NotNull] DefaultParser.BasicFrequencyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.periodVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPeriodVal([NotNull] DefaultParser.PeriodValContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.maximum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMaximum([NotNull] DefaultParser.MaximumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.frequencyVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFrequencyVal([NotNull] DefaultParser.FrequencyValContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.dayFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDayFrequency([NotNull] DefaultParser.DayFrequencyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.latinFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLatinFrequency([NotNull] DefaultParser.LatinFrequencyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.administrationTiming"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdministrationTiming([NotNull] DefaultParser.AdministrationTimingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.specificTimes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSpecificTimes([NotNull] DefaultParser.SpecificTimesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.specificTime"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSpecificTime([NotNull] DefaultParser.SpecificTimeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.hour"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHour([NotNull] DefaultParser.HourContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.hourAndMinute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHourAndMinute([NotNull] DefaultParser.HourAndMinuteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.timeOfDay"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTimeOfDay([NotNull] DefaultParser.TimeOfDayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.timingEvent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTimingEvent([NotNull] DefaultParser.TimingEventContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.latinAdministrationTiming"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLatinAdministrationTiming([NotNull] DefaultParser.LatinAdministrationTimingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.periodBeforeOrAfter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPeriodBeforeOrAfter([NotNull] DefaultParser.PeriodBeforeOrAfterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.meals"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMeals([NotNull] DefaultParser.MealsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.duration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDuration([NotNull] DefaultParser.DurationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.durationStandard"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDurationStandard([NotNull] DefaultParser.DurationStandardContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.durationOrdinal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDurationOrdinal([NotNull] DefaultParser.DurationOrdinalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.durationUnbounded"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDurationUnbounded([NotNull] DefaultParser.DurationUnboundedContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.additionalInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditionalInstruction([NotNull] DefaultParser.AdditionalInstructionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.emptyStomach"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEmptyStomach([NotNull] DefaultParser.EmptyStomachContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.asDirected"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAsDirected([NotNull] DefaultParser.AsDirectedContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.withFood"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWithFood([NotNull] DefaultParser.WithFoodContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.withLiquid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWithLiquid([NotNull] DefaultParser.WithLiquidContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.doNotSwallow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoNotSwallow([NotNull] DefaultParser.DoNotSwallowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.indicationForUse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndicationForUse([NotNull] DefaultParser.IndicationForUseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.indicationPrecursor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndicationPrecursor([NotNull] DefaultParser.IndicationPrecursorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.indicationValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndicationValue([NotNull] DefaultParser.IndicationValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.indicationEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndicationEnum([NotNull] DefaultParser.IndicationEnumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.ordinalNumeric"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrdinalNumeric([NotNull] DefaultParser.OrdinalNumericContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.numericValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumericValue([NotNull] DefaultParser.NumericValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.rangeNumericValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRangeNumericValue([NotNull] DefaultParser.RangeNumericValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.rangeNumericValueWithUOM"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRangeNumericValueWithUOM([NotNull] DefaultParser.RangeNumericValueWithUOMContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.rangeSeparator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRangeSeparator([NotNull] DefaultParser.RangeSeparatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.period"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPeriod([NotNull] DefaultParser.PeriodContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.periodEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPeriodEnum([NotNull] DefaultParser.PeriodEnumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.dayOfTheWeek"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDayOfTheWeek([NotNull] DefaultParser.DayOfTheWeekContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.periodly"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPeriodly([NotNull] DefaultParser.PeriodlyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.wordNumber"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWordNumber([NotNull] DefaultParser.WordNumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.wordDigit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWordDigit([NotNull] DefaultParser.WordDigitContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.medication"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMedication([NotNull] DefaultParser.MedicationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.medicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMedicationComponent([NotNull] DefaultParser.MedicationComponentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.simpleMedicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSimpleMedicationComponent([NotNull] DefaultParser.SimpleMedicationComponentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.complexMedicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComplexMedicationComponent([NotNull] DefaultParser.ComplexMedicationComponentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.nonOpioid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNonOpioid([NotNull] DefaultParser.NonOpioidContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDescription([NotNull] DefaultParser.DescriptionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.drugForm"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDrugForm([NotNull] DefaultParser.DrugFormContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.opioid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOpioid([NotNull] DefaultParser.OpioidContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.drugSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDrugSuffix([NotNull] DefaultParser.DrugSuffixContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.strength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStrength([NotNull] DefaultParser.StrengthContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.brandName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBrandName([NotNull] DefaultParser.BrandNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.freeText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFreeText([NotNull] DefaultParser.FreeTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.testDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTestDose([NotNull] DefaultParser.TestDoseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.testAmbiguousDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTestAmbiguousDose([NotNull] DefaultParser.TestAmbiguousDoseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.testFormExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTestFormExpression([NotNull] DefaultParser.TestFormExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.testRoute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTestRoute([NotNull] DefaultParser.TestRouteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.testFrequencies"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTestFrequencies([NotNull] DefaultParser.TestFrequenciesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.testDuration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTestDuration([NotNull] DefaultParser.TestDurationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.testAdditionalInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTestAdditionalInstruction([NotNull] DefaultParser.TestAdditionalInstructionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="DefaultParser.testIndicationForUse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTestIndicationForUse([NotNull] DefaultParser.TestIndicationForUseContext context);
}
} // namespace PracticeFusion.MmeCalculator.Core.Parsers.Generated
