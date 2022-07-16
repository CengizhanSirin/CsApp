using AutoMapper;
using CsApp.Application.Features.Commands.CreateClient;
using CsApp.Application.Features.Commands.CreateComplaint;
using CsApp.Application.Features.Commands.UpdateClient;
using CsApp.Application.Features.Commands.UpdateComplaint;

namespace CsApp.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Client, Application.Dto.ClientViewDto>().ReverseMap();
            CreateMap<Domain.Entities.Complaint, Application.Dto.ComplaintViewDto>().ReverseMap();

            CreateMap<Domain.Entities.Complaint, Application.Dto.ClientWithComplaintJoinDto>().ReverseMap();

            CreateMap<Domain.Entities.Client, CreateClientCommand>().ReverseMap();
            CreateMap<Domain.Entities.Complaint, CreateComplaintCommand>().ReverseMap();

            CreateMap<Domain.Entities.Client, UpdateClientCommand>().ReverseMap();
            CreateMap<Domain.Entities.Complaint, UpdateComplaintCommand>().ReverseMap();



        }
    }
}
