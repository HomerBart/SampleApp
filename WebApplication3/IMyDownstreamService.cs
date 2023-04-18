namespace WebApplication3
{
    public interface IMyDownstreamService
    {
        Task<string> CallDownstreamServiceAsync();
    }
}
