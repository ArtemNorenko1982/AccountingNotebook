using AccountingNotebook.Common;
using AccountingNotebook.Data.Access.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingNotebook.Application.ContainerSettings.Registrations
{
    public class DbRegistration : IRegistrationModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddDbContext<AccountNotebookContext>(x => x.UseInMemoryDatabase(databaseName: "Accounting"));
        }
    }
}
