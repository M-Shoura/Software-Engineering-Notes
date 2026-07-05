using AutoMapper;
using IKIA.BLL.DTOs.Departments;
using IKIA.PL.ViewModels.Departments;

namespace IKIA.PL.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region Department

            CreateMap<DepartmentViewModel,CreatedDepartmentDTO>();
            CreateMap<DepartmentViewModel,UpdatedDepartmentDTO>();
            CreateMap<DepartmentDetailsToReturnDTO,DepartmentViewModel>();

            // // if the names of properties are not the same then we must configure this by: 
            // CreateMap<DepartmentDetailsToReturnDTO,DepartmentViewModel>()
            //     .ForMember(dest => dest.Code , config => config.MapFrom(src => src.Code));      
            //      // this is done for each and every property .. with properties with the same names and types

            // if we want to map the reverse .. 
            // then use .ReverseMap(); 

            // // Ex: if the names of some properties are not the same and we want to use Reverse also 
            // CreateMap<DepartmentDetailsToReturnDTO, DepartmentViewModel>()
            //     .ForMember(dest => dest.Codexxx, config => config.MapFrom(src => src.Code))
            //     .ReverseMap()
            //     .ForMember(dest => dest.Code, config => config.MapFrom(src => src.Codexxx));
           

            #endregion


            #region Employee

            #endregion


        }
    }
}
