using System.Linq.Expressions;
using CategoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Data;

public class CategoryRepository : ICategoryRepository
{
    protected DbSet<Category> Entities { get; }
    protected IQueryable<Category> Tables => Entities;
    protected IQueryable<Category> TableAsNoTracking => Entities.AsNoTracking();

    private readonly CategoryDbContext _categoryDbContext;

    public CategoryRepository(CategoryDbContext categoryDbContext)
    {
        _categoryDbContext = categoryDbContext;
        Entities = _categoryDbContext.Set<Category>();
    }

    /// <summary>
    /// list of <see cref="Category"/> by no tracking.
    /// </summary>
    /// <returns></returns>
    public IQueryable<Category> Get(Expression<Func<Category, bool>> predicate)
    {
        return TableAsNoTracking.Where(predicate);
    }

    public IQueryable<Category> Get()
    {
        return TableAsNoTracking;
    }

    /// <summary>
    /// find item in <see cref="TEntity"/> by tracking.
    /// </summary>
    /// <returns></returns>
    public Category GetById(long id)
    {
        return Entities.Find(id);
    }

    public void Add(Category category)
    {
        Entities.Add(category);
    }

    public void Delete(Category category)
    {
        Entities.Remove(category);
    }

    public void Update(Category category)
    {
        Entities.Update(category);
    }

    public virtual void Save()
    {
        _categoryDbContext.SaveChanges();
    }
}