namespace trabalhoPOOList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GerenciadorDeCerimonias agendar = new GerenciadorDeCerimonias();

            // teste para 50 pessoas
            for(int i = 0; i < 4; i++)
            {
                agendar.AgendarCerimonia();
            }
            
            // teste para 100 pessoas

            for (int i = 0; i < 12; i++)
            {
                agendar.AgendarCerimonia();
            }
            
            // teste para 200 pessoas 

            for (int i = 0; i < 8; i++)
            {
                agendar.AgendarCerimonia();
            }

            // teste para 500 pessoas 

            for (int i = 0; i < 4; i++)
            {
                agendar.AgendarCerimonia();
            }
            agendar.MostrarCerimoniasAgendadas();
        }
    }
}