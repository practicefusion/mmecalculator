parser grammar DefaultParser;

options {
	superClass = Parser;
	tokenVocab = DefaultLexer;
}

sig: dosage (dosage)* ((DOT | COMMA)? freeText)? EOF;

strictSig: strictDosage (strictDosage)* EOF;

dosage:
	dosageSeparator? doseDeliveryMethod? (dose | ambiguousDose) (
		route
		| frequencies
		| duration
		| additionalInstruction
		| indicationForUse
	)*;

strictDosage:
	dosageSeparator? doseDeliveryMethod dose 
	route
	frequencies ?
	additionalInstruction ?
	indicationForUse? duration?;

//////////////////////////////////////////////////////////////////////////
// Dose
dosageSeparator: AND? THEN | OR;

doseDeliveryMethod:
	ADMINISTER
	| APPLY
	| CHEW
	| CHEW AND SWALLOW
	| DISSOLVE
	| GIVE
	| INFUSE
	| INHALE
	| INJECT
	| INSERT
	| PLACE
	| SUCK
	| TAKE
	| USE;

ambiguousDose: doseVal;

doseVal: numericValue | rangeNumericValue;

dose:
	(doseVal doseUnit | rangeNumericValueWithUOM) (
		OPEN_PAREN dose CLOSE_PAREN
	)?;

doseUnit: formExpression | doseUnitOfMeasure;

formExpression:
	formRoute? form;

formRoute:
	INJECTABLE
	| NASAL
	| ORAL
	| RECTAL
	| SUBLINGUAL
	| TRANSDERMAL;

form:
	APPLICATION
	| BUCCAL
	| CAPSULE
	| CARTRIDGE
	| DOSE
	| DROP
	| EACH
	| ELIXIR
	| FILM
	| INJECTION
	| LIQUID
	| LOLLIPOP
	| LOZENGE
	| PATCH
	| PIECE
	| PILL
	| PUFF
	| SOLUTION
	| SPRAY
	| SUPPOSITORY
	| SUSPENSION
	| SYRINGE
	| SYRUP
	| SYSTEM
	| TABLET
	| TDP
	| TROCHE;

doseUnitOfMeasure:
	CENTIMETERS
	| CUBICCENTIMETERS
	| GRAMS
	| INTERNATIONALUNITS
	| LITERS
	| MILLIEQUIVALENTS
	| MICROGRAMSPERHOUR
	| MICROGRAMSPERACT
	| MICROGRAMS
	| MILLIGRAMSPERHOUR
	| MILLIGRAMSPERACT
	| MILLIGRAMSPERML
	| MILLIGRAMS
	| MILLILITERS
	| OUNCES
	| TABLESPOONS
	| TEASPOONS;

//////////////////////////////////////////////////////////////////////////
// Route
route:
	routeInstruction? routeEnum (FORWARDSLASH routeEnum)* (
		OR? route
	)*;

routeInstruction: (INHALED)? (BY | VIA | PER);

routeEnum:
	MOUTH
	| ORAL
	| ORALLY
	| PO
	| UNDER THE TONGUE
	| SL
	| SUBLINGUAL
	| SUBLINGUALLY
	| (FEEDING | GASTROSTOMY) TUBE
	| INTRANASALLY
	| NASALLY
	| (PER|EACH) NOSTRIL
	| RECTAL
	| RECTALLY
	| TOPICAL
	| TOPICALLY
	| TRANSDERMAL
	| TRANSDERMALLY
	| TOSKIN
	| ONSKIN
	| TOUPPERTORSO;

//////////////////////////////////////////////////////////////////////////
// Frequency
frequencies: frequency (frequency)*;

frequency:
	(AND? CHANGE)? (
		specialFrequency
		| basicFrequency
		| dayFrequency
		| latinFrequency
		| administrationTiming
	);

specialFrequency:
	EVERY numericValue HOUR OPEN_PAREN numericValue TIMES FORWARDSLASH DAY CLOSE_PAREN
	| AS (ONE | NUMBER) DOSE;

basicFrequency:
	maximum? frequencyVal? (
		(PER | EVERY | EACH | A_AN | Q_Q) periodVal? period
		| latinFrequency
		| Q_Q? periodly
	);

periodVal: numericValue | rangeNumericValue;

maximum: MAXIMUM | UP TO;

frequencyVal:
	(numericValue | rangeNumericValue) (TIME | TIMES | X_X)
	| ONCE
	| TWICE
	| THRICE;

dayFrequency: (EVERY | ON) dayOfTheWeek (AND? dayOfTheWeek)*;

latinFrequency:
	QD
	| QHS
	| QOD
	| BID
	| TID
	| QID
	| QPM
	| QN
	| QAM;

administrationTiming:
	(AND? THEN? AT? IN? THE?) (
		specificTimes
		| timeOfDay
		| timingEvent
		| latinAdministrationTiming
	);

specificTimes: specificTime ((COMMA | AND)? AT? specificTime)*;

specificTime: (hour | hourAndMinute) (AM | PM)?;

hour: NUMBER;

hourAndMinute: CLOCKNUMBER;

timeOfDay:
	(EVERY | EACH)? (
		MORNING
		| DAY? (BEFORE | AFTER | AT) (NOON | MIDDAY)
		| EVENING
		| NIGHT TIME?
		| (periodBeforeOrAfter)? BEDTIME
	);

timingEvent:
	(BEFORE | AFTER | WITH | periodBeforeOrAfter) (EVERY | EACH) meals;

latinAdministrationTiming: EVERY? (HS | QPC | QAC);

periodBeforeOrAfter:
	numericValue (MINUTE | HOUR) (BEFORE | AFTER);

meals: MEAL | BREAKFAST | LUNCH | DINNER;

//////////////////////////////////////////////////////////////////////////
// Duration
duration:
	durationStandard
	| durationOrdinal
	| durationUnbounded;

durationStandard:
	(FOR | THIS IS A_AN | MUST LAST FOR? | X_X) numericValue period SUPPLY?;

durationOrdinal: ( FOR | ON) THE ordinalNumeric period;

durationUnbounded: THEREAFTER;

//////////////////////////////////////////////////////////////////////////
// Additional Instructions
additionalInstruction: withFood | withLiquid | asDirected | emptyStomach | doNotSwallow;

emptyStomach: ON A_AN? EMPTY_TOKEN STOMACH;

asDirected: AS DIRECTED;

withFood: (BEFORE | AFTER | WITH) (MEAL | FOOD | EATING)
	| AC
	| PC;

withLiquid: WITH (PLENTY OF)? (WATER | MILK | LIQUID);

doNotSwallow: DONOTSWALLOW;

//////////////////////////////////////////////////////////////////////////
// Indication for Use
indicationForUse:
	(FOR | indicationPrecursor) indicationValue
	| indicationPrecursor;

indicationPrecursor: (AS NEEDED | PRN) FOR?;

indicationValue: (
		freeText
		| indicationEnum
		| OR
		| AND
		| TO
		| FORWARDSLASH
		| IN
		| THE
	)+;

indicationEnum:
	COUGH
	| HEADACHE
	| NAUSEA
	| PAIN
	| SLEEP
	| SHORTNESS OF BREATH
	| SOB;

//////////////////////////////////////////////////////////////////////////
// Common rules
ordinalNumeric:
	FIRST
	| SECOND
	| THIRD
	| FOURTH
	| FIFTH
	| SIXTH
	| SEVENTH;

numericValue: NUMBER | wordNumber;

rangeNumericValue: numericValue rangeSeparator numericValue;

rangeNumericValueWithUOM:
	numericValue doseUnitOfMeasure rangeSeparator numericValue doseUnitOfMeasure;

rangeSeparator: TO | DASH;

period: (ordinalNumeric | OTHER)? periodEnum;

periodEnum:
	MILLISECOND
	| SECOND
	| MINUTE
	| HOUR
	| DAY
	| WEEK
	| MONTH
	| YEAR;

dayOfTheWeek:
	MONDAY
	| TUESDAY
	| WEDNESDAY
	| THURSDAY
	| FRIDAY
	| SATURDAY
	| SUNDAY;

periodly: HOURLY | DAILY | WEEKLY | MONTHLY | YEARLY;

wordNumber: wordDigit ((AND A_AN?)? wordDigit)*;

wordDigit:
	ONE
	| TWO
	| THREE
	| FOUR
	| FIVE
	| SIX
	| SEVEN
	| EIGHT
	| NINE
	| TEN
	| TWELVE
	| HALF
	| TWENTY
	| THIRTY
	| FORTY
	| SEVENTY;

medication:
	medicationComponent (FORWARDSLASH medicationComponent)* drugForm? brandName? EOF;
medicationComponent:
	simpleMedicationComponent
	| complexMedicationComponent;

simpleMedicationComponent:
	(description* opioid drugSuffix? | nonOpioid) strength;

complexMedicationComponent:
	strength (opioid drugSuffix | nonOpioid) route? strength;

nonOpioid: description drugSuffix?;

description:
	(WORD | NUMBER | HOUR) (DASH? (WORD | NUMBER | HOUR))*;

drugForm: formExpression+ | WORD+ formExpression+ | formExpression+ WORD+;

opioid:
	BUPRENORPHINE
	| BUTORPHANOL
	| CODEINE
	| DIHYDROCODEINE
	| FENTANYL
	| HYDROCODONE
	| HYDROMORPHONE
	| LEVORPHANOL
	| MEPERIDINE
	| METHADONE
	| MORPHINE
	| OPIUM
	| OXYCODONE
	| OXYMORPHONE
	| PENTAZOCINE
	| TAPENTADOL
	| TRAMADOL;

drugSuffix:
	SULFATE
	| HCL
	| HYDROCHLORIDE
	| BITARTRATE
	| TARTRATE
	| PHOSPHATE
	| POLISTIREX;

strength: numericValue doseUnitOfMeasure;

brandName: BRANDNAME;

freeText: WORD+;

// internal tests: do not reference these rules in the grammar.
testDose: dose+;

testAmbiguousDose: ambiguousDose+;

testFormExpression: formExpression+;

testRoute: route+;

testFrequencies: dose? route? frequencies;

testDuration: duration+;

testAdditionalInstruction: additionalInstruction+;

testIndicationForUse: indicationForUse+;
