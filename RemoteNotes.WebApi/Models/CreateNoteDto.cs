using System.ComponentModel.DataAnnotations;
using AutoMapper;
using RemoteNotes.Application.Common.Mappings;
using RemoteNotes.Application.Notes.Commands.CreateNote;

namespace RemoteNotes.WebApi.Models
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(notedDto => notedDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(notedDto => notedDto.Details));
        }
    }
}