using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Affiliates
{
    /// <summary>
    /// Represents an affiliate
    /// </summary>
    public partial class Affiliate : BaseEntity
    {
        //-->>

        //-->>

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// </summary>
        public bool Active { get; set; }

        //-->>
    }
}
