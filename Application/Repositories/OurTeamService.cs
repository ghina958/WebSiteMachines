using Microsoft.EntityFrameworkCore;
using WebSiteMachines.Data;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;

namespace WebSiteMachines.Repositories
{
    public class OurTeamService : IOurTeamService
    {
        private readonly ApplicationDbContext _context;
        public OurTeamService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<OurTeam>> GetAll()
        {
            return await _context.OurTeam.ToListAsync();
        }

        public async Task<OurTeam> GetById(int id)
        {
            return await _context.OurTeam.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Add(OurTeam ourTeam)
        {
            _context.OurTeam.Add(ourTeam);
            return Save();
        }

        public bool Delete(OurTeam ourTeam)
        {
            _context.OurTeam.Remove(ourTeam);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(OurTeam ourTeam)
        {
            _context.OurTeam.Update(ourTeam);
            return Save();
        }
    }





}
