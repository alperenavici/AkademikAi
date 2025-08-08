using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AutoMapper;

namespace AkademikAi.Service.AutoMapper.Exams
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, ExamListDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.ParticipantCount, opt => opt.MapFrom(src => src.Participants.Count()));

            CreateMap<Exam, ExamDetailDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.DurationMinutes, opt => opt.MapFrom(src => src.DurationMinutes))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => 
                    src.ExamQuestions != null ? 
                    src.ExamQuestions.OrderBy(eq => eq.QuestionOrder).Select(eq => eq.Question).ToList() : 
                    new List<Questions>()));
            
            CreateMap<Questions, QuestionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.QuestionText))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => 
                    src.QuestionsOptions != null ? 
                    src.QuestionsOptions.OrderBy(o => o.OptionOrder).ToList() : 
                    new List<QuestionsOptions>()));
                
            CreateMap<QuestionsOptions, QuestionOptionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OptionText, opt => opt.MapFrom(src => src.OptionText))
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Label)); 

            CreateMap<ExamCreateDto, Exam>();
        }
    }
}
