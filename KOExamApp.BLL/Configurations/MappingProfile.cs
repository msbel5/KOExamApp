using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KOExamApp.BLL.Dtos;
using KOExamApp.DAL.Models;

namespace KOExamApp.BLL.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Choice, ChoiceDto>();
            CreateMap<ChoiceDto, Choice>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
