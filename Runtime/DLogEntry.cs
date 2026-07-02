using System;
using System.Collections.Generic;

namespace DraasGames.Logging
{
    /// <summary>
    /// A single structured log record carried by <see cref="DLogger.MessageLogged"/>.
    /// Holds everything a console-style view needs to render and filter a message, including a
    /// <see cref="Tags"/> slot that stays empty until DLogger gains tag support — so tag filtering
    /// can be added later without touching the capture pipeline or <see cref="ILoggerService"/>.
    /// </summary>
    public readonly struct DLogEntry
    {
        /// <summary>
        /// Gets message log level.
        /// </summary>
        public DLogLevel Level { get; }

        /// <summary>
        /// Gets message passet to the log entry.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets Type name of the sender object, or <c>null</c> when none was provided.
        /// </summary>
        public string Sender { get; }

        /// <summary>
        /// Gets the exception for <see cref="DLogger.LogException"/> entries; otherwise <c>null</c>.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>Tags attached to the message. Never <c>null</c>; empty until DLogger supports tags.</summary>
        public IReadOnlyList<string> Tags { get; }

        public DLogEntry(
            DLogLevel level,
            string message,
            string sender = null,
            Exception exception = null,
            IReadOnlyList<string> tags = null)
        {
            Level = level;
            Message = message;
            Sender = sender;
            Exception = exception;
            Tags = tags ?? Array.Empty<string>();
        }
    }
}
