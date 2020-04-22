using System;
using System.Collections.Generic;
using System.Linq;
using AccountingNotebook.Common;
using AccountingNotebook.Core.Common;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingNotebook.Application.ContainerSettings.Registrations
{
    public class AutomapperRegistration : IRegistrationModule
    {
        public void Register(IServiceCollection services)
        {
            var typesWithMappings = new List<Type>()
            {
                typeof(CommonAutomapperProfile)
            };

            var assembliesWithMappings = typesWithMappings.Select(t => t.Assembly);

            services.AddAutoMapper(cfg => cfg.AddCollectionMappers(), assembliesWithMappings);
        }
    }
}
