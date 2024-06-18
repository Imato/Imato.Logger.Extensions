using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Imato.Logger.Extensions
{
    public static class Log
    {
        public static void LogTrace(this ILogger logger, Func<object> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.LogTrace(messageFactory().Serialize());
            }
        }

        public static void LogDebug(this ILogger logger, Func<object> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(messageFactory().Serialize());
            }
        }

        public static void LogInformation(this ILogger logger, Func<object> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(messageFactory().Serialize());
            }
        }

        public static void LogWarning(this ILogger logger, Func<object> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Warning))
            {
                logger.LogWarning(messageFactory().Serialize());
            }
        }

        public static void LogError(this ILogger logger, Func<object> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError(messageFactory().Serialize());
            }
        }

        public static void LogCritical(this ILogger logger, Func<object> messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Critical))
            {
                logger.LogCritical(messageFactory().Serialize());
            }
        }

        private static object[] JsonArgs(object[]? args)
        {
            if (args == null)
            {
                return Array.Empty<object>();
            }
            return args
                    .Select(x => Json.Serialize(x))
                    .ToArray();
        }

        public static void LogTrace(this ILogger logger, Func<object> messageFactory, params object[] args)
        {
            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.LogTrace(messageFactory().Serialize(), JsonArgs(args));
            }
        }

        public static void LogDebug(this ILogger logger, Func<object> messageFactory, params object[] args)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(messageFactory().Serialize(), JsonArgs(args));
            }
        }

        public static void LogInformation(this ILogger logger, Func<object> messageFactory, params object[] args)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(messageFactory().Serialize(), JsonArgs(args));
            }
        }

        public static void LogWarning(this ILogger logger, Func<object> messageFactory, params object[] args)
        {
            if (logger.IsEnabled(LogLevel.Warning))
            {
                logger.LogWarning(messageFactory().Serialize(), JsonArgs(args));
            }
        }

        public static void LogError(this ILogger logger, Func<object> messageFactory, params object[] args)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError(messageFactory().Serialize(), JsonArgs(args));
            }
        }

        public static void LogCritical(this ILogger logger, Func<object> messageFactory, params object[] args)
        {
            if (logger.IsEnabled(LogLevel.Critical))
            {
                logger.LogCritical(messageFactory().Serialize(), JsonArgs(args));
            }
        }

        public static void LogTrace(this ILogger logger, Exception exception, Func<object>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.LogTrace(exception, messageFactory != null ? messageFactory().Serialize() : null);
            }
        }

        public static void LogDebug(this ILogger logger, Exception exception, Func<object>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug(exception, messageFactory != null ? messageFactory().Serialize() : null);
            }
        }

        public static void LogInformation(this ILogger logger, Exception exception, Func<object>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation(exception, messageFactory != null ? messageFactory().Serialize() : null);
            }
        }

        public static void LogWarning(this ILogger logger, Exception exception, Func<object>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Warning))
            {
                logger.LogWarning(exception, messageFactory != null ? messageFactory().Serialize() : null);
            }
        }

        public static void LogError(this ILogger logger, Exception exception, Func<object>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError(exception, messageFactory != null ? messageFactory().Serialize() : null);
            }
        }

        public static void LogCritical(this ILogger logger, Exception exception, Func<object>? messageFactory)
        {
            if (logger.IsEnabled(LogLevel.Critical))
            {
                logger.LogCritical(exception, messageFactory != null ? messageFactory().Serialize() : null);
            }
        }
    }
}