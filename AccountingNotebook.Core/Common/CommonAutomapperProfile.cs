using AccountingNotebook.Contract.DTO;
using AccountingNotebook.Data.Entity;
using AutoMapper;

namespace AccountingNotebook.Core.Common
{
    public class CommonAutomapperProfile : Profile
    {
        public CommonAutomapperProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Account, AccountEntity>().ReverseMap();
        }
    }
}
