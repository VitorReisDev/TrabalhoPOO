namespace trabalhoPOOList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GerenciadorDeCerimonias agendar = new GerenciadorDeCerimonias();


            while (true)
            {
                int qtdPartcipantes;

                Console.WriteLine("Digite a quantidade de pessoas que irà participar do evento");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out qtdPartcipantes) && (qtdPartcipantes >= 2) && (qtdPartcipantes <= 500)) break;
                    else { Console.WriteLine("Digite uma quantidade válida de convidados"); }
                }
                agendar.AgendarCerimonia(qtdPartcipantes);
                
            }




           /*  // teste para 50 pessoas
           for(int i = 0; i < 4; i++)
            {
                agendar.AgendarCerimonia();
            }
            
            // teste para 100 pessoas

            for (int i = 0; i < 12; i++)
            {
                agendar.AgendarCerimonia();
            } */
            
            // teste para 200 pessoas 

           /*  for (int i = 0; i < 8; i++)
            {
                agendar.AgendarCerimonia(200);
            } */

            // teste para 500 pessoas 
/* 
            for (int i = 0; i < 4; i++)
            {
                agendar.AgendarCerimonia();
            }
            agendar.MostrarCerimoniasAgendadas(); */
          
        }
    }
}