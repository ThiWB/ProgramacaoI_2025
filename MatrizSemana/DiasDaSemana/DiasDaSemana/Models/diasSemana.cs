namespace DiasDaSemana.Models
{
    public class diasSemana
    {

        //Vetor que armazena os dias da semana
        public string[] diasDaSemana = new string[]
        {
            "DOMINGO", "SEGUNDA-FEIRA", "TERÇA-FEIRA", "QUARTA-FEIRA", "QUINTA-FEIRA", "SEXTA-FEIRA", "SÁBADO"
        };

        //Método para retornar dia da semana com base no input do usuário
        public string OutputDiaSemana(int userInput)
        {
            if(userInput < 1 || userInput > 7)
            {
                return "Esse dia não existe! Digite um Número de 1 a 7!";
            }

            return diasDaSemana[userInput - 1];
        }
    }
}
