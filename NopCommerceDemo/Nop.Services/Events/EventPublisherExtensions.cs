using Nop.Core;
using Nop.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Events
{
    public static class EventPublisherExtensions
    {
        //-->>

        public static void EntityUpdated<T>(this IEventPublisher eventPublisher,T entity) where T:BaseEntity
        {
            eventPublisher.Publish(new EntityUpdated<T>(entity));
        }

        //-->>
    }
}
