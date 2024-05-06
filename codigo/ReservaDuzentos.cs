using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using trabalhoPOOList;
=======
>>>>>>> 02f4e516f08b895a2bf4a5b4255010317837f06c

namespace trabalhoPOO
{
    
    public class ReservaDuzentos : Reserva
    {
        
        EspacoDuzentos EspacoDuzentos;

<<<<<<< HEAD
        private static int cont;
=======
        private int cont;
>>>>>>> 02f4e516f08b895a2bf4a5b4255010317837f06c
        public ReservaDuzentos()
        {
            this.EspacoDuzentos = new EspacoDuzentos();
        }

<<<<<<< HEAD
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


=======
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
>>>>>>> 02f4e516f08b895a2bf4a5b4255010317837f06c
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
