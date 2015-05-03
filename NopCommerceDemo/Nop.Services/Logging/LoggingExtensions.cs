using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nop.Services.Logging
{
    // TODO: Not finished
    public static class LoggingExtensions
    {

        // TODO: Here
        public static void Error(this ILogger logger, string message, Exception exception = null, Customer customer = null)
        {
            FilteredLog(logger, LogLevel.Error, message, exception, customer);
        }

        private static void FilteredLog(ILogger logger, LogLevel level, string message, Exception exception = null, Customer customer = null)
        {
            // don't log thread abort exception
            if (exception is ThreadAbortException)
                return;

            if(logger.IsEnabled(level))
            {
                string fullMessage = exception == null ? string.Empty : exception.ToString();
                logger.InsertLog(level, message, fullMessage, customer);
            }
        }
    }
}
