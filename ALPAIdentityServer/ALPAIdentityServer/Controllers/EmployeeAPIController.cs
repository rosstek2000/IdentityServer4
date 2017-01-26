using System.Web.Http;
using System.Collections.Generic;
using ALPAIdentityServer.Models;

namespace ALPAIdentityServer.Controllers
{
    [Authorize]
    public class EmployeeAPIController : ApiController
    {
        public List<Employee> Get()
        {
            return new EmployeeDatabase();
        }
    }
}
