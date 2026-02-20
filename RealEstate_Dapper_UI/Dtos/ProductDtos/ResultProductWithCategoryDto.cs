namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? CoverImage { get; set; }
        public string? City { get; set; }
        public string? CityName { get; set; }
        public string? District { get; set; }
        public string? DistrictName { get; set; }
        public string? Semt { get; set; }
        public string? SemtName { get; set; }
        public string? Neighborhood { get; set; }
        public string? NeighborhoodName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int ProductCategory { get; set; }
        public int AppUserId { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
