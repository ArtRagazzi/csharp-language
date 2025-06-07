using System;

namespace BasicoCsharp
{
    struct Product
    {
        public int id;
        public string name;
        public float price;

        public Product(int id, string name, float price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            
        }
        public float PriceInDolar(float actualPrice)
        {
            return price / actualPrice;
        }
    }

    enum EEstadoCivil
    {
        Solteiro = 1,
        Casado = 2,
        Divorciado = 3,
        Viuvo = 4
    }

    struct Pessoa
    {
        public string nome;
        public string sobrenome;
        public int idade;
        public EEstadoCivil estado;

        public Pessoa(string nome, string sobrenome, int idade, EEstadoCivil estado)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.idade = idade;
            this.estado = estado;
        }
    }
    class Program
    {
       static void Main(string[] args)
        {
            int inteiro = 100;
            float real = 15.5f;

            //inteiro = (int)real; // inteiro = 15
            inteiro = Convert.ToInt32(real);//inteiro = 16
            //Parse so aceita String como argumento
            //inteiro = int.Parse(real.ToString());
            
            Console.WriteLine(inteiro);
            
            Console.WriteLine(Convert.ToBoolean(1)); // True, 0 == False
            // ------------------------------------------------

            int valor = 5;
            valor++; // 6
            valor += 5; // 11
            Console.WriteLine(valor);
            
            //-------------------------
            MeuMetodo("Salve Familia");
            // --------------------
            
            Product produto1 = new Product(1,"Computador",3200.5f);
            Console.WriteLine(produto1.PriceInDolar(5.5f));

            Product produto2 = produto1;
            //Struct sao Value Type, Classes Sao Reference Type
            Console.WriteLine(produto2.name);
            produto2.name = "Celular";
            Console.WriteLine("Nome do Produto2 apos mudar prod2 "+produto2.name);
            Console.WriteLine("Nome do Produto1 apos mudar prod2 "+produto1.name);

            //-------------------------
            var pessoa1 = new Pessoa("Julio", "Silva", 24, EEstadoCivil.Solteiro);
            Console.WriteLine(pessoa1.nome);
            Console.WriteLine(pessoa1.sobrenome);
            Console.WriteLine(pessoa1.idade);
            Console.WriteLine(pessoa1.estado);
            Console.WriteLine("Exibindo Enum estado civil em INT "+(int)pessoa1.estado);


        }


        static void MeuMetodo(string palavra)
        {
            Console.WriteLine(palavra);
        }
    }
}

