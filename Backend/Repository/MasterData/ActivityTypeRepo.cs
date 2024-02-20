using Backend.Interfaces.MasterData;
using Backend.Models;

public class ActivityTypeRepo : IActivityType
{
    private readonly WBCContext _dbContext;

    public ActivityTypeRepo(WBCContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<MstActivityType>> GetAllData()
    {
        List<MstActivityType> oList = new List<MstActivityType>();
        try
        {
            await Task.Run(() =>
            {
                oList = _dbContext.MstActivityTypes.ToList();
            });
        }
        catch (Exception ex)
        {
            //Logs.GenerateLogs(ex);
        }
        return oList;
    }

    public async Task<ApiResponseModel> Insert(MstActivityType oMstActivityType, string UserCode)
    {
        ApiResponseModel response = new ApiResponseModel();
        try
        {
            _dbContext.MstActivityTypes.Add(oMstActivityType);
            await _dbContext.SaveChangesAsync();

            response.Id = 1;
            response.Message = "Saved successfully";
        }
        catch (Exception ex)
        {
            // Log the exception
            response.Id = 0;
            response.Message = $"Failed to save: {ex.Message}";
        }
        return response;
    }

    public async Task<ApiResponseModel> Update(MstActivityType oMstActivityType, string UserCode)
    {
        ApiResponseModel response = new ApiResponseModel();
        try
        {
            _dbContext.MstActivityTypes.Update(oMstActivityType);
            await _dbContext.SaveChangesAsync();

            response.Id = 1;
            response.Message = "Updated successfully";
        }
        catch (Exception ex)
        {
            // Log the exception
            response.Id = 0;
            response.Message = $"Failed to update: {ex.Message}";
        }
        return response;
    }
}
