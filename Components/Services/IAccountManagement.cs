using Web_Framewk_CA2.Components.Model;

namespace Web_Framewk_CA2.Components.Services
{
    public interface IAccountManagement
    {
        public Task<FormResult> RegisterAsync(string email, string password);
    }
}
