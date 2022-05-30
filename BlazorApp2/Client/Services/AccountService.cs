using BlazorApp2.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp2.Client.Services
{
    public class AccountService : IAcountService
    {
        public readonly HttpClient _http;
        public readonly NavigationManager _navigationManager;
        public List<Account> Accounts { get; set; } = new List<Account>();
        public AccountService(HttpClient Http, NavigationManager NavigationManager)
        {
            _http = Http; 
            _navigationManager = NavigationManager;
        }

        public async Task getAccount()
        {
            var result = await _http.GetFromJsonAsync<List<Account>>("api/account");
            if (result != null)
            {
                Accounts = result;
            }
        }
    }
}
