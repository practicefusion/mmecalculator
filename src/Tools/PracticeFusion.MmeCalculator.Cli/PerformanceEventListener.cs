using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace PracticeFusion.MmeCalculator.Cli
{
    internal class PerformanceEventListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name.Equals(DefaultEventCounterSource.Log.Name))
            {
                EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All,
                    new Dictionary<string, string> { ["EventCounterIntervalSec"] = "1" });
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (!eventData.EventName!.Equals("EventCounters"))
            {
                return;
            }

            var metrics = new List<(string, string)>();
            for (var i = 0; i < eventData.Payload!.Count; i++)
            {
                if (eventData.Payload[i] is IDictionary<string, object> eventPayload)
                {
                    metrics.Add(GetRelevantMetric(eventPayload));
                }
            }

            Console.Error.Write($"\r{string.Join(", ", metrics.Select(x => $"{x.Item1} : {x.Item2}"))}   ");
        }

        private static (string counterName, string counterValue) GetRelevantMetric(
            IDictionary<string, object> eventPayload)
        {
            var counterName = "";
            var counterValue = "";

            if (eventPayload.TryGetValue("DisplayName", out var displayValue))
            {
                counterName = displayValue.ToString();
            }

            if (eventPayload.TryGetValue("Increment", out var value))
            {
                counterValue = ((double)value).ToString("0.##");
            }

            return (counterName, counterValue);
        }
    }
}