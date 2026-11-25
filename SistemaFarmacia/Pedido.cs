using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia
{
     class Pedido
    {
        string paciente;
        int quantidade;
        int prioridade;
        int forma;

        public string Paciente { get => paciente; set => paciente = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public int Prioridade { get => prioridade; set => prioridade = value; }
        public int Forma { get => forma; set => forma = value; }
    }
}
