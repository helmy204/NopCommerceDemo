using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Logging
{
    /// <summary>
    /// Default logger
    /// </summary>
    public partial class DefaultLogger : ILogger
    {
        #region Fields

        private readonly IWebHelper _webHelper;

        private readonly CommonSettings _commonSettings;

        #endregion Fields

        #region Utilities

        /// <summary>
        /// Gets a value indicating whether this message should not be logged
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>Result</returns>
        protected virtual bool IgnoreLog(string message)
        {
            if (_commonSettings.IgnoreLogWordList.Count == 0)
                return false;

            if (String.IsNullOrWhiteSpace(message))
                return false;

            return _commonSettings
                .IgnoreLogWordList
                .Any(x => message.IndexOf(x, StringComparison.InvariantCultureIgnoreCase) >= 0);
        }

        #endregion Utilities

        public bool IsEnabled(Core.Domain.Logging.LogLevel level)
        {
            throw new NotImplementedException();
        }

        public void DeleteLog(Core.Domain.Logging.Log log)
        {
            throw new NotImplementedException();
        }

        public void ClearLog()
        {
            throw new NotImplementedException();
        }

        public Core.IPagedList<Core.Domain.Logging.Log> GetAllLogs(DateTime? fromUtc, DateTime? toUtc, string message, Core.Domain.Logging.LogLevel? logLevel, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Core.Domain.Logging.Log GetLogById(int logId)
        {
            throw new NotImplementedException();
        }

        public IList<Core.Domain.Logging.Log> GetLogByIds(int[] logIds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logLevel">Log Level</param>
        /// <param name="shortMessage">The short message</param>
        /// <param name="fullMessage">The full message</param>
        /// <param name="customer">The customer to associate log record with</param>
        /// <returns>A log item</returns>
        public virtual Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", Customer customer = null)
        {
            // check ignore word/phrase list?
            if (IgnoreLog(shortMessage) || IgnoreLog(fullMessage))
                return null;

            var log = new Log
            {
                LogLevel = logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                IpAddress = _webHelper.GetCurrentIpAddress(),
                Customer = customer//,
                //PageUrl
            };




            return log;
        }
    }
}
