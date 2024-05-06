using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOOList
{
    public abstract class  Reserva
    {
        protected static DateTime DataDaUltimaReserva;
        Espaco espaco;
        
        public Reserva()
        {
            this.espaco = new Espaco();
        }

        public abstract void reservar();
        protected virtual DateTime EncontrarDataDisponivel()
        {
            DateTime dataTemp = new DateTime();
            dataTemp = DateTime.Today.AddDays(30);

            while (dataTemp.DayOfWeek != DayOfWeek.Friday && dataTemp.DayOfWeek != DayOfWeek.Saturday)
            {
                dataTemp = dataTemp.AddDays(1);
            }


            return dataTemp;
        }
        protected abstract DateTime ObterProximaData();

    }
}
