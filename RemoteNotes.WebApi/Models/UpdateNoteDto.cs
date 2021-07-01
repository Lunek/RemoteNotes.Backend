using System;
using AutoMapper;
using RemoteNotes.Application.Common.Mappings;
using RemoteNotes.Application.Notes.Commands.CreateNote;
using RemoteNotes.Application.Notes.Commands.UpdateNote;

namespace RemoteNotes.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(notedDto => notedDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(notedDto => notedDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(notedDto => notedDto.Details));
        }
    }
}