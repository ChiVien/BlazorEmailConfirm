using BlazorApp2.Shared;
namespace BlazorApp2.Client.Services
{
    public interface IAcountService
    {
        List<Account> Accounts { get; set; }
        Task getAccount();
    }
}
