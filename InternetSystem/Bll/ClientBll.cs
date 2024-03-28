using BackendBootcamp.DBModels;
using BackendBootcamp.Models;
using BackendBootcamp.Repository;

namespace BackendBootcamp.Bll
{
    public class ClientBll
    {
        private readonly BackendbootcampContext _Context;
        private readonly ClientRepository ClientR;
        public ClientBll (BackendbootcampContext db)
        {
            _Context = db;
            ClientR = new ClientRepository(db);
        }

        // Se busca el cliente en la base de datos, si se consigue, se retorna el cliente encontrado
        // En caso contrario, si el cliente no se ha encontrado, se devuelve el cliente genérico "Anonymous"
        public Client GetClientByIdentification(string identification)
        {
            Client? clientFound = ClientR.getClientByIdentification(identification);
            if (clientFound == null)
            {
                return ClientR.getAnonymousClient();
            }

            return clientFound;
        }

        public Client? AddClient(ClientModelReq client)
        {
            Client? createdClientModel = new()
            {
                Identification = client.Identification,
                Name = client.Name,
                Lastname = client.Lastname,
                Email = client.Email,
                Phonenumber = client.Phonenumber,
                Address = client.Address,
                Referenceaddress = client.Referenceaddress,
            };

            Client? clientCreated = ClientR.CreateClient(createdClientModel);

            return clientCreated;
        }
    }
}
