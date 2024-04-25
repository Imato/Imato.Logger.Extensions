using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Imato.Logger.Extensions
{
    public static class Extensions
    {
        public static async Task<T> LogDuration<T>(this ILogger logger,
            Func<Task<T>> task,
            string taskName = "",
            int maxDuration = 10_000)
        {
            var now = DateTime.UtcNow;
            if (logger?.IsEnabled(LogLevel.Debug) == true)
            {
                logger?.LogInformation($"Start {taskName}");
            }
            var result = await task();

            var time = (DateTime.UtcNow - now).TotalMilliseconds;
            if (time > maxDuration)
            {
                logger?.LogWarning($"{taskName} max duration {maxDuration} exceeded - {time}");
            }

            if (logger?.IsEnabled(LogLevel.Debug) == true)
            {
                logger?.LogInformation($"End {taskName}. Duration: {time}");
            }

            return result;
        }

        public static async Task LogDuration(this ILogger logger,
            Func<Task> task,
            string taskName = "",
            int maxDuration = 10_000)
        {
            await LogDuration(logger,
                async () =>
                {
                    await task();
                    return Task.FromResult(true);
                },
                taskName, maxDuration);
        }
    }
}