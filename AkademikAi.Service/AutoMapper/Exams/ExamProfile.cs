using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Entites;
using AutoMapper;

namespace AkademikAi.Service.AutoMapper.Exams
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamListDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<Exam, ExamDetailDto>();
            CreateMap<Questions, QuestionDto>();
            CreateMap<QuestionsOptions, QuestionOptionDto>(); 

            CreateMap<ExamCreateDto, Exam>();
        }
    }
}
