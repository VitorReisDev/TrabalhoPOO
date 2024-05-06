using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    Quinhentas = 500
}

namespace trabalhoPOOList
{
    public class DadosDoEvento //Responsável pelos componentes do eventos
    {
        private static DateTime DataReservada; 
        public DateTime DataDaCerimonia { get; set; }
        public StatusEspaco StatusDoEspaco { get; set; }
        public CapacidadeEspaco CapacidadeDoEspaco { get; set; }
        public int QtdDeParticipantes { get; set; }

        public void EncontrarPrimeiraDataValida() // itera até obter a primeira data válida ((sexta feira) caso a data mínima que é 30 dias após a data atual não seja sexta ou sábado) 
        {
            DateTime dataAtual = DateTime.Today;
            DateTime dataMinima = dataAtual.AddDays(30);

            while (dataMinima.DayOfWeek != DayOfWeek.Friday && dataMinima.DayOfWeek != DayOfWeek.Saturday)
            {
                dataMinima = dataMinima.AddDays(1);
            }
            this.DataDaCerimonia = dataMinima;
            DadosDoEvento.DataReservada = dataMinima;
        }
        public void ObterProximaDataValida() // Procura uma data valida após a data mínima
        {

            this.DataDaCerimonia = DadosDoEvento.DataReservada.Date.AddDays(AvancarParaProximaData());
            DadosDoEvento.DataReservada = this.DataDaCerimonia;

        }
        public void RepetirDataAnterior() // Repete a data da última cerimônia marcada..
        {
            this.DataDaCerimonia = DadosDoEvento.DataReservada;
        } 
        private int AvancarParaProximaData() // Auxilia o método ObterProximaDataValida a saltar para o próximo dia válido.(sexta/sábado)
        {
            int diasParaAvancar = 0;
            if (DadosDoEvento.DataReservada.DayOfWeek == DayOfWeek.Friday)
            {
                diasParaAvancar = 1;
            }
            else if (DadosDoEvento.DataReservada.DayOfWeek == DayOfWeek.Saturday)
            {
                diasParaAvancar = 6;
            }
            else { throw new ArgumentException("O dia especificado não é sexta e nem sábado"); }

            return diasParaAvancar;
        }
        private void ArmazenarQtdParticipantes(int qtdParticipantes)// Armazena na propriedade QtdDeParticpantes a quantidade de participantes informada pelos noivos
        {
            this.QtdDeParticipantes = qtdParticipantes;
        }
        private void ArmazenarCapacidadeDoEspaco(int qtdParticipantes)// Armazena na propriedade CapacidadeDoEspaco a sua capacidade(Levando em consideração a quantidade de participantes informada pelos noivos)
        {
            if (qtdParticipantes <= 0 || qtdParticipantes > 500)
            {
                Console.WriteLine($"Quantidade de participantes inválida. Quantidade : {qtdParticipantes}");
            }
            else if (qtdParticipantes <= 50)
            {
                this.CapacidadeDoEspaco = CapacidadeEspaco.Cinquenta;
            }
            else if (qtdParticipantes > 50 && qtdParticipantes <= 100)
            {
                this.CapacidadeDoEspaco = CapacidadeEspaco.Cem;
            }
            else if (qtdParticipantes > 100 && qtdParticipantes <= 200)
            {
                this.CapacidadeDoEspaco = CapacidadeEspaco.Duzentas;
            }
            else { this.CapacidadeDoEspaco = CapacidadeEspaco.Quinhentas; }
        }
        public void ReservarEspaco(DadosDoEvento agenda, int qtdParticipantes)// Reserva o espaço atualizando seu status (Auxiliado pelos métodos ArmazenarQtdParticipantes && ArmazenarCapacidadeDoEspaco)
        {
            this.StatusDoEspaco = StatusEspaco.Reservado;
            ArmazenarQtdParticipantes(qtdParticipantes);
            ArmazenarCapacidadeDoEspaco(qtdParticipantes);
        }

    }
}
