using Backend.Models;

namespace FrontEnd.Interface.MasterData
{
    public interface IActivityType
    {
        Task<List<MstActivityType>> GetAllData();

        Task<ApiResponseModel> Insert(MstActivityType oMstActivityType, string UserCode);

        Task<ApiResponseModel> Update(MstActivityType oMstActivityType, string UserCode);
    }
}
