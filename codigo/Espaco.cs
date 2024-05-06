using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace trabalhoPOOList
{
    public class Espaco
    {
        protected DateTime DataReservada;
        protected EnunsEspaco.CapacidadeEspaco CapacidadeDoEspaco;

        public Espaco(EnunsEspaco.CapacidadeEspaco capacidadeDoEspaco)
        {
            this.DataReservada = new DateTime();
            this.CapacidadeDoEspaco = capacidadeDoEspaco;
        }
        public Espaco()
        {

        }

        public virtual void SetDataReservada(DateTime dataReservada)
        {
            this.DataReservada = dataReservada;
        }
        public void MostrarReservas()
        {
            Console.WriteLine("Datas reservadas");
            Console.WriteLine($"Data reservada: {this.DataReservada}");
            Console.WriteLine($"Capacidade do espaço: {this.CapacidadeDoEspaco}");
        }



    }

   
}
