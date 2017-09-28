
using System.Collections.Generic;
//using clientprj.Domain.Client;
using clientprj.DTO;

namespace clientprj.Services
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAll();
        ClientDTO GetById(int id);
        ClientDTO Add(ClientDTO cli);
        void Update(ClientDTO cli);
        void Remove(int id);
    }
}