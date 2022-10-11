using System.Linq.Expressions;
using CategoryService.Models;

namespace CategoryService.Data;

public interface ICategoryRepository
{
    IQueryable<Category> Get(Expression<Func<Category, bool>> predicate);
    IQueryable<Category> Get();
    Category GetById(long id);
    void Add(Category category);
    void Update(Category category);
    void Delete(Category category);
    void Save();
}