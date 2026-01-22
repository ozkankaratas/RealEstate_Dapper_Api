namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories
{
    public interface IStatisticRepository
    {
        int ProductCountByEmployeeId(int id);
        int ActiveProductCount(int id);
        int PassiveProductCount(int id);
        int AllProductCount();
    }
}
