using System.Threading.Tasks;

namespace TCCApi.VendaApi.Services
{
    public interface IAuthService
    {
        string BaseUrl { get; }

        Task<string> AuthenticateAsync();
    }
}