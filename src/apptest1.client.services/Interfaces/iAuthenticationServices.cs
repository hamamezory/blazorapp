using apptest.shared.Models;
using apptest.shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apptest1.client.services.Interfaces
{
    public interface iAuthenticationServices
    {
        Task<ApiResponse> RegisterUserAsync(RegisterRequest model);

        // TODO: Migrate login to IAuthenticationService 

    }
}
