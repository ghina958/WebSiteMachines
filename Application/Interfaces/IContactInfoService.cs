using WebSiteMachines.Models;

namespace WebSiteMachines.Interfaces
{
	public interface IContactInfoService
	{
		Task<ContactInfo> GetContactInfo();
        //Task<ContactInfo> GetById();
        bool Update(ContactInfo contactInfo);
		bool Save();
	}
}
