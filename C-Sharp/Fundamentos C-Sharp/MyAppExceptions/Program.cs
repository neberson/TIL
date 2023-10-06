
using System.Runtime.ConstrainedExecution;

namespace MyAppExceptions;
class Program
{
    static void Main(String[] args)
    {
        var arr = new int[3];
        try
        {
            /* for (int index = 0; index < 10; index++)
             {
                 Console.WriteLine(arr[index]);
             }*/
            Cadastrar("");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.InnerException);
            Console.WriteLine(ex.Message);
            Console.WriteLine("Não encontrei o indice na lista!");
        }
        catch (MinhaException ex)
        {
            Console.WriteLine(ex.QuandoAconteceu);
        }
        catch
        {
            Console.WriteLine($"Ops, Algo deu errado!");
        }
        finally
        {
            Console.WriteLine("Chegou ao fim do código!");
        }


    }

    static void Cadastrar(string texto)
    {
        if (string.IsNullOrEmpty(texto))
        {
            throw new MinhaException(DateTime.Now);
        }
    }

    public class MinhaException : Exception
    {
        public MinhaException(DateTime date)
        {
            QuandoAconteceu = date;
        }
        public DateTime QuandoAconteceu { get; set; }
    }
}