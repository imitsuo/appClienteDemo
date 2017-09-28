
using System.Collections.Generic;
using System.Linq;
using clientprj.Domain.Client;
using clientprj.DTO;
using clientprj.Infrastructure.Repositories;

namespace clientprj.Services
{
    public class ClientService : IClientService
    {
        private IRepository<Client> clientRepository;

        public ClientService(IRepository<Client> repository)
        {
            this.clientRepository = repository;
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            return ConvertToDto(this.clientRepository.GetAll().ToList());
        }

        public ClientDTO GetById(int id)
        {
            return ConvertToDto(this.clientRepository.Get<int>(id));
        }

        public ClientDTO Add(ClientDTO dto)
        {
            var cli = ConvertToEntity(dto);
            return ConvertToDto(this.clientRepository.Insert(cli));
        }

        public void Update(ClientDTO dto)
        {
            var cli = this.clientRepository.Get<int>(dto.Id.Value);
                       
            cli.setName(dto.Name);
            cli.setTelefone(dto.Telefone);
            cli.setDocumento(dto.Documento);

            this.clientRepository.Update(cli);
        }

        public void Remove(int id)
        {
            var cli = this.clientRepository.Get<int>(id);

            this.clientRepository.Delete(cli);            
        }



        private List<ClientDTO> ConvertToDto(List<Client> clis)
        {
            var dtos = new List<ClientDTO>();
            clis.ForEach(x => dtos.Add(ConvertToDto(x)));

            return dtos;
        }
        private ClientDTO ConvertToDto(Client cli)
        {
            var dto = new ClientDTO();
            
            dto.Id = cli.Id;            
            dto.Name = cli.Name;            
            dto.Telefone = cli.Telefone;
            dto.Documento = cli.Documento;

            return dto;
        }

        private Client ConvertToEntity(ClientDTO dto)
        {
            var cli = new Client(dto.Name, dto.Documento, dto.Telefone);
            return cli;            
        }
    }
}