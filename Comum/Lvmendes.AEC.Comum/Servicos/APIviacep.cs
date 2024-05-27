using Lvmendes.AEC.Comum.Entidades.Api.viacep;
using Lvmendes.AEC.Comum.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Comum.Servicos
{
    public class APIviacep : IAPIviacep
    {
        private readonly IConfiguration _configuration;



        public APIviacep( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Retornoviacep RetornoCep(string cep)
        {
            HttpClientHelper clientHelper = new HttpClientHelper();
            var apiUrl = string.Format(_configuration["API:viacep"], cep);
            

            Retornoviacep retorno = clientHelper.GetAsync<Retornoviacep>(apiUrl, null).Result;

            return retorno;
            
        }
    }
}
