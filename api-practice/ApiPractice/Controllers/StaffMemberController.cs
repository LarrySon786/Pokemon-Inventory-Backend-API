using ApiPractice.Models;
using ApiPractice.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractice.Controller;

[ApiController]
[Route("staff")]
public class StaffMemberController : ControllerBase
{
    private readonly StaffMemberService _staff;

    public StaffMemberController(StaffMemberService staff)
    {
        _staff = staff;
    }

    // GET single staff member
    [HttpGet]
    public async Task<IActionResult> GetAllStaff()
    {
        var staff = await _staff.GetAllStaffMembers();
        return Ok(staff);
    }

    // GET all staff members
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetStaffById(int id)
    {
        var staff = await _staff.GetStaffById(id);
        if (staff == null)
            return NotFound();
        return Ok(staff);
    }

    [HttpPost()]
    public async Task<IActionResult> CreateStaff(StaffMember staff)
    {
        var result = await _staff.CreateStaff(staff);
        if (result == null)
            return BadRequest();
        return Created();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateStaff(int id, StaffMember updated)
    {
        updated.Id = id;
        var result = await _staff.UpdateStaff(updated);

        if (result == null)
            return NotFound();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStaff(int id)
    {
        var result = await _staff.DeleteStaffById(id);
        if (result)
            return NoContent();

        return NotFound();
    }
}