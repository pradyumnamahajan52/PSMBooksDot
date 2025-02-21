using PSMBooksDot.API.DTO;
using PSMBooksDot.API.Models;

namespace PSMBooksDot.API.Repositories
{
    public interface ICategoryRespository
    {
        List<BooksCategory> GetAll();
        BooksCategory? GetById(int id);
        BooksCategory Create(BooksCategory booksCategory);
        BooksCategory? Update(int id, AdminCategoryRequestDTO booksCategory);
        BooksCategory? Delete(int id);
    }
}
