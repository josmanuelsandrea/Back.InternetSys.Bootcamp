using BackendBootcamp.DBModels;
using BackendBootcamp.Models;

namespace BackendBootcamp.Repository
{
    public class ClientRepository
    {
        private readonly BackendbootcampContext _Context;
        public ClientRepository(BackendbootcampContext ctx)
        {
            _Context = ctx;
        }

        public Client? getClientByIdentification(string identification_id)
        {
            try
            {
                return _Context.Clients.Where(c => c.Identification == identification_id).FirstOrDefault();
            } catch (Exception)
            {
                return null;
            }
        }

        public Client getAnonymousClient()
        {
            return _Context.Clients.Where(c => c.Identification == "0000000000").FirstOrDefault();
        }

        public Client? CreateClient(Client model)
        {
            var test = model;
            try
            {
                _Context.Clients.Add(model);
                _Context.SaveChanges();
                return model;
            } catch (Exception)
            {
;               return null;
            }
        }
    }
}
