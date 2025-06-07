namespace Fundamentos
{
    class Classe
    {
        static void Main(string[] args){
            var pg = new Pagamentos();
            var pg2 = new PagamentoBoleto();
            var pg3 = new PagamentoCartao();
            pg.Pagar();
            pg2.Pagar();
            pg3.Pagar();
            Console.WriteLine(pg2.numeroBoleto);
            
            Console.WriteLine("--------------Propriedades e Acesso de Atributos-----------------");
            
            var customer = new Customer("Artur", "Rua 5");
            Console.WriteLine(customer.Name);
            customer.Name = "s";
            Console.WriteLine(customer.Address);
            customer.Address = "Rua 5123";
            Console.WriteLine(customer.Address);
            
            Console.WriteLine("---------------Using e Depose--------------------");
            
            //Caso nos nao utilizarmos o Using, seremos obrigados a "Encerrar a conexao com essa classe utilizando Dispose"
            var agendamento = new Agendamento();
            agendamento.Dispose();
            
            //Forma mais facil, onde o gerenciamento e feito automatico
            using (var agendamento2 = new Agendamento()){
                Console.WriteLine("Processando.......");
                Console.WriteLine("Finalizou o processamento");
            }
            
            Console.WriteLine("---------------Classes estaticas e Seladas--------------------");
            //Sempre a mesma informação para todos os usuarios
            Settings.API_URL = "1sddsDSd1199dCs9sc";
            Console.WriteLine(Settings.API_URL);
            
            

        }
    }
    class Customer{
        
        //Forma mais Facil e Rapido, sem validação, nome Precisa ser maiusculo
        public string Address{get;set;}
        
        //Caso tenha alguma validação nos metodos GET E SET, uma boa forma é usar assim
        private string _name;
        public string Name{
            get{
                Console.WriteLine("Acessando o valor de nome");
                return _name;
            }
            set{
                if (value.Length < 2){
                    Console.WriteLine("O nome tem que ser maior que 2");
                    return;
                }
                _name = value;
            }
        }

        public Customer(string name, string address){
            this._name = name;
            this.Address = address;
        }
        public Customer(){}
    }
    class Pagamentos{
        private DateTime vencimento;

        //Virtual permite que esse metodo seja sobrescrito OVERRIDE
        public virtual void Pagar(){
            ConsultarSaldoDoCartao();
            Console.WriteLine("Esse e o do pagar base");
        }

        public void Pagar(string numero){
            ConsultarSaldoDoCartao();
            Console.WriteLine("Esse e o do pagar base usando sobrecarga de metodo");
        }
        public void Pagar(string numero, string numero2){
            ConsultarSaldoDoCartao();
            Console.WriteLine("Esse e o do pagar base usando sobrecarga de metodo 2");
        }
        
        private void ConsultarSaldoDoCartao(){
            
        }
    }
    class PagamentoBoleto : Pagamentos{
        public int numeroBoleto;
        
    }
    class PagamentoCartao : Pagamentos{
        public int numeroCartao;

        public override void Pagar(){
            Console.WriteLine("Esse e o do pagar via cartao");

        }
    }
    public class Agendamento : IDisposable{
        public Agendamento(){
            Console.WriteLine("Iniciando agendamento");
        }

        //Chamado quando o objeto e destruido via Garbage Collector
        public void Dispose(){
            Console.WriteLine("Finalizando agendamento");
        }
    }

    public static class Settings{
        public static string API_URL{get;set;}
    }

    public sealed class Notificacao(){
        private string mensagem;
    }
    //Nao pode ser Extendida, ja que notification e selada
    //public class Notification2:Notificacao{}
}