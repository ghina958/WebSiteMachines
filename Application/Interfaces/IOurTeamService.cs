using WebSiteMachines.Models;

namespace WebSiteMachines.Interfaces
{
    public interface IOurTeamService
    {
        Task<List<OurTeam>> GetAll();

        Task<OurTeam> GetById(int id);
        bool Add(OurTeam ourTeam);
        bool Update(OurTeam ourTeam);
        bool Delete(OurTeam ourTeam);
        bool Save();
    }
}
