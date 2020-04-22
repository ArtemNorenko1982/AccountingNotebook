using AccountingNotebook.Common;
using AccountingNotebook.Core.Interfaces;
using AccountingNotebook.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingNotebook.Application.ContainerSettings.Registrations
{
    public class ServicesRegistration : IRegistrationModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
