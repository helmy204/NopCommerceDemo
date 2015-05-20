using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Authentication
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public partial interface IAuthenticationService
    {
        void SignIn(Customer customer, bool createPersistentCookie);
        void SignOut();
        Customer GetAuthenticatedCustomer();
    }
}
