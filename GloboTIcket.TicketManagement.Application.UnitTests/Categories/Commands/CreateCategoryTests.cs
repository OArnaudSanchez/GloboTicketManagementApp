using AutoMapper;
using GloboTIcket.TicketManagement.Application.Contracts.Persistance;
using GloboTIcket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTIcket.TicketManagement.Application.Profiles;
using GloboTIcket.TicketManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GloboTIcket.TicketManagement.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;

        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = RepositoryMock.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task HandleValidCategoryAddedToCategoriesRepository()
        {
            var handler = new CreateCategoryCommandHandler(_mockCategoryRepository.Object, _mapper);
            await handler.Handle(new CreateCategoryCommand { Name = "Test" }, CancellationToken.None);
            var categories = await _mockCategoryRepository.Object.ListAllAsync();
            categories.Count.ShouldBe(5);
        }
    }
}