using AutoMapper;
using AptManagement.Data.Models;
using AptManagement.Data.Context.Dapper.DBModels;

namespace AptManagement.Data.Context.Dapper.Config
{
    public class AppModelMapper : Profile
    {
        public AppModelMapper()
        {
            IMappingExpression<DBApartment, Apartment> modelMap = CreateMap<DBApartment, Apartment>();
        }
    }
}