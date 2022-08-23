using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContatoRequestModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
