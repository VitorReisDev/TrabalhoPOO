using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabalhoPOOList;

namespace trabalhoPOO
{
    
    public class ReservaDuzentos : Reserva
    {
        
        EspacoDuzentos EspacoDuzentos;

        private static int cont;
        public ReservaDuzentos()
        {
            this.EspacoDuzentos = new EspacoDuzentos();
        }

public override void reservar()
{
    DateTime dataReserva = EncontrarDataDisponivel();
    if (cont < 2)
    {
        this.EspacoDuzentos.SetDataReservada(dataReserva);
        Reserva.DataDaUltimaReserva = dataReserva;
        this.EspacoDuzentos.MostrarReservas();
        Console.WriteLine("oiii");
        cont++;
        Console.WriteLine(cont);
    }
    else
    {
        
        cont = 0;
        dataReserva = ObterProximaData();
        this.EspacoDuzentos.SetDataReservada(dataReserva);
        Reserva.DataDaUltimaReserva = dataReserva;
        this.EspacoDuzentos.MostrarReservas();
        Console.WriteLine("oi");
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
