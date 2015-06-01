using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Events
{
    /// <summary>
    /// Event Publisher
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Publish event
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="eventMessage">Event Message</param>
        void Publish<T>(T eventMessage);
    }
}
