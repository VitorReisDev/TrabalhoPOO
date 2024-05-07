using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabalhoPOO;

namespace trabalhoPOOList
{
    public class GerenciadorDeCerimonias
    {
        private List<ReservaCinquenta> AgendaParaCinquentaPessoas;
        private List<ReservaCem> AgendaParaCemPessoas;
        private List<ReservaDuzentos> AgendaParaDuzentosPessoas;

      
        public GerenciadorDeCerimonias()
        {
            this.AgendaParaCinquentaPessoas = new List<ReservaCinquenta>();
            this.AgendaParaCemPessoas = new List<ReservaCem>();
            this.AgendaParaDuzentosPessoas = new List<ReservaDuzentos>();
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
                ReservaCem agenda = new ReservaCem();
                agenda.reservar();
                this.AgendaParaCemPessoas.Add(agenda);
            }
            else if (qtdPessoas > 100 && qtdPessoas <= 200) // Agendamento do espaço para 101 à 200 pessoas.
            {
                ReservaDuzentos agenda = new ReservaDuzentos();
                agenda.reservar();
                this.AgendaParaDuzentosPessoas.Add(agenda);
            }
            else if (qtdPessoas > 200 && qtdPessoas <= 500) // Agendamento do espaço para 201 à 500 pessoas.
            {

            }
            else { throw new Exception("ouve um erro na validação na quantidade de pessoas especificadas pelo usuário"); }
        }
    }
}
