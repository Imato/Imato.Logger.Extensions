using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
        /// <param name="maxDuration">Create warning after</param>
        /// <returns></returns>
        public static async Task<T> LogDuration<T>(this ILogger logger,
            Func<Task<T>> task,
            string taskName = "",
            int maxDuration = 10_000)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            logger?.LogInformation(() => $"Start {taskName}");
            var result = await task();

            stopWatch.Stop();
            if (stopWatch.ElapsedMilliseconds > maxDuration)
            {
                logger?.LogWarning(() => $"{taskName} max duration {maxDuration} ms exceeded - {stopWatch.ElapsedMilliseconds} ms");
            }

            logger?.LogInformation(() => $"End {taskName}. Duration: {stopWatch.ElapsedMilliseconds}");

            return result;
        }

        public static T LogDuration<T>(this ILogger logger,
            Func<T> task,
            string taskName = "",
            int maxDuration = 10_000)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            logger?.LogInformation(() => $"Start {taskName}");
            var result = task();

            stopWatch.Stop();
            if (stopWatch.ElapsedMilliseconds > maxDuration)
            {
                logger?.LogWarning(() => $"{taskName} max duration {maxDuration} ms exceeded - {stopWatch.ElapsedMilliseconds} ms");
            }

            logger?.LogInformation(() => $"End {taskName}. Duration: {stopWatch.ElapsedMilliseconds}");

            return result;
        }

        /// <summary>
        /// Log task task duration. Create warning if maxDuration exceeded
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="task"></param>
        /// <param name="taskName">Log message</param>
        /// <param name="maxDuration">Create warning after</param>
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

        /// <summary>
        /// Log task task duration. Create warning if maxDuration exceeded
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="task"></param>
        /// <param name="taskName">Log message</param>
        /// <param name="maxDuration">Create warning after</param>
        /// <returns></returns>
        public static void LogDuration(this ILogger logger,
            Action task,
            string taskName = "",
            int maxDuration = 10_000)
        {
            LogDuration(logger,
                () =>
                {
                    task();
                    return true;
                },
                taskName, maxDuration);
        }
    }
}