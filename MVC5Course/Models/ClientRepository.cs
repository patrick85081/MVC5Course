using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
	    public override IQueryable<Client> All()
	    {
	        return base.All().Where(c => !c.IsDelete);
	    }

	    public override void Delete(Client entity)
	    {
	        entity.IsDelete = true;
	    }

	    public Client Find(int? id) =>
	        id.HasValue ? this.All().FirstOrDefault(c => c.ClientId == id) : null;

	    public IQueryable<Client> Search(string keyword)
	    {
	        var clients = this.All();
	        if (!string.IsNullOrEmpty(keyword))
	        {
	            clients = clients.Where(c => c.FirstName.Contains(keyword));
	        }

	        clients = clients.OrderByDescending(c => c.ClientId).Take(10);
            return clients;
	    }
	}

	public  interface IClientRepository : IRepository<Client>
	{
	    Client Find(int? id);
	    IQueryable<Client> Search(string keyword);
	}
}