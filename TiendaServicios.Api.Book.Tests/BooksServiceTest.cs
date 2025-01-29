using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using TiendaServicios.Api.Book.Application;
using TiendaServicios.Api.Book.Model;
using TiendaServicios.Api.Book.Persistence;

namespace TiendaServicios.Api.Book.Tests
{
    public class BooksServiceTest
    {
        private IEnumerable<BookModel> GetTrialData()
        {
            A.Configure<BookModel>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.BookAuthorId, () => { return Guid.NewGuid(); });

            var list = A.ListOf<BookModel>(30);
            list[0].BookId = Guid.Empty;

            return list;
        }

        private Mock<BookContext> CreateContext()
        {
            var dataTest = GetTrialData().AsQueryable();
            var dbSet = new Mock<DbSet<BookModel>>();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });

            var mapper = mapConfig.CreateMapper();

            dbSet.As<IQueryable<BookModel>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<BookModel>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<BookModel>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<BookModel>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbSet.As<IAsyncEnumerable<BookModel>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<BookModel>(dataTest.GetEnumerator()));

            dbSet.As<IQueryable<BookModel>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<BookModel>(dataTest.Provider));

            var context = new Mock<BookContext>();
            context.Setup(x => x.Books).Returns(dbSet.Object);
            return context;
        }

        [Fact]
        public async void GetBookbyId()
        {
            var mockContext = CreateContext();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });

            var mapper = mapConfig.CreateMapper();

            ActionsApp actions = new ActionsApp(mockContext.Object, mapper);
            var request = await actions.IndexTest(Guid.Empty);

            Assert.NotNull(request);
            Assert.True(request.BookId == Guid.Empty);
        }

        [Fact]
        public async void GetBooks()
        {
            System.Diagnostics.Debugger.Launch();
            var mockContext = CreateContext();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });

            var mapper = mapConfig.CreateMapper();
            ActionsApp actions = new ActionsApp(mockContext.Object, mapper);
            
            var list = await actions.Test();
            
            Assert.True(list.Any());
        }

        [Fact]
        public async void SaveBook()
        {
            System.Diagnostics.Debugger.Launch();
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "BookDB").Options;

            var context = new BookContext(options);
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });

            var mapper = mapConfig.CreateMapper();

            ActionsApp actions = new ActionsApp(context, mapper);
            var book = await actions.Create(new DTO.BookDTO
            {
                BookId = Guid.NewGuid(),
                PublisheddDate = DateTime.Now,
                Title = "PRUEBA",
                BookAuthorId = Guid.Empty,
            });

            Assert.True(book != null);
        }
    }
}