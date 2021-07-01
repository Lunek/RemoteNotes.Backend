using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RemoteNotes.Application.Notes.Queries.GetNoteDetails;
using RemoteNotes.Persistence;
using RemoteNotes.Tests.Common;
using Shouldly;
using Xunit;

namespace RemoteNotes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly NotesDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);
            
            //Act
            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("f13f9bae-af85-48fc-b6fc-2a703964b3c5")
                }, CancellationToken.None);
            
            //Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}