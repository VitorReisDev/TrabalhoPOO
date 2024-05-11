using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOOList
{
    public class EnunsEspaco
    {
        public enum StatusEspaco //Responsável por enumerar o estado do espaço (disponível/reservado)
        {
            Disponivel,
            Reservado
        }

        public enum CapacidadeEspaco //Responsável por enumerar a capacidade do espaço que será reservado
        {
            Cinquenta = 50,
            Cem = 100,
            Duzentas = 200,
            Quinhentos = 500
        }
    }
}
