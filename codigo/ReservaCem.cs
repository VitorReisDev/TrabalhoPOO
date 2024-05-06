using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOOList
{
    
    public class ReservaCem : Reserva
    {
        EspacoCem EspacoCem;

        public ReservaCem()
        {
            this.EspacoCem = new EspacoCem();
        }

        public override void reservar()
        {
            DateTime dataTemp = EncontrarDataDisponivel();
            if (Reserva.DataDaUltimaReserva < dataTemp)
            {
                this.EspacoCem.SetDataReservada(EncontrarDataDisponivel());
                Reserva.DataDaUltimaReserva = EncontrarDataDisponivel();
                this.EspacoCem.MostrarReservas();
            }
            else
            {
                this.EspacoCem.SetDataReservada(ObterProximaData());
                Reserva.DataDaUltimaReserva = ObterProximaData();
                this.EspacoCem.MostrarReservas();
            }
        }
        protected override DateTime ObterProximaData()
        {
            DateTime dataTemp = ReservaCem.DataDaUltimaReserva;

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
