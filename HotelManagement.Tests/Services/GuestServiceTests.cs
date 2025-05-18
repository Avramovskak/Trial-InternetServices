using HotelManagement.Application.DTOs;
using HotelManagement.Application.Services;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Interfaces;
using Moq;

namespace HotelManagement.Tests.Services;

public class GuestServiceTests
{
    private readonly Mock<IGuestRepository> _mockRepo;
    private readonly GuestService _service;

    public GuestServiceTests()
    {
        _mockRepo = new Mock<IGuestRepository>();
        _service = new GuestService(_mockRepo.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreatedGuest()
    {
        var dto = new CreateGuestDto
        {
            FirstName = "John",
            LastName = "Doe",
            DOB = DateTime.Parse("1990-01-01"),
            Address = "123 Street",
            Nationality = "Testland",
            CheckInDate = DateTime.Today,
            CheckOutDate = DateTime.Today.AddDays(3),
            RoomId = 1
        };

        Guest? capturedGuest = null;
        _mockRepo.Setup(r => r.AddAsync(It.IsAny<Guest>()))
                 .Callback<Guest>(g => {
                     g.Id = 10;
                     capturedGuest = g;
                 })
                 .Returns(Task.CompletedTask);

        var result = await _service.CreateAsync(dto);

        Assert.NotNull(result);
        Assert.Equal(10, result.Id);
        Assert.Equal("John", capturedGuest?.FirstName);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnList()
    {
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Guest>
        {
            new Guest { Id = 1, FirstName = "Jane", LastName = "Smith", DOB = DateTime.Now, Address = "abc", Nationality = "X", CheckInDate = DateTime.Today, CheckOutDate = DateTime.Today.AddDays(1), RoomId = 1 }
        });

        var result = await _service.GetAllAsync();

        Assert.Single(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenGuestNotFound()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Guest?)null);

        var result = await _service.DeleteAsync(99);

        Assert.False(result);
    }
}
