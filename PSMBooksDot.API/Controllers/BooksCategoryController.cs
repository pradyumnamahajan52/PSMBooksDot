using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSMBooksDot.API.Data;
using PSMBooksDot.API.DTO;
using PSMBooksDot.API.Models;

namespace PSMBooksDot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksCategoryController : ControllerBase
    {
        private readonly PSMBooksShopDbContext dbContext;
        public BooksCategoryController(PSMBooksShopDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var booksCategoriesList = dbContext.BooksCategories.ToList();
            var booksCategoriesListDTO = new List<AdminCategoryResponseDTO>();
            foreach (var bookCategoryItem in booksCategoriesList)
            {
                booksCategoriesListDTO.Add(new AdminCategoryResponseDTO()
                {
                    Id = bookCategoryItem.Id,
                    Type = bookCategoryItem.Type,
                    CreatedAt = bookCategoryItem.CreatedAt,
                    UpdatedAt = bookCategoryItem.UpdatedAt
                });

            }
            return Ok(booksCategoriesListDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var booksCategories = dbContext.BooksCategories.FirstOrDefault(x => x.Id == id);
            if (booksCategories == null)
            {
                return NotFound();
            }
            var booksCategoriesDTO = new AdminCategoryResponseDTO
            {
                Id= booksCategories.Id,
                Type= booksCategories.Type, 
                CreatedAt = booksCategories.CreatedAt,
                UpdatedAt = booksCategories.UpdatedAt
            };
            return Ok(booksCategoriesDTO);
        }


        [HttpPost]
        public IActionResult Create([FromBody] AdminCategoryRequestDTO adminCategoryRequestDTO)
        {
            var booksCategory = new BooksCategory
            {
                Type = adminCategoryRequestDTO.Type
            };
            dbContext.BooksCategories.Add(booksCategory);
            dbContext.SaveChanges();

            var booksCategoriesDTO = new AdminCategoryResponseDTO
            {
                Id = booksCategory.Id,
                Type = booksCategory.Type,
                CreatedAt = booksCategory.CreatedAt,
                UpdatedAt = booksCategory.UpdatedAt
            };
            return CreatedAtAction(nameof(GetById), new { id = booksCategory.Id }, booksCategoriesDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] AdminCategoryRequestDTO adminCategoryRequestDTO)
        {
            var booksCategories = dbContext.BooksCategories.FirstOrDefault(x => x.Id == id);
            if (booksCategories == null)
            {
                return NotFound();
            }
            booksCategories.Type = adminCategoryRequestDTO.Type;
            booksCategories.UpdatedAt = DateTime.UtcNow;

            dbContext.SaveChanges();

            var booksCategoriesDTO = new AdminCategoryResponseDTO
            {
                Id = booksCategories.Id,
                Type = booksCategories.Type,
                CreatedAt = booksCategories.CreatedAt,
                UpdatedAt = booksCategories.UpdatedAt
            };
            return Ok(booksCategoriesDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var booksCategories = dbContext.BooksCategories.FirstOrDefault(x => x.Id == id);
            if (booksCategories == null)
            {
                return NotFound();
            }
            dbContext.BooksCategories.Remove(booksCategories);
            dbContext.SaveChanges();
            var booksCategoriesDTO = new AdminCategoryResponseDTO
            {
                Id = booksCategories.Id,
                Type = booksCategories.Type,
                CreatedAt = booksCategories.CreatedAt,
                UpdatedAt = booksCategories.UpdatedAt
            };
            return Ok(booksCategoriesDTO);
        }
    }
}
