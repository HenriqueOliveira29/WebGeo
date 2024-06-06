using Microsoft.EntityFrameworkCore;
using WebGeoInfrastructure.Entities;
using WebGeoInfrastructure.Interfaces.Repositories;

namespace WebGeoRepository.Repositories
{
    public class RoutesRepository : IRoutesRepository
    {
        private readonly AppDBContext _context;

        public RoutesRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Routes>> GetAll()
        {
            return await _context.Routes.ToListAsync();
        }

        public async Task<Locality> GetById(int id)
        {
            return await _context.Localities.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Locality> GetLocalityMostClosed(double cordX, double cordY)
        {
            var sql = @$"
            SELECT *
            FROM public.""Localities""
            ORDER BY ""Location"" <-> ST_Transform(ST_SetSRID(ST_MakePoint({cordY}, {cordX}), 4326), 3763)
            LIMIT 1";

            return await _context.Localities
                                 .FromSqlRaw(sql)
                                 .FirstOrDefaultAsync();
        }
    }
}
