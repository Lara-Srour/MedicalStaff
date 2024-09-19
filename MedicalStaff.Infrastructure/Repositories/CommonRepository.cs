using MedicalStaff.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalStaff.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MedicalStaff.Infrastructure;

namespace MedicalStaff.Infrastructure.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    { 
        private readonly MedicalStaffDbContext _context;
        private readonly DbSet<T> _dbSet;

        public CommonRepository(MedicalStaffDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            // Update the properties of the existing entity
            _context.Entry(entity).State = EntityState.Modified;

            // Save changes to the database
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}