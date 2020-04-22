using AccountingNotebook.Common;
using AccountingNotebook.Contract.Interfaces;
using AccountingNotebook.Data.Access.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingNotebook.Application.ContainerSettings.Registrations
{
    public class DataCollectionRegistration : IRegistrationModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddScoped(typeof(IAccountingRepository<,>), typeof(AccountingRepository<,>));
        }
    }
}
