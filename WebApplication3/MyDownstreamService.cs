using Microsoft.Identity.Web;

namespace WebApplication3
{
    public class MyDownstreamService : IMyDownstreamService
    {
        private readonly IConfiguration config;
        private readonly ITokenAcquisition tokenAcquisitionService;

        public MyDownstreamService(IConfiguration config, ITokenAcquisition tokenAcquisitionService)
        {
            this.config = config;
            this.tokenAcquisitionService = tokenAcquisitionService;
        }

        public async Task<string> CallDownstreamServiceAsync()
        {
            string scope = config.GetValue<string>("MyDownstreamService:Scopes")!;
            string accessToken = await tokenAcquisitionService.GetAccessTokenForUserAsync(new string[] { scope });
            return accessToken;
        }
    }
}
