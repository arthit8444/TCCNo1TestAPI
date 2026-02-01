using Microsoft.EntityFrameworkCore;
using TCCNo1TestAPI.Domain.Context;
using TCCNo1TestAPI.Domain.Entities;
using TCCNo1TestAPI.Domain.Interfaces;

namespace TCCNo1TestAPI.Infrastructure.Repositories
{
    public class PersonRepository(PersonContext context) : IPersonRepository
    {
        private readonly PersonContext context = context;

        public async Task AddAsync(Person entity)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                if (entity != null)
                {
                    var now = DateTime.Now;
                    entity.CreatedBy = "system";
                    entity.CreatedDate = now;
                    entity.ModifiedBy = "system";
                    entity.ModifiedDate = now;
                    context.Persons.Add(entity);
                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
            }
            catch (Exception ex)
            {                
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Person>> GetAllAsync()
        {
            try
            {
                var entities = await context.Persons.OrderBy(o => o.ModifiedDate).ToListAsync();

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Person?> GetByIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    return context.Persons.FirstOrDefaultAsync(p => p.Id == id);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Person entity)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                if (entity != null)
                {
                    var now = DateTime.Now;
                    entity.ModifiedBy = "system";
                    entity.ModifiedDate = now;
                    context.Persons.Update(entity);
                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
            }
            catch (Exception ex)
            {                
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
