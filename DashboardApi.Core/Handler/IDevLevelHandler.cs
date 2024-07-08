using DashboardApi.Core.Models;
using DashboardApi.Core.Request.DevLevel;
using DashboardApi.Core.Response;

namespace DashboardApi.Core.Handler;

public interface IDevLevelHandler
{
    Task<PagedResponse<List<DevLevel>>> GetAll(GetAllDevLevelsRequest request);
    Task<Response<DevLevel>> GetById(GetDevLevelByIdRequest request);
}