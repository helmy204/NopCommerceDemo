using Nop.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Security
{
    /// <summary>
    /// Permission service interface
    /// </summary>
    public partial interface IPermissionService
    {
        //-->>

        //-->>

        //-->>

        //-->>

        //-->>

        //-->>

        //-->>

        //-->>

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <returns>true - authorized; otherwise, false</returns>
        bool Authorize(PermissionRecord permission);

        //-->>

        //-->>

        //-->>
    }
}
