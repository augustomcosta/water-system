using Microsoft.EntityFrameworkCore;
using WaterSystem.Domain.Entities;
using WaterSystem.Domain.Repositories;
using WaterSystem.Infra.Context;

namespace WaterSystem.Data.Repositories;

public class ResidenceRepository : IResidenceRepository
{
    private readonly AppDbContext _context;
    
    public ResidenceRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Residence>> GetAll()
    {
        var residences = await _context.Residences.ToListAsync();
        if (residences == null)
        {
            throw new Exception("No residences were found");
        }
        
        return residences;
    }

    public async Task<Residence> GetById(Guid? id)
    {
        var residenceById = await _context.Residences.FirstOrDefaultAsync(r => r.Id == id);
        if (residenceById == null)
        {
            throw new Exception($"Residence with Id {id} not found.");
        }

        return residenceById;
    }

    public async Task<Residence> Create(Residence residence)
    {
        await _context.AddAsync(residence);
        await _context.SaveChangesAsync();
        return residence;
    }

    public async Task<Residence> Update(Guid? id, Residence residence)
    {
        var residenceToUpdate = await _context.Residences.FirstOrDefaultAsync(r => r.Id == id);
        residence.UpdateResidence(residenceToUpdate);
        return residence;
    }

    public Task<Residence> Delete(Guid? id)
    {
        throw new NotImplementedException();
    }
}