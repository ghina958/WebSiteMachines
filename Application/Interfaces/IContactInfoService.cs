using WebSiteMachines.Models;

namespace WebSiteMachines.Interfaces
{
	public interface IContactInfoService
	{
		Task<ContactInfo> GetContactInfo();
		bool Update(ContactInfo contactInfo);
		bool Save();
	}
}
