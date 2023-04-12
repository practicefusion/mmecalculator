lexer grammar DefaultLexer;

OPEN_PAREN: '(';
CLOSE_PAREN: ')';
DOT: '.';
DASH: '-';
FORWARDSLASH: '/';
COMMA: ',';

fragment A: [aA];
fragment B: [bB];
fragment C: [cC];
fragment D: [dD];
fragment E: [eE];
fragment F: [fF];
fragment G: [gG];
fragment H: [hH];
fragment I: [iI];
fragment J: [jJ];
fragment K: [kK];
fragment L: [lL];
fragment M: [mM];
fragment N: [nN];
fragment O: [oO];
fragment P: [pP];
fragment Q: [qQ];
fragment R: [rR];
fragment S: [sS];
fragment T: [tT];
fragment U: [uU];
fragment V: [vV];
fragment W: [wW];
fragment X: [xX];
fragment Y: [yY];
fragment Z: [zZ];

fragment DIGIT: [0-9];
fragment NUMERICCOMMA: ',';
fragment NUMERIC:
	DIGIT+ (NUMERICCOMMA DIGIT+)* (DOT DIGIT+)?
	| DOT DIGIT+
	| DIGIT+ FORWARDSLASH DIGIT+;

// numbers
HALF: H A L F;
ONE: O N E;
ONCE: O N C E;
TWO: T W O;
TWICE: T W I C E;
THREE: T H R E E;
THRICE: T H R I C E;
FOUR: F O U R;
FIVE: F I V E;
SIX: S I X;
SEVEN: S E V E N;
EIGHT: E I G H T;
NINE: N I N E;
TEN: T E N;
TWELVE: T W E L V E;
TWENTY: T W E N T Y;
THIRTY: T H I R T Y;
FORTY: F O U? R T Y;
SEVENTY: S E V E N T Y;

// ordinal numbers
FIRST: F I R S T;
// SECOND already defined
THIRD: T H I R D;
FOURTH: F O U R T H;
FIFTH: F I F T H;
SIXTH: S I X T H;
SEVENTH: S E V E N T H;

// number expressions
NUMBER: NUMERIC;

CLOCKNUMBER: DIGIT+ ':' DIGIT+;

// general
A_AN: A | A N;
ADMINISTER: A D M I N I S T E R;
AFTERNOON: A F T E R N O O N;
AFTER: A F T E R;
AM: A M;
AND: A N D;
APPLY: A P P L Y;
AS: A S;
AT: A T;
BEDTIME: B E D ' '? T I M E;
BREAKFAST: B R E A K F A S T;
BREATH: B R E A T H;
BEFORE: B E F O R E;
BY: B Y;
CHANGE: C H A N G E;
CHEW: C H E W;
COUGH: C O U G H;
DINNER: D I N N E R;
DIRECTED: D I R E C T E D;
DISSOLVE: D I S S O L V E;
EATING: E A T I N G;
INHALE: I N H A L E;
INFUSE: I N F U S E;
INJECT: I N J E C T;
INSERT: I N S E R T;
IS: I S;
EACH: E A | E A C H;
// would prefer to use "EMPTY" but that causes
// a CS0108 warning with ParserRuleContext.EMPTY
EMPTY_TOKEN: E M P T Y;
EVENING: E V E N I N G;
EVERY: E V E R Y;
FOOD: F O O D;
FOR: F O R;
GIVE: G I V E;
HEADACHE: H E A D A C H E;
IN: I N;
LAST: L A S T;
LIQUID: L I Q U I D S?;
LUNCH: L U N C H;
MAXIMUM: M A X | M A X I M U M;
MEAL: M E A L S?;
MIDDAY: M I D ' '? D A Y;
MILK: M I L K;
MORNING: M O R N I N G;
MUST: M U S T;
NAUSEA: N A U S E A;
NEEDED: N E E D E D;
NIGHT: N I G H T;
NOON: N O O N;
NOSTRIL: N O S T R I L S?;
OF: O F;
ON: O N;
OR: O R;
OTHER: O T H E R;
PAIN: P A I N;
PLACE: P L A C E;
PLENTY: P L E N T Y;
PER: P E R;
PM: P M;
SHORTNESS: S H O R T N E S S;
SLEEP: S L E E P;
SOB: S O B;
STOMACH: S T O M A C H;
SUCK: S U C K;
SUPPLY: S U P P L Y;
SWALLOW: S W A L L O W;
TAKE: T A K E;
THE: T H E;
THEN: T H E N;
THIS: T H I S;
THEREAFTER: T H E R E A F T E R;
TIME: T I M E;
TIMES: T I M E S;
TO: T O;
UNDER: U N D E R;
UP: U P;
USE: U S E;
VIA: V I A;
WATER: W A T E R;
WITH: W I T H;
X_X: X;

// latin & abbreviations
AC: A DOT? C DOT?;
BID: B (DOT | ' ')? I (DOT | ' ')? D DOT?;
HS: H DOT? S DOT?;
PC: P DOT? C DOT?;
PRN: P DOT? R DOT? N DOT?;
Q_Q: Q;
QAC: Q DOT? A DOT? C DOT?;
QAD: Q DOT? A DOT? D DOT?;
QAM: Q DOT? A DOT? M DOT?;
QD: Q DOT? D DOT?;
QH: Q DOT? H DOT?;
QHS: Q (DOT | ' ')? H (DOT | ' ')? S DOT?;
QID: Q (DOT | ' ')? I (DOT | ' ')? D DOT?;
QN: Q DOT? N DOT?;
QOD: Q DOT? O DOT? D DOT?;
QPC: Q DOT? P DOT? C DOT?;
QPM: Q DOT? P DOT? M DOT?;
TID: T (DOT | ' ')? I (DOT | ' ')? D DOT?;

// forms
APPLICATION: A P P L I C A T I O N S?;
CAPSULE: C A P S? | C A P S U L E S?;
CARTRIDGE: C A R T R I D G E S?;
DOSE: D O S E S? ;
DROP: D R O P S?;
ELIXIR: E L I X I R?;
FILM: F I L M S?;
INJECTION: I N J E C T I O N S?;
LOLLIPOP: L O L L I P O P S?;
LOZENGE: L O Z E N G E S?;
PATCH: P A T C H (E S)?;
PIECE: P I E C E S?;
PILL: P I L L S?;
PUFF: P U F F S?;
SOLUTION: S O L (N | U T I O N);
SPRAY: S P R A Y S?;
SUPPOSITORY: S U P P O S I T O R ( Y | I E S);
SUSPENSION: S U S P E N S I O N;
SYRINGE: S Y R I N G E S?;
SYRUP: S Y R U P;
SYSTEM: S Y S T E M;
TABLET:
	T A? B? S?
	| T B L T S?
	| T A B L E T S?
	| T A L B E T S?
	| T A B E T S?
	| T A G L E T S?;
TROCHE: T R O C H E S?;
TDP: T D P;

// route and forms
BUCCAL: B U C C A L;
INJECTABLE: I N J E C T A B L E;
NASAL: N A S A L;
NASALLY: NASAL L Y;
ORAL: O R A L;
ORALLY: ORAL L Y;
PO: P (DOT | ' ')? O DOT?;
SL: S DOT? L DOT?;
SUBLINGUAL: S U B L I N G U A L;
SUBLINGUALLY: SUBLINGUAL L Y;
TRANSDERMAL: T R A N S D E R M A L?;
TRANSDERMALLY: TRANSDERMAL L Y;

// routes
MOUTH: M O U T H;
FEEDING: F E E D I N G;
TUBE: T U B E;
TONGUE: T O N G U E;
GASTROSTOMY: G A S T R O S T O M Y;
RECTAL: R E C T A L;
RECTALLY: RECTAL L Y;
INHALED: I N H A L E D;
TOPICAL: T O P I C A L;
TOPICALLY: TOPICAL L Y;
INTRANASALLY: I N T R A N A S A L L Y;
TOSKIN: T O ' ' (T H E ' ')? S K I N;
ONSKIN: O N ' ' (T H E ' ')? S K I N;
TOUPPERTORSO: T O ' ' (T H E ' ')? U P P E R ' ' T O R S O;

// periods
MILLISECOND: M S | M I L L I S E C O N D S?;
SECOND: S | S E C S? | S E C O N D S?;
MINUTE: M | M I? N S? | M I N U T E S?;
HOUR: H | H R S? | H O U R S?;
DAY: D | D Y S? | D A Y S?;
WEEK: W | W K S? | W E E K S?;
MONTH: M O N T H S?;
YEAR: Y | Y R S? | Y E A R S?;

// periodly
HOURLY: H O U R L Y;
DAILY: D A I L Y;
WEEKLY: W E E K L Y;
MONTHLY: M O N T H L Y;
YEARLY: A N N U A L L Y | Y E A R L Y;

// days of the week
MONDAY: M O N (D A Y S?)?;
TUESDAY: T U E (S D A Y S?)?;
WEDNESDAY: W E D (N E S D A Y S?)?;
THURSDAY: T H U (R S D A Y S?)?;
FRIDAY: F R I (D A Y S?)?;
SATURDAY: S A T (U R D A Y S?)?;
SUNDAY: S U N (D A Y S?)?;

// units of measure
CENTIMETERS: C M S? | C E N T I M E T (E R S? | R E S?);
CUBICCENTIMETERS: C C S?;
GRAMS: G M? S? | G R A M S?;
INTERNATIONALUNITS:
	I U S?
	| I N T E R N A T I O N A L (' ')+ U N I T S?
	| U N I T S?;
LITERS: L | L I T E R S?;
MILLIEQUIVALENTS: M E Q S? | M I L L I E Q U I V A L E N T S?;
MICROGRAMSPERHOUR: M C G FORWARDSLASH H R;
MICROGRAMSPERACT:
	M C G FORWARDSLASH (
		(A C T (U A T (I O N)?)? S?)
		| S P R A Y S?
	);
MICROGRAMS: M C G | M I C R O G R A M S?;
MILLIGRAMSPERHOUR: M G FORWARDSLASH H R;
MILLIGRAMSPERACT:
	M G FORWARDSLASH (
		(A C T (U A T (I O N)?)? S?)
		| S P R A Y S?
	);
MILLIGRAMSPERML: M G FORWARDSLASH M L;
MILLIGRAMS: M G S? | M I L L I G R A M (M E)? S?;
MILLILITERS: M L S? | M I L L I L I T (E R S? | R E S?);
OUNCES: O Z | O U N C E S?;
TABLESPOONS: T B S P S? | T B L S | T A B L E S P O O N S?;
TEASPOONS: T E A S? | T S P S? | T E A S P O O N S?;

// opioid
BUPRENORPHINE: B U P R E N O R P H I N E;
BUTORPHANOL: B U T O R P H A N O L;
CODEINE: C O D E I N E;
DIHYDROCODEINE: D I H Y D R O C O D E I N E;
FENTANYL: F E N T A N Y L;
HYDROCODONE: H Y D R O C O D O N E;
HYDROMORPHONE: H Y D R O M O R P H O N E;
LEVORPHANOL: L E V O R P H A N O L;
MEPERIDINE: M E P E R I D I N E;
METHADONE: M E T H A D O N E;
MORPHINE: M O R P H I N E;
OPIUM: O P I U M;
OXYCODONE: O X Y C O D O N E;
OXYMORPHONE: O X Y M O R P H O N E;
PENTAZOCINE: P E N T A Z O C I N E;
TAPENTADOL: T A P E N T A D O L;
TRAMADOL: T R A M A D O L;

// opioid suffixes
SULFATE: S U L F A T E;
HCL: H C L;
HYDROCHLORIDE: H Y D R O C H L O R I D E;
BITARTRATE: B I T A R T R A T E;
TARTRATE: T A R T R A T E;
PHOSPHATE: P H O S P H A T E;
POLISTIREX: P O L I S T I R E X;

// additional instructions
DONOTSWALLOW: D O ' ' N O T ' ' S W A L L O W;

// ignore whitespace
WS: [ \r\t\n,]+ -> skip;

WORD: [a-zA-Z]+ | [a-zA-Z]+ DASH [a-zA-Z]+;

BRANDNAME: '[' ANYTOKEN+ ']';

ANYTOKEN: .;