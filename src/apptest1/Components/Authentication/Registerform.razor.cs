using apptest.shared.Models;
using apptest1.client.services.Exceptions;
using apptest1.client.services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apptest1.Components
{
    public partial  class Registerform
    {

        [Inject]
        public iAuthenticationServices AuthenticationService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private RegisterRequest _model = new();
        private bool _isBusy = false;
        private string _errorMessage = string.Empty;

        private async Task RegisterUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;

            try
            {
                await AuthenticationService.RegisterUserAsync(_model);
                Navigation.NavigateTo("/authentication/login");
            }
            catch (ApiException ex)
            {
                // Hanlde the errors of the aPI 
                // TODO: Log those errors 
                _errorMessage = ex.ApiErrorResponse.Message;
            }
            catch (Exception ex)
            {
                // Handle errors 
                _errorMessage = ex.Message;
            }

            _isBusy = false;
        }

        private void RedirectToLogin()
        {
            Navigation.NavigateTo("/authentication/login");
        }
    }
}
