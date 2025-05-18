using HotelManagement.Application.DTOs;
using HotelManagement.Application.Services;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Interfaces;
using Moq;

namespace HotelManagement.Tests.Services;

public class RoomServiceTests
{
    private readonly Mock<IRoomRepository> _mockRepo;
    private readonly RoomService _service;

    public RoomServiceTests()
    {
        _mockRepo = new Mock<IRoomRepository>();
        _service = new RoomService(_mockRepo.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreatedRoom()
    {
        var dto = new CreateRoomDto
        {
            Number = 101,
            Floor = 1,
            Type = "Single"
        };

        Room? capturedRoom = null;
        _mockRepo.Setup(r => r.AddAsync(It.IsAny<Room>()))
                 .Callback<Room>(r => {
                     r.Id = 5;
                     capturedRoom = r;
                 })
                 .Returns(Task.CompletedTask);

        var result = await _service.CreateAsync(dto);

        Assert.NotNull(result);
        Assert.Equal(5, result.Id);
        Assert.Equal("Single", capturedRoom?.Type);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnList()
    {
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Room>
        {
            new Room { Id = 1, Number = 100, Floor = 1, Type = "Double" }
        });

        var result = await _service.GetAllAsync();

        Assert.Single(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenRoomNotFound()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Room?)null);

        var result = await _service.DeleteAsync(999);

        Assert.False(result);
    }
}
