using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using System.Security.Claims;

namespace WebApplication3
{
    public class MyClaimsTransformation : IClaimsTransformation
    {
        private readonly IMyDownstreamService myDownstreamService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="identityService">Authman identity service.</param>
        public MyClaimsTransformation(IMyDownstreamService myDownstreamService)
        {
            this.myDownstreamService = myDownstreamService;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity != null && principal.Identity.IsAuthenticated && principal.Identity.Name != null)
            {
                string accessToken = await myDownstreamService.CallDownstreamServiceAsync();
                Debug.Write(accessToken);
            }
            return principal;
        }
    }
}
