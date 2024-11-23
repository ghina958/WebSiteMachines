using Microsoft.EntityFrameworkCore;
using WebSiteMachines.Data;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;

namespace WebSiteMachines.Repositories
{
	public class ContactInfoService : IContactInfoService
	{
		private readonly ApplicationDbContext _context;
		public ContactInfoService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<ContactInfo> GetContactInfo()
		{
			return await _context.ContactInfo.FirstOrDefaultAsync();
		}
        //public Task<ContactInfo> GetById()
        //{
        //    throw new NotImplementedException();
        //}
        public bool Update(ContactInfo contactInfo)
		{
			_context.ContactInfo.Update(contactInfo);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

       
    }
}
