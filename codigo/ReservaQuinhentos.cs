using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabalhoPOO;

namespace trabalhoPOOList
{
    
    public class ReservaQuinhentos : Reserva
    {
        EspacoQuinhentos EspacoQuinhentos;

        public  ReservaQuinhentos()
        {
            this.EspacoQuinhentos = new EspacoQuinhentos();
        }

        public override void reservar()
        {
            DateTime dataTemp = EncontrarDataDisponivel();
            if (Reserva.DataDaUltimaReserva < dataTemp)
            {
                this.EspacoQuinhentos.SetDataReservada(EncontrarDataDisponivel());
                Reserva.DataDaUltimaReserva = EncontrarDataDisponivel();
                this.EspacoQuinhentos.MostrarReservas();
            }
            else
            {
                this.EspacoQuinhentos.SetDataReservada(ObterProximaData());
                Reserva.DataDaUltimaReserva = ObterProximaData();
                this.EspacoQuinhentos.MostrarReservas();
            }
        }
        protected override DateTime ObterProximaData()
        {
            DateTime dataTemp = ReservaQuinhentos.DataDaUltimaReserva;

            if (dataTemp.DayOfWeek == DayOfWeek.Friday)
            {
                dataTemp = dataTemp.AddDays(1);
            }
            else
            {
                dataTemp = dataTemp.AddDays(6);
            }
            return dataTemp;
        }
    }
}
