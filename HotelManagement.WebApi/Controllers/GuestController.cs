using HotelManagement.Service.DTOs;
using HotelManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuestController : ControllerBase
{
    private readonly IGuestService _guestService;

    public GuestController(IGuestService guestService)
    {
        _guestService = guestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var guests = await _guestService.GetAllAsync();
        return Ok(guests);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var guest = await _guestService.GetByIdAsync(id);
        if (guest == null) return NotFound();
        return Ok(guest);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGuestDto dto)
    {
        var created = await _guestService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateGuestDto dto)
    {
        var result = await _guestService.UpdateAsync(id, dto);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _guestService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
