using apptest.shared.Models;
using apptest.shared.Responses;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
//using apptest.shared.Models;
//using apptest.shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace apptest1.Components
{
    public partial class Loginform : ComponentBase
    {

        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public ILocalStorageService Storage { get; set; }

        private LoginRequest model = new LoginRequest();
        private bool _isBusy = false;
        private string _errorMessage = string.Empty;

        private async Task LoginUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;

            var response = await HttpClient.PostAsJsonAsync("/api/v2/auth/login", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse<LoginResults>>();
                 //Store it in local storage 
                await Storage.SetItemAsStringAsync("access_token", result.value.Token);
                await Storage.SetItemAsync<DateTime>("expiry_date", result.value.ExpiryDate);

                await AuthenticationStateProvider.GetAuthenticationStateAsync();

                Navigation.NavigateTo("/");
            }
            else
            {
                var errorResult = await response.Content.ReadFromJsonAsync<ApiErrorResonse>();
                _errorMessage = errorResult.Message;
            }
            _isBusy = false;
        }

        private void RedirectToRegister()
        {
            Navigation.NavigateTo("/authentication/register");
        }
      

    }
}
