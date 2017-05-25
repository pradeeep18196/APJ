using AutoMapper;
using WebApplication.Areas.Admin.Models;

public class AutoMapperProfileConfiguration : Profile
{
    public AutoMapperProfileConfiguration()
    : this("MyProfile")
    {
    }
    protected AutoMapperProfileConfiguration(string profileName)
    : base(profileName)
    {
        CreateMap<ApplicationViewModel, ApplicationForm>();
        CreateMap<ApplicationForm,ApplicationViewModel>();
    }
}