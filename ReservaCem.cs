using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOOList
{
    
    public class ReservaCinquenta : Reserva
    {
        EspacoCinquenta EspacoCinquenta;

        public ReservaCinquenta()
        {
            this.EspacoCinquenta = new EspacoCinquenta();
        }

        public override void reservar()
        {
            DateTime dataTemp = EncontrarDataDisponivel();
            if (Reserva.DataDaUltimaReserva < dataTemp)
            {
                this.EspacoCinquenta.SetDataReservada(EncontrarDataDisponivel());
                Reserva.DataDaUltimaReserva = EncontrarDataDisponivel();
                this.EspacoCinquenta.MostrarReservas();
            }
            else
            {
                this.EspacoCinquenta.SetDataReservada(ObterProximaData());
                Reserva.DataDaUltimaReserva = ObterProximaData();
                this.EspacoCinquenta.MostrarReservas();
            }
        }
        protected override DateTime ObterProximaData()
        {
            DateTime dataTemp = ReservaCinquenta.DataDaUltimaReserva;

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
