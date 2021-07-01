using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RemoteNotes.Application.Notes.Queries.GetNoteList;
using RemoteNotes.Persistence;
using RemoteNotes.Tests.Common;
using Xunit;
using Shouldly;

namespace RemoteNotes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListQueryHandlerTests
    {
        private readonly NotesDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        
        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            //Arrange
            var handle = new GetNoteListQueryHandler(Context, Mapper);
            
            //Act
            var result = await handle.Handle(
                new GetNoteListQuery
                {
                    UserId = NotesContextFactory.UserBId
                }, CancellationToken.None);
            
            //Assert
            result.ShouldBeOfType<NoteListVm>();
            result.Notes.Count.ShouldBe(2);
        }
    }
}