//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/jmalek/src/mmecalculator/src/Grammar/DefaultParser.g4 by ANTLR 4.12.0

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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="DefaultParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public interface IDefaultParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.sig"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSig([NotNull] DefaultParser.SigContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.sig"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSig([NotNull] DefaultParser.SigContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.dosage"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDosage([NotNull] DefaultParser.DosageContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.dosage"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDosage([NotNull] DefaultParser.DosageContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.dosageSeparator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDosageSeparator([NotNull] DefaultParser.DosageSeparatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.dosageSeparator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDosageSeparator([NotNull] DefaultParser.DosageSeparatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.doseDeliveryMethod"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoseDeliveryMethod([NotNull] DefaultParser.DoseDeliveryMethodContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.doseDeliveryMethod"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoseDeliveryMethod([NotNull] DefaultParser.DoseDeliveryMethodContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.ambiguousDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAmbiguousDose([NotNull] DefaultParser.AmbiguousDoseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.ambiguousDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAmbiguousDose([NotNull] DefaultParser.AmbiguousDoseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.doseVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoseVal([NotNull] DefaultParser.DoseValContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.doseVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoseVal([NotNull] DefaultParser.DoseValContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.dose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDose([NotNull] DefaultParser.DoseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.dose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDose([NotNull] DefaultParser.DoseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.doseUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoseUnit([NotNull] DefaultParser.DoseUnitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.doseUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoseUnit([NotNull] DefaultParser.DoseUnitContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.formExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFormExpression([NotNull] DefaultParser.FormExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.formExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFormExpression([NotNull] DefaultParser.FormExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.formRoute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFormRoute([NotNull] DefaultParser.FormRouteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.formRoute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFormRoute([NotNull] DefaultParser.FormRouteContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.form"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForm([NotNull] DefaultParser.FormContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.form"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForm([NotNull] DefaultParser.FormContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.doseUnitOfMeasure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoseUnitOfMeasure([NotNull] DefaultParser.DoseUnitOfMeasureContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.doseUnitOfMeasure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoseUnitOfMeasure([NotNull] DefaultParser.DoseUnitOfMeasureContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.route"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRoute([NotNull] DefaultParser.RouteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.route"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRoute([NotNull] DefaultParser.RouteContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.routeInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRouteInstruction([NotNull] DefaultParser.RouteInstructionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.routeInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRouteInstruction([NotNull] DefaultParser.RouteInstructionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.routeEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRouteEnum([NotNull] DefaultParser.RouteEnumContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.routeEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRouteEnum([NotNull] DefaultParser.RouteEnumContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.frequencies"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFrequencies([NotNull] DefaultParser.FrequenciesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.frequencies"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFrequencies([NotNull] DefaultParser.FrequenciesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.frequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFrequency([NotNull] DefaultParser.FrequencyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.frequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFrequency([NotNull] DefaultParser.FrequencyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.specialFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSpecialFrequency([NotNull] DefaultParser.SpecialFrequencyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.specialFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSpecialFrequency([NotNull] DefaultParser.SpecialFrequencyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.basicFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBasicFrequency([NotNull] DefaultParser.BasicFrequencyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.basicFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBasicFrequency([NotNull] DefaultParser.BasicFrequencyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.periodVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPeriodVal([NotNull] DefaultParser.PeriodValContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.periodVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPeriodVal([NotNull] DefaultParser.PeriodValContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.maximum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMaximum([NotNull] DefaultParser.MaximumContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.maximum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMaximum([NotNull] DefaultParser.MaximumContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.frequencyVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFrequencyVal([NotNull] DefaultParser.FrequencyValContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.frequencyVal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFrequencyVal([NotNull] DefaultParser.FrequencyValContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.dayFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDayFrequency([NotNull] DefaultParser.DayFrequencyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.dayFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDayFrequency([NotNull] DefaultParser.DayFrequencyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.latinFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLatinFrequency([NotNull] DefaultParser.LatinFrequencyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.latinFrequency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLatinFrequency([NotNull] DefaultParser.LatinFrequencyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.administrationTiming"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdministrationTiming([NotNull] DefaultParser.AdministrationTimingContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.administrationTiming"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdministrationTiming([NotNull] DefaultParser.AdministrationTimingContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.specificTimes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSpecificTimes([NotNull] DefaultParser.SpecificTimesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.specificTimes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSpecificTimes([NotNull] DefaultParser.SpecificTimesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.specificTime"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSpecificTime([NotNull] DefaultParser.SpecificTimeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.specificTime"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSpecificTime([NotNull] DefaultParser.SpecificTimeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.hour"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHour([NotNull] DefaultParser.HourContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.hour"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHour([NotNull] DefaultParser.HourContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.hourAndMinute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHourAndMinute([NotNull] DefaultParser.HourAndMinuteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.hourAndMinute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHourAndMinute([NotNull] DefaultParser.HourAndMinuteContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.timeOfDay"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTimeOfDay([NotNull] DefaultParser.TimeOfDayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.timeOfDay"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTimeOfDay([NotNull] DefaultParser.TimeOfDayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.timingEvent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTimingEvent([NotNull] DefaultParser.TimingEventContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.timingEvent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTimingEvent([NotNull] DefaultParser.TimingEventContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.latinAdministrationTiming"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLatinAdministrationTiming([NotNull] DefaultParser.LatinAdministrationTimingContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.latinAdministrationTiming"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLatinAdministrationTiming([NotNull] DefaultParser.LatinAdministrationTimingContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.periodBeforeOrAfter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPeriodBeforeOrAfter([NotNull] DefaultParser.PeriodBeforeOrAfterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.periodBeforeOrAfter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPeriodBeforeOrAfter([NotNull] DefaultParser.PeriodBeforeOrAfterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.meals"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMeals([NotNull] DefaultParser.MealsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.meals"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMeals([NotNull] DefaultParser.MealsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.duration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDuration([NotNull] DefaultParser.DurationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.duration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDuration([NotNull] DefaultParser.DurationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.durationStandard"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDurationStandard([NotNull] DefaultParser.DurationStandardContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.durationStandard"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDurationStandard([NotNull] DefaultParser.DurationStandardContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.durationOrdinal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDurationOrdinal([NotNull] DefaultParser.DurationOrdinalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.durationOrdinal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDurationOrdinal([NotNull] DefaultParser.DurationOrdinalContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.durationUnbounded"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDurationUnbounded([NotNull] DefaultParser.DurationUnboundedContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.durationUnbounded"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDurationUnbounded([NotNull] DefaultParser.DurationUnboundedContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.additionalInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdditionalInstruction([NotNull] DefaultParser.AdditionalInstructionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.additionalInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdditionalInstruction([NotNull] DefaultParser.AdditionalInstructionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.emptyStomach"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEmptyStomach([NotNull] DefaultParser.EmptyStomachContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.emptyStomach"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEmptyStomach([NotNull] DefaultParser.EmptyStomachContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.asDirected"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAsDirected([NotNull] DefaultParser.AsDirectedContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.asDirected"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAsDirected([NotNull] DefaultParser.AsDirectedContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.withFood"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWithFood([NotNull] DefaultParser.WithFoodContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.withFood"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWithFood([NotNull] DefaultParser.WithFoodContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.withLiquid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWithLiquid([NotNull] DefaultParser.WithLiquidContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.withLiquid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWithLiquid([NotNull] DefaultParser.WithLiquidContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.doNotSwallow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoNotSwallow([NotNull] DefaultParser.DoNotSwallowContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.doNotSwallow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoNotSwallow([NotNull] DefaultParser.DoNotSwallowContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.indicationForUse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndicationForUse([NotNull] DefaultParser.IndicationForUseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.indicationForUse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndicationForUse([NotNull] DefaultParser.IndicationForUseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.indicationPrecursor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndicationPrecursor([NotNull] DefaultParser.IndicationPrecursorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.indicationPrecursor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndicationPrecursor([NotNull] DefaultParser.IndicationPrecursorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.indicationValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndicationValue([NotNull] DefaultParser.IndicationValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.indicationValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndicationValue([NotNull] DefaultParser.IndicationValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.indicationEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndicationEnum([NotNull] DefaultParser.IndicationEnumContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.indicationEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndicationEnum([NotNull] DefaultParser.IndicationEnumContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.ordinalNumeric"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrdinalNumeric([NotNull] DefaultParser.OrdinalNumericContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.ordinalNumeric"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrdinalNumeric([NotNull] DefaultParser.OrdinalNumericContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.numericValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumericValue([NotNull] DefaultParser.NumericValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.numericValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumericValue([NotNull] DefaultParser.NumericValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.rangeNumericValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRangeNumericValue([NotNull] DefaultParser.RangeNumericValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.rangeNumericValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRangeNumericValue([NotNull] DefaultParser.RangeNumericValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.rangeNumericValueWithUOM"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRangeNumericValueWithUOM([NotNull] DefaultParser.RangeNumericValueWithUOMContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.rangeNumericValueWithUOM"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRangeNumericValueWithUOM([NotNull] DefaultParser.RangeNumericValueWithUOMContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.rangeSeparator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRangeSeparator([NotNull] DefaultParser.RangeSeparatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.rangeSeparator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRangeSeparator([NotNull] DefaultParser.RangeSeparatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.period"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPeriod([NotNull] DefaultParser.PeriodContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.period"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPeriod([NotNull] DefaultParser.PeriodContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.periodEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPeriodEnum([NotNull] DefaultParser.PeriodEnumContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.periodEnum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPeriodEnum([NotNull] DefaultParser.PeriodEnumContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.dayOfTheWeek"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDayOfTheWeek([NotNull] DefaultParser.DayOfTheWeekContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.dayOfTheWeek"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDayOfTheWeek([NotNull] DefaultParser.DayOfTheWeekContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.periodly"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPeriodly([NotNull] DefaultParser.PeriodlyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.periodly"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPeriodly([NotNull] DefaultParser.PeriodlyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.wordNumber"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWordNumber([NotNull] DefaultParser.WordNumberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.wordNumber"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWordNumber([NotNull] DefaultParser.WordNumberContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.wordDigit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWordDigit([NotNull] DefaultParser.WordDigitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.wordDigit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWordDigit([NotNull] DefaultParser.WordDigitContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.medication"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMedication([NotNull] DefaultParser.MedicationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.medication"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMedication([NotNull] DefaultParser.MedicationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.medicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMedicationComponent([NotNull] DefaultParser.MedicationComponentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.medicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMedicationComponent([NotNull] DefaultParser.MedicationComponentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.simpleMedicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleMedicationComponent([NotNull] DefaultParser.SimpleMedicationComponentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.simpleMedicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleMedicationComponent([NotNull] DefaultParser.SimpleMedicationComponentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.complexMedicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComplexMedicationComponent([NotNull] DefaultParser.ComplexMedicationComponentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.complexMedicationComponent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComplexMedicationComponent([NotNull] DefaultParser.ComplexMedicationComponentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.nonOpioid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNonOpioid([NotNull] DefaultParser.NonOpioidContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.nonOpioid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNonOpioid([NotNull] DefaultParser.NonOpioidContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDescription([NotNull] DefaultParser.DescriptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDescription([NotNull] DefaultParser.DescriptionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.drugForm"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDrugForm([NotNull] DefaultParser.DrugFormContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.drugForm"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDrugForm([NotNull] DefaultParser.DrugFormContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.opioid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOpioid([NotNull] DefaultParser.OpioidContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.opioid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOpioid([NotNull] DefaultParser.OpioidContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.drugSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDrugSuffix([NotNull] DefaultParser.DrugSuffixContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.drugSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDrugSuffix([NotNull] DefaultParser.DrugSuffixContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.strength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStrength([NotNull] DefaultParser.StrengthContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.strength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStrength([NotNull] DefaultParser.StrengthContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.brandName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBrandName([NotNull] DefaultParser.BrandNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.brandName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBrandName([NotNull] DefaultParser.BrandNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.freeText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFreeText([NotNull] DefaultParser.FreeTextContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.freeText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFreeText([NotNull] DefaultParser.FreeTextContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.testDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTestDose([NotNull] DefaultParser.TestDoseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.testDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTestDose([NotNull] DefaultParser.TestDoseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.testAmbiguousDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTestAmbiguousDose([NotNull] DefaultParser.TestAmbiguousDoseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.testAmbiguousDose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTestAmbiguousDose([NotNull] DefaultParser.TestAmbiguousDoseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.testFormExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTestFormExpression([NotNull] DefaultParser.TestFormExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.testFormExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTestFormExpression([NotNull] DefaultParser.TestFormExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.testRoute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTestRoute([NotNull] DefaultParser.TestRouteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.testRoute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTestRoute([NotNull] DefaultParser.TestRouteContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.testFrequencies"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTestFrequencies([NotNull] DefaultParser.TestFrequenciesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.testFrequencies"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTestFrequencies([NotNull] DefaultParser.TestFrequenciesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.testDuration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTestDuration([NotNull] DefaultParser.TestDurationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.testDuration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTestDuration([NotNull] DefaultParser.TestDurationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.testAdditionalInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTestAdditionalInstruction([NotNull] DefaultParser.TestAdditionalInstructionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.testAdditionalInstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTestAdditionalInstruction([NotNull] DefaultParser.TestAdditionalInstructionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DefaultParser.testIndicationForUse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTestIndicationForUse([NotNull] DefaultParser.TestIndicationForUseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DefaultParser.testIndicationForUse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTestIndicationForUse([NotNull] DefaultParser.TestIndicationForUseContext context);
}
} // namespace PracticeFusion.MmeCalculator.Core.Parsers.Generated
