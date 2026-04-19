using AutoMapper;
using Peerly.Gateway.Api.Models.Homeworks;
using Proto = Peerly.Core.V1;

namespace Peerly.Gateway.Api.Features.Students.GetStudentHomework;

public sealed class GetStudentHomeworkProfile : Profile
{
    public GetStudentHomeworkProfile()
    {
        CreateMap<GetStudentHomeworkQuery, Proto.V1GetStudentHomeworkRequest>();
        CreateMap<Proto.V1GetStudentHomeworkResponse, GetStudentHomeworkQueryResponse>();
        CreateMap<Proto.HomeworkInfo, HomeworkInfo>();
    }
}
