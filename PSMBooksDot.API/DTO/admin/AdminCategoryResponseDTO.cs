namespace PSMBooksDot.API.DTO
{
    public class AdminCategoryResponseDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
