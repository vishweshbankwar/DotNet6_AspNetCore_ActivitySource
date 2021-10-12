using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestDotnet6ActivitySource
{
    public class ActivityExportService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                var listener = new ActivityListener
                {
                    ShouldListenTo = _ => true,
                    Sample = (ref ActivityCreationOptions<ActivityContext> options) => ComputeActivitySamplingResult(options),
                    ActivityStarted = (activity) =>
                    {
                        Console.WriteLine("Activity Started:");
                        Console.WriteLine("ParentId: " + activity.ParentId);
                        Console.WriteLine("ParentSpanId:" + activity.ParentSpanId);
                        Console.WriteLine("Activity TraceId: " + activity.TraceId);
                    },

                    // Callback when Activity is stopped.
                    ActivityStopped = (activity) =>
                    {
                        Console.WriteLine("Activity Stopped");
                    },
                };
                ActivitySource.AddActivityListener(listener);
            }
            catch (Exception ex)
            {

            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private static ActivitySamplingResult ComputeActivitySamplingResult(
        in ActivityCreationOptions<ActivityContext> options)
        {
            var traceID = options.TraceId; // traceId here will be the traceId for created Activity.
            var parent = options.Parent; // Parent not available here.

            return ActivitySamplingResult.AllDataAndRecorded;
        }
    }
}
