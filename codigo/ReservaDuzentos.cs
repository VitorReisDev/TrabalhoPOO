using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO
{
    
    public class ReservaDuzentos : Reserva
    {
        
        EspacoDuzentos EspacoDuzentos;

        private int cont;
        public ReservaDuzentos()
        {
            this.EspacoDuzentos = new EspacoDuzentos();
        }

        public override void reservar()
        {
            DateTime dataTemp = EncontrarDataDisponivel();
            if (Reserva.DataDaUltimaReserva < dataTemp && cont <= 2)
            {
                this.EspacoDuzentas.SetDataReservada(EncontrarDataDisponivel());
                Reserva.DataDaUltimaReserva = EncontrarDataDisponivel();
                this.EspacoDuzentos.MostrarReservas();
                cont++;
            }
            else
            {
                this.EspacoDuzentos.SetDataReservada(ObterProximaData());
                Reserva.DataDaUltimaReserva = ObterProximaData();
                this.EspacoDuzentos.MostrarReservas();
            }
        }
        protected override DateTime ObterProximaData()
        {
            DateTime dataTemp = ReservaDuzentos.DataDaUltimaReserva;

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
