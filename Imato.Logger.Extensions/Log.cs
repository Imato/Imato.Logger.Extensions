using Microsoft.Extensions.Logging;
using System;

namespace Imato.Logger.Extensions
{
    public static class Log
    {
        public static void LogTrace(this ILogger logger, Func<string> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.LogTrace(messageFactory());
            }
        }

        public static void LogDebug(this ILogger logger, Func<string> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(messageFactory());
            }
        }

        public static void LogInformation(this ILogger logger, Func<string> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(messageFactory());
            }
        }

        public static void LogWarning(this ILogger logger, Func<string> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Warning))
            {
                logger.LogWarning(messageFactory());
            }
        }

        public static void LogError(this ILogger logger, Func<string> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError(messageFactory());
            }
        }

        public static void LogCritical(this ILogger logger, Func<string> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Critical))
            {
                logger.LogCritical(messageFactory());
            }
        }

        public static void LogTrace(this ILogger logger, Exception exception, Func<string>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.LogTrace(exception, messageFactory != null ? messageFactory() : null);
            }
        }

        public static void LogDebug(this ILogger logger, Exception exception, Func<string>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(exception, messageFactory != null ? messageFactory() : null);
            }
        }

        public static void LogInformation(this ILogger logger, Exception exception, Func<string>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(exception, messageFactory != null ? messageFactory() : null);
            }
        }

        public static void LogWarning(this ILogger logger, Exception exception, Func<string>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Warning))
            {
                logger.LogWarning(exception, messageFactory != null ? messageFactory() : null);
            }
        }

        public static void LogError(this ILogger logger, Exception exception, Func<string>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError(exception, messageFactory != null ? messageFactory() : null);
            }
        }

        public static void LogCritical(this ILogger logger, Exception exception, Func<string>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Critical))
            {
                logger.LogCritical(exception, messageFactory != null ? messageFactory() : null);
            }
        }
    }
}