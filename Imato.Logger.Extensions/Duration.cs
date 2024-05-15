using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Imato.Logger.Extensions
{
    public static class Duration
    {
        /// <summary>
        /// Log task task duration. Create warning if maxDuration exceeded
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="task"></param>
        /// <param name="taskName">Log message</param>
        /// <param name="maxDuration"></param>
        /// <returns></returns>
        public static async Task<T> LogDuration<T>(this ILogger logger,
            Func<Task<T>> task,
            string taskName = "",
            int maxDuration = 10_000)
        {
            var now = DateTime.UtcNow;
            logger?.LogInformation(() => $"Start {taskName}");
            var result = await task();

            var time = (DateTime.UtcNow - now).TotalMilliseconds;
            if (time > maxDuration)
            {
                logger?.LogWarning(() => $"{taskName} max duration {maxDuration} exceeded - {time}");
            }

            logger?.LogInformation(() => $"End {taskName}. Duration: {time}");

            return result;
        }

        /// <summary>
        /// Log task task duration. Create warning if maxDuration exceeded
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="task"></param>
        /// <param name="taskName">Log message</param>
        /// <param name="maxDuration"></param>
        /// <returns></returns>
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