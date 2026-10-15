using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Services;

public class StaffMemberService
{
    private readonly ProjectDbConnection _context;

    public StaffMemberService(ProjectDbConnection context)
    {
        _context = context;
    }

    public async Task<List<StaffMember>> GetAllStaffMembers()
    {
        return await _context.StaffMembersDb.ToListAsync();
    }

    public async Task<StaffMember?> GetStaffById(int id)
    {
        return await _context.StaffMembersDb.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<StaffMember> CreateStaff(StaffMember staff)
    {
        var entity = staff;
        _context.StaffMembersDb.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<StaffMember> UpdateStaff(StaffMember updated)
    {
        var existing = await GetStaffById(updated.Id);
        if (existing == null)
            throw new Exception("Could not get staff. No matching Id found");

        existing.FirstName = updated.FirstName;
        existing.LastName = updated.LastName;
        existing.Email = updated.Email;
        existing.Phone = updated.Phone;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteStaffById(int id)
    {
        var result = await _context.StaffMembersDb
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

        if (result > 0)
            return true;
        else
        {
            return false;
        }
    }
}