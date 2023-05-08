using System.Linq.Expressions;
namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var people = new People();
        people.nome = "duigi";
        people.id = 1;
        var lista = new List<People>();
        lista.Add(people);
        /* lista.Add("primeiro");
        var teste = "oi";
        var obj = new { Nome = "toi" };
        */
        var test = lista.Find(x => x.id == 1);
        Console.WriteLine(test.nome);
        soma(2, 3);
    }

     static void soma(int num, int num2)
    {
        Console.WriteLine(num + num2);
    }

     class People
     {
          public int id { get; set; }       
          
          public string nome { get; set; }

          public override string ToString()
          {
              return base.ToString();
          }
     }
}