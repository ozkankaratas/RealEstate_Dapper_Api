namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string EmployeeNameWithMaxProductCount();
        string CategoryNameWithMaxProductCount();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        string CityNameWithMaxProductCount();
        int CityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int AvarageRoomCount();
        int ActiveEmployeeCount();
    }
}
