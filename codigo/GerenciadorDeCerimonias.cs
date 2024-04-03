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
        private List<DadosDoEvento> AgendaParaCinquentaPessoas;
        private List<DadosDoEvento> AgendaParaCemPessoas;
        private List<DadosDoEvento> AgendaParaDuzentasPessoas;
        private List<DadosDoEvento> AgendaParaQuinhentasPessoas;
        public GerenciadorDeCerimonias()
        {
            this.AgendaParaCinquentaPessoas = new List<DadosDoEvento>();
            this.AgendaParaCemPessoas = new List<DadosDoEvento>();
            this.AgendaParaDuzentasPessoas = new List<DadosDoEvento>();
            this.AgendaParaQuinhentasPessoas = new List<DadosDoEvento>();
        }

        public void AgendarCerimonia() //Agenda a cerimônia no espaço mais apropriado
        {
            int qtdPessoas = ValidarQtdParticipantes();
            if (qtdPessoas <= 50) // Agendamento do espaço para 50 pessoas (Somente 1 por data).
            {
                DadosDoEvento agendar = new DadosDoEvento();
                if (this.AgendaParaCinquentaPessoas.Count == 0) //Realizará o primeiro agendamento da lista na data mínima disponível (30 dias após o dia atual sexta/sábado).
                {

                    agendar.EncontrarPrimeiraDataValida();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaCinquentaPessoas.Add(agendar);
                }
                else //Realizará os agendamento após a data marcada anteriormente.
                {
                    agendar.ObterProximaDataValida();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaCinquentaPessoas.Add(agendar);
                }
            }
            else if (qtdPessoas > 50 && qtdPessoas <= 100)// Agendamento do espaço para 100 pessoas (4 por data).
            {
                DadosDoEvento agendar = new DadosDoEvento();

                if (this.AgendaParaCemPessoas.Count == 0)//Realizará o primeiro agendamento da agenda na data mínima disponível (30 dias após o dia atual sexta/sábado)
                {
                    agendar.EncontrarPrimeiraDataValida();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaCemPessoas.Add(agendar);
                }
                else if (VerificarDisponibilidadeEspacoCemPessoas()) // Repetirá o agendamento na data marcada anteriormente, caso a quantidade de 4 agendamentos do espaço por data não tenha excedido.
                {
                    agendar.RepetirDataAnterior();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaCemPessoas.Add(agendar);
                }
                else //Realizará os agendamento após a data marcada anteriormente.
                {
                    agendar.ObterProximaDataValida();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaCemPessoas.Add(agendar);
                }
            }
            else if (qtdPessoas > 100 && qtdPessoas <= 200) // Agendamento do espaço para 100 pessoas (2 por data).
            {
                DadosDoEvento agendar = new DadosDoEvento();

                if (this.AgendaParaDuzentasPessoas.Count == 0) //Realizará o primeiro agendamento da agenda na data mínima disponível (30 dias após o dia atual sexta/sábado)
                {
                    agendar.EncontrarPrimeiraDataValida();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaDuzentasPessoas.Add(agendar);
                }
                else if(VerificarDisponibilidadeEspacoDuzentasPessoas()) // Repetirá o agendamento na data marcada anteriormente, caso a quantidade de 2 agendamentos do espaço por data não tenha excedido.
                {

                    agendar.RepetirDataAnterior();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaDuzentasPessoas.Add(agendar);
                }
                else //Realizará os agendamento após a data marcada anteriormente.
                {
                    agendar.ObterProximaDataValida();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaDuzentasPessoas.Add(agendar);
                }
            }
            else if (qtdPessoas > 200 && qtdPessoas <= 500)// Agendamento do espaço para 500 pessoas (1 por data).
            {
                DadosDoEvento agendar = new DadosDoEvento();
                if (this.AgendaParaQuinhentasPessoas.Count == 0) //Realizará o primeiro agendamento da lista na data mínima disponível (30 dias após o dia atual sexta/sábado).
                {

                    agendar.EncontrarPrimeiraDataValida();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaQuinhentasPessoas.Add(agendar);
                }
                else //Realizará os agendamento após a data marcada anteriormente.
                {
                    agendar.ObterProximaDataValida();
                    agendar.ReservarEspaco(agendar, qtdPessoas);
                    this.AgendaParaQuinhentasPessoas.Add(agendar);
                }
            }
        }

        private int ValidarQtdParticipantes()// Verifica se a quantidade de participantes é válida
        {
            int qtdPartcipantes;

            Console.WriteLine("Digite a quantidade de pessoas que irà participar do evento");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out qtdPartcipantes) && (qtdPartcipantes >= 2) && (qtdPartcipantes <= 500))
                {
                    return qtdPartcipantes;
                }
                else { Console.WriteLine("Digite uma quantidade válida de convidados"); }
            }
        }
        public bool VerificarDisponibilidadeEspacoCemPessoas() // auxilia no o método AgendarCerimonia no controle de quantidade de agendamentos por data (4 agendamentos por data)
        {
            bool resultadoVerificacao = false;
            int contadorDeEventosMarcados = 0;
            int indiceUltimoAgendamento = this.AgendaParaCemPessoas.Count - 1;
            DateTime dataAtualReservada = this.AgendaParaCemPessoas[indiceUltimoAgendamento].DataDaCerimonia;

            if (this.AgendaParaCemPessoas.Count <= 4)
            {
                // Verifica se há mais de três evento marcado para a mesma data
                for (int i = indiceUltimoAgendamento; i >= 0; i--)
                {
                    if (this.AgendaParaCemPessoas[i].DataDaCerimonia == dataAtualReservada)
                    {
                        contadorDeEventosMarcados++;
                    }
                }

                // Se houver mais de três evento marcado para a mesma data, retorna falso
                if (contadorDeEventosMarcados == 4)
                {
                    resultadoVerificacao = false;
                }
                else { resultadoVerificacao = true; }
            }

            // Se houver mais de quatro eventos marcados, verifica se o antepenúltimo evento é para a mesma data( retorna false se for, e verdadeiro caso nao seja)
            else if (this.AgendaParaCemPessoas.Count > 4)
            {
                if (this.AgendaParaCemPessoas[indiceUltimoAgendamento - 3].DataDaCerimonia == dataAtualReservada)
                {
                    resultadoVerificacao = false;
                }
                else { resultadoVerificacao = true; }
            }

            return resultadoVerificacao;
        }
        public bool VerificarDisponibilidadeEspacoDuzentasPessoas()// auxilia no o método AgendarCerimonia no controle de quantidade de agendamentos por data (2 agendamentos por data)
        {
            bool resultadoVerificacao = false;
            int contadorDeEventosMarcados = 0;
            int indiceUltimoAgendamento = this.AgendaParaDuzentasPessoas.Count - 1;
            DateTime dataAtualReservada = this.AgendaParaDuzentasPessoas[indiceUltimoAgendamento].DataDaCerimonia;

            if (this.AgendaParaDuzentasPessoas.Count <= 2)
            {
                // Verifica se há mais de um evento marcado para a mesma data
                for (int i = indiceUltimoAgendamento; i >= 0; i--)
                {
                    if (this.AgendaParaDuzentasPessoas[i].DataDaCerimonia == dataAtualReservada)
                    {
                        contadorDeEventosMarcados++;
                    }
                }

                // Se houver mais de um evento marcado para a mesma data, retorna falso
                if (contadorDeEventosMarcados >= 2)
                {
                    resultadoVerificacao = false;
                }
                else
                {
                    resultadoVerificacao = true;
                }
            }
            else // Se houver mais de dois eventos marcados, verifica se o penúltimo evento é para a mesma data
            {
                if (this.AgendaParaDuzentasPessoas[indiceUltimoAgendamento - 1].DataDaCerimonia == dataAtualReservada)
                {
                    resultadoVerificacao = false;
                }
                else
                {
                    resultadoVerificacao = true;
                }
            }

            return resultadoVerificacao;
        }
        public void MostrarCerimoniasAgendadas()// Exibi na tela os agendamentos efetuados nas agendas
        {
            int contCinquentaPessoas = 0;
            int contCemPessoas = 0;
            int contDuzentasPessoas = 0;
            int contQuinhentasPessoas = 0;

            // Verifica as cerimônias agendadas para cinquenta pessoas
            if (this.AgendaParaCinquentaPessoas.Count > 0)
            {
                foreach (var cerimonia in this.AgendaParaCinquentaPessoas)
                {
                    if (cerimonia != null)
                    {
                        Console.WriteLine($" Data da cerimônia : {cerimonia.DataDaCerimonia.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($" Capacidade do espaço reservado : {cerimonia.CapacidadeDoEspaco}");
                        Console.WriteLine($" Status do espaço : {cerimonia.StatusDoEspaco}");
                        Console.WriteLine($" Quantidade de participantes : {cerimonia.QtdDeParticipantes}");
                        contCinquentaPessoas++;
                    }
                }
                Console.WriteLine($"\nTotal de cerimônias para cinquenta pessoas: {contCinquentaPessoas}\n");
            }

            // Verifica as cerimônias agendadas para cem pessoas
            if (this.AgendaParaCemPessoas.Count > 0)
            {
                foreach (var cerimonia in this.AgendaParaCemPessoas)
                {
                    if (cerimonia != null)
                    {
                        Console.WriteLine($" Data da cerimônia : {cerimonia.DataDaCerimonia.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($" Capacidade do espaço reservado : {cerimonia.CapacidadeDoEspaco}");
                        Console.WriteLine($" Status do espaço : {cerimonia.StatusDoEspaco}");
                        Console.WriteLine($" Quantidade de participantes : {cerimonia.QtdDeParticipantes}");
                        contCemPessoas++;
                    }
                }
                Console.WriteLine($"\nTotal de cerimônias para cem pessoas: {contCemPessoas}\n");
            }

            // Verifica as cerimônias agendadas para duzentas pessoas
            if (this.AgendaParaDuzentasPessoas.Count > 0)
            {
                foreach (var cerimonia in this.AgendaParaDuzentasPessoas)
                {
                    if (cerimonia != null)
                    {
                        Console.WriteLine($" Data da cerimônia : {cerimonia.DataDaCerimonia.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($" Capacidade do espaço reservado : {cerimonia.CapacidadeDoEspaco}");
                        Console.WriteLine($" Status do espaço : {cerimonia.StatusDoEspaco}");
                        Console.WriteLine($" Quantidade de participantes : {cerimonia.QtdDeParticipantes}");
                        contDuzentasPessoas++;
                    }
                }
                Console.WriteLine($"\nTotal de cerimônias para duzentas pessoas: {contDuzentasPessoas}\n");
            }

            // Verifica as cerimônias agendadas para quinhentas pessoas
            if (this.AgendaParaQuinhentasPessoas.Count > 0)
            {
                foreach (var cerimonia in this.AgendaParaQuinhentasPessoas)
                {
                    if (cerimonia != null)
                    {
                        Console.WriteLine($" Data da cerimônia : {cerimonia.DataDaCerimonia.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($" Capacidade do espaço reservado : {cerimonia.CapacidadeDoEspaco}");
                        Console.WriteLine($" Status do espaço : {cerimonia.StatusDoEspaco}");
                        Console.WriteLine($" Quantidade de participantes : {cerimonia.QtdDeParticipantes}");
                        contQuinhentasPessoas++;
                    }
                }
                Console.WriteLine($"\nTotal de cerimônias para quinhentas pessoas: {contQuinhentasPessoas} \n");
            }
            Console.ReadLine();
        }

    }
}
