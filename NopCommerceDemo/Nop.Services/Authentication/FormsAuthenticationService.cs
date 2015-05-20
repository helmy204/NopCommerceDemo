using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Authentication
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public partial class FormsAuthenticationService : IAuthenticationService
    {
        public void SignIn(Core.Domain.Customers.Customer customer, bool createPersistentCookie)
        {
            throw new NotImplementedException();
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }

        public virtual Customer GetAuthenticatedCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
