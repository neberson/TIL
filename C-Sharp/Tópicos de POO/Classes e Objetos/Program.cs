namespace Estudo_Classes
{
    partial class Program
    {
        static void Main(string[] args)
        {
            /* Para criar o objeto de uma classe deve-se especificar o tipo da classe, o nome do objeto que deseja criar,
             * seguido de igualdade e da palavra reservada "new", após o new utiliza-se o nome da classe novamente seguido de parenteses. Exemplo:
             * <NomeDaClasse> NomeDoObjeto = new NomeDaClasse();*/
            Pessoa pessoa1 = new Pessoa();

            /* Após criar o objeto é possível atribuir valor ao atríbutos e acessa-los, para por exemplo realizar uma impressão do valor.*/
            pessoa1.nome = "Paulo";
            pessoa1.idade = 45;
            pessoa1.genero = "Masculino";
            pessoa1.Identificar();

            /*Além disso é possível definir vários objetos para uma mesma classe*/
            /*Pessoa pessoa2 = new Pessoa();
            pessoa2.nome = "José";
            Console.WriteLine(pessoa2.nome);*/
            /*Todo objeto é instanciado como um tipo por referência, então cada objeto aponta para um local na mémoria e terá seus próprios valores.*/
        }
    }
}