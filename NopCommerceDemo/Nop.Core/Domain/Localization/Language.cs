using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// Represents a language
    /// </summary>
    public partial class Language:BaseEntity,IStoreMappingSupported
    {
        

        public bool LimitedToStores
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
