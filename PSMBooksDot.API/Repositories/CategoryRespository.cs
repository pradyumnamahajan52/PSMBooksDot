using PSMBooksDot.API.Data;
using PSMBooksDot.API.DTO;
using PSMBooksDot.API.Models;

namespace PSMBooksDot.API.Repositories
{
    public class CategoryRespository : ICategoryRespository
    {
        private readonly PSMBooksShopDbContext dbContext;
        public CategoryRespository(PSMBooksShopDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public List<BooksCategory> GetAll()
        {
            return dbContext.BooksCategories.ToList();

        }

        public BooksCategory? GetById(int id)
        {
            return dbContext.BooksCategories.FirstOrDefault(c => c.Id == id);
        }
        
        public BooksCategory Create(BooksCategory booksCategory)
        {
            dbContext.BooksCategories.Add(booksCategory);
            dbContext.SaveChanges();
            return booksCategory;
        }

        public BooksCategory? Update(int id, AdminCategoryRequestDTO booksCategory)
        {
            var existingBookCategory = dbContext.BooksCategories.FirstOrDefault(x => x.Id == id);
            if (existingBookCategory != null) { return null; }
            existingBookCategory.Type = booksCategory.Type;
            existingBookCategory.UpdatedAt = DateTime.UtcNow;
            dbContext.SaveChanges();
            return existingBookCategory;
        }

        public BooksCategory? Delete(int id)
        {
            var existingBookCategory = dbContext.BooksCategories.FirstOrDefault(x => x.Id == id);
            if (existingBookCategory != null) { return null; }
            dbContext.BooksCategories.Remove(existingBookCategory);
            dbContext.SaveChanges();
            return existingBookCategory;
        }
    }
}
