using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
	    public IQueryable<Client> GetPageClients(int page = 1, int pageCount = 10)
	    {
	        return this.All()
	            .OrderByDescending(c => c.ClientId)
	            .Skip((page - 1) * pageCount)
	            .Take(pageCount);
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
	    IQueryable<Client> GetPageClients(int page = 1, int pageCount = 10);
	    Client Find(int? id);
	    IQueryable<Client> Search(string keyword);
	}
}