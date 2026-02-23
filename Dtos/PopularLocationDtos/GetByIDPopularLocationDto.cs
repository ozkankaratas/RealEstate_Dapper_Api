namespace RealEstate_Dapper_Api.Dtos.PopularLocationDtos
{
    public class GetByIDPopularLocationDto
    {
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }
        public string CityID { get; set; }

    }
}
