using System.Data;

namespace RachunkiTechniczneWebApi.Dal
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}
