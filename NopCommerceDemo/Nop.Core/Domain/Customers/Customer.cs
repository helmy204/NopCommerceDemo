using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Customers
{
    // TODO: Not Finished
    /// <summary>
    /// Represents a customer
    /// </summary>
    public partial class Customer : BaseEntity
    {

        /// <summary>
        /// Gets or sets the customer system name
        /// </summary>
        public string SystemName { get; set; }
    }
}
