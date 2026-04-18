using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    void Add(Category category);
    void Update(Category category);
    void Remove(Category category);
}