using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PSMBooksDot.API.DTO
{
    public class CategoryResponseDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

    }
}
