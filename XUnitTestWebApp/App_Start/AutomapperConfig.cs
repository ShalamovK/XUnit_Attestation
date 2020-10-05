using AutoMapper;
using Common.Models.Dtos;
using Common.Models.Entities;
using XUnitTestWebApp.Models;

namespace XUnitTestWebApp.App_Start {
    public class AutomapperConfig {
    }

    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateBllMappings();
            CreateViewMappings();
        }

        public void CreateBllMappings() {
            CreateMap<InvoiceLine, InvoiceLineDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
        }

        public void CreateViewMappings() {
            CreateMap<InvoiceLineDto, InvoiceLineViewModel>().ReverseMap();
            CreateMap<InvoiceDto, InvoiceViewModel>().ReverseMap();
        }
    }
}
