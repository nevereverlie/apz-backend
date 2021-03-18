using Apz_backend.Models;
using Apz_backend.Models.DB;
using Apz_backend.Models.OAS;
using AutoMapper;

namespace Apz_backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, OasUser>();
            CreateMap<OasUser, User>();
            CreateMap<Medication, OasMedication>();
        }
    }
}