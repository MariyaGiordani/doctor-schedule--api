using System;

namespace APICore.Models
{
    public class RetornoWS
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public Object Objeto { get; set; }
    }
}
