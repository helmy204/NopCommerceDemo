using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Common
{
    // TODO: Not Finished
    public class CommonSettings : ISettings
    {

        /// <summary>
        /// Gets and sets a value indicating whether 404 errors (page or file not found) should be logged
        /// </summary>
        public bool Log404Errors { get; set; }
    }
}
