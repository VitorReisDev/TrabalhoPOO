using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOOList
{
    public class GerenciadorDeCerimonias
    {
        private List<ReservaCinquenta> AgendaParaCinquentaPessoas;
      
        public GerenciadorDeCerimonias()
        {
            this.AgendaParaCinquentaPessoas = new List<ReservaCinquenta>();
        }

        public void AgendarCerimonia(int qtdPessoas) //Agenda a cerimônia no espaço mais apropriado
        {
            if (qtdPessoas > 2 && qtdPessoas <= 50) // Agendamento do espaço para 50 pessoas.
            {
                ReservaCinquenta agenda = new ReservaCinquenta();
                agenda.reservar();
                this.AgendaParaCinquentaPessoas.Add(agenda);
            }
            else if(qtdPessoas > 50 && qtdPessoas <= 100) // Agendamento do espaço para 51 à 100 pessoas.
            {

            }
            else if (qtdPessoas > 100 && qtdPessoas <= 200) // Agendamento do espaço para 101 à 200 pessoas.
            {

            }
            else if (qtdPessoas > 200 && qtdPessoas <= 500) // Agendamento do espaço para 201 à 500 pessoas.
            {

            }
            else { throw new Exception("ouve um erro na validação na quantidade de pessoas especificadas pelo usuário"); }
        }
    }
}
