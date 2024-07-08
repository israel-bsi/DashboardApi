using DashboardApi.Core.Enums;
using DashboardApi.Core.Handler;
using DashboardApi.Core.Models;
using DashboardApi.Core.Request.DevLevel;
using DashboardApi.Core.Response;

namespace DashboardApi.Web.Handler;

public class DevLevelHandler : IDevLevelHandler
{
    public Task<PagedResponse<List<DevLevel>>> GetAll(GetAllDevLevelsRequest request)
    {
        try
        {
            var enumValues = Enum.GetValues(typeof(EDevLevel))
                .Cast<EDevLevel>()
                .Select(e => new DevLevel { Id = (int)e, Description = e.ToString() })
                .ToList();

            return Task.FromResult(new PagedResponse<List<DevLevel>>(enumValues));
        }
        catch
        {
            return Task.FromResult(new PagedResponse<List<DevLevel>>(null, 500, "Não foi possivel carregar os niveis"));
        }
    }
    public Task<Response<DevLevel>> GetById(GetDevLevelByIdRequest request)
    {
        try
        {
            var enumValue = Enum.GetValues(typeof(EDevLevel))
                .Cast<EDevLevel>()
                .FirstOrDefault(e => (int)e == request.Id);

            var devLevel = new DevLevel { Id = (int)enumValue, Description = enumValue.ToString() };

            return Task.FromResult(new Response<DevLevel>(devLevel));
        }
        catch
        {
            return Task.FromResult(new Response<DevLevel>(null, 500, "Não foi possivel carregar o nivel"));
        }
    }
}