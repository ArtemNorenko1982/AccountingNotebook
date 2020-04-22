using Microsoft.Extensions.DependencyInjection;

namespace AccountingNotebook.Common
{
    public interface IRegistrationModule
    {
        void Register(IServiceCollection services);
    }
}
