using clientprj.Domain.Util;

namespace clientprj.Domain.Client
{
    public class Client 
    {
        public int Id { get;protected set;}
        public string Name {get;protected set;}
       // public string Cpf { get; protected set;}    
        //public string Cnpj {get; protected set;}
        public string Telefone{get; protected set;}
        public string Documento {get; protected set;}

        private Client()
        {}

        public Client(string name,                       
                      string documento, 
                      string telefone)
        {
            var domainException = new DomainException();

            
            if(string.IsNullOrEmpty(name)) 
                domainException.Errors.Add("Nome é obrigatório");
            
            if(!Util.Cnpj.ValidaCNPJ(documento) && !Util.Cpf.ValidaCPF(documento))
               domainException.Errors.Add("Documento inválido");
            
            
            if(!Util.Telefone.ValidaTelefone(telefone)) 
                domainException.Errors.Add("Telefone inválido");
            
            if(domainException.Errors.Count > 0) 
                throw domainException;
           
            this.Name = name;
            this.Telefone = telefone;
            this.Documento = documento;
        }

       /* public Client(string name,
                      TipoDocumento tipoDocumento, 
                      string documento, 
                      string telefone)
        {
            var domainException = new DomainException();

            
            if(string.IsNullOrEmpty(name)) 
                domainException.Errors.Add("Name is required");
            
            if(tipoDocumento == TipoDocumento.Cnpj &&
               !Util.Cnpj.ValidaCNPJ(documento))
            {
                 domainException.Errors.Add("Cnpj invalid");
            }
            

            if(tipoDocumento == TipoDocumento.Cpf && 
               !Util.Cpf.ValidaCPF(documento))
               {
                   domainException.Errors.Add("Cpf invalid");
               }

            if(!Util.Telefone.ValidaTelefone(telefone)) 
                domainException.Errors.Add("Telefone invalid");
            
            if(domainException.Errors.Count > 0) 
                throw domainException;

            this.Cpf = string.Empty;
            this.Cnpj = string.Empty;
            this.Name = name;
            this.Telefone = telefone;
            if(tipoDocumento == TipoDocumento.Cpf) this.Cpf = documento;
            if(tipoDocumento == TipoDocumento.Cnpj) this.Cnpj = documento;
        }*/

        public void setDocumento(string documento)
        {
            var domainException = new DomainException();
                        
            if(!Util.Cnpj.ValidaCNPJ(documento) && !Util.Cpf.ValidaCPF(documento))
            {
               domainException.Errors.Add("Documento inválido");
               throw domainException;
            }

            this.Documento = documento;   
        }
        
       /* public void setCpf(string documento)
        {
            var domainException = new DomainException();

            if(!Util.Cpf.ValidaCPF(documento))               
               domainException.Errors.Add("Cpf invalid");

            if(domainException.Errors.Count > 0) 
                throw domainException;
            
            
            this.Cnpj = string.Empty;            
            this.Cpf = documento;            
        }

        public void setCnpj(string documento)
        {
            var domainException = new DomainException();

            if(!Util.Cnpj.ValidaCNPJ(documento))               
                domainException.Errors.Add("Cnpj invalid");
            

            if(domainException.Errors.Count > 0) 
                throw domainException;
            
            this.Cpf = string.Empty;
            this.Cnpj = documento;           
        }*/

        public void setTelefone(string telefone)
        {
            var domainException = new DomainException();

             if(!Util.Telefone.ValidaTelefone(telefone)) 
                domainException.Errors.Add("Telefone invalid");
            
            if(domainException.Errors.Count > 0) 
                throw domainException;

      
            this.Telefone = telefone;
        }

        public void setName(string name)
        {
            var domainException = new DomainException();

            
            if(string.IsNullOrEmpty(name)) 
                domainException.Errors.Add("Name is required");

            if(domainException.Errors.Count > 0) 
                throw domainException;
            
            this.Name = name;
        }
    }

    public enum TipoDocumento
    {
        Cpf = 1,
        Cnpj = 2
    }
}
