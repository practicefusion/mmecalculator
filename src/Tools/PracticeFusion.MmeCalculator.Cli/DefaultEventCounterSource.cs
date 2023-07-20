using System;
using System.Diagnostics.Tracing;

namespace PracticeFusion.MmeCalculator.Cli
{
    [EventSource(Name = "MmeCalculator.Cli")]
    public sealed class DefaultEventCounterSource : EventSource
    {
        public static readonly DefaultEventCounterSource Log = new();

        private IncrementingEventCounter _calculationCounter;

        private DefaultEventCounterSource()
        {
            _calculationCounter = new IncrementingEventCounter("calculation-time", this)
            {
                DisplayName = "Calculations/Sec", DisplayRateTimeScale = TimeSpan.FromSeconds(1)
            };
        }

        public void IncrementCalculations()
        {
            _calculationCounter.Increment();
        }

        protected override void Dispose(bool disposing)
        {
            _calculationCounter?.Dispose();
            _calculationCounter = null;

            base.Dispose(disposing);
        }
    }
}