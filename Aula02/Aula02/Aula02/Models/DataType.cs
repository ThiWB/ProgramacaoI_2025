namespace Aula02.Models
{
    public class DataType
    {
        public char myVar = 'a';
        public char myConst = 'b';


        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';

        //Podemos atribuir referência de caracteres Unicode
        public char myChar4 = '\u2726';

        //Podemos ainda mesclar caracteres especiais como nova linha, tabulação e etc.
        public string textLine = "Esta é uma linha de texto.\n\n\n";

        /*
            \e = caractere de escape
            \n = nova linha
            \r = retorno
            \t = tabulação horizontal
            \" = usado para exibir aspas dentro de string
            \' = usado para exibir aspas simples dentro de string
         */

        private int count = 10;
        public string message;

        public DataType()
        {
            //Interpolação de Strings
            //Combinando Strings de diferentes maneiras no C#
            message = $"O Contador está em {count}";

            string username = "Thiago";
            int inboxCount = 10;
            int maxCount = 100;

            message += $"\nO Usuário {username} tem {inboxCount} Mensagens ";
            message += $"\nEspaço restante em sua Caixa de Entrada {maxCount - inboxCount}";


        }

    }
}
