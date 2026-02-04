namespace RealEstate_Dapper_Api.Dtos.ProductDetailDtos
{
    public class CreateProductDetailDto
    {
        public int ProductSize { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public int RoomCount { get; set; }
        public int GarageSize { get; set; }
        public string BuildYear { get; set; }
        public string VideoUrl { get; set; }
    }
}
