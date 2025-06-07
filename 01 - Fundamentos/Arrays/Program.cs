namespace Arrays{
    class  Program{
        
        static string[] agenda = new string[10]; 
        
        static void Main(){
            Console.WriteLine(agenda.Length);
            Menu();
        }


        static void Menu(){
            Console.Clear();
            int escolha;
            do{
                Console.WriteLine("1 - Adicionar Contato\n" +
                                  "2 - Remover contato\n" +
                                  "3 - Editar contato\n" +
                                  "4 - Listar contatos\n" +
                                  "5 - Popular contatos\n" +
                                  "0 - Sair");
                escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha){
                    case 1: Adicionar(); break;
                    case 2: Remover(); break;
                    case 3: Editar(); break;
                    case 4: Listar(); break;
                    case 5: Popular(); break;
                }
            } while (escolha != 0);

        }

        static void Adicionar(){
            Console.Clear();
            Console.WriteLine("Digite a posicao do contato: ");
            int posicao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o nome do contato");
            agenda[posicao] = Console.ReadLine();
            
            
        }
        static void Remover(){
            Console.Clear();
            Console.WriteLine("Digite a posicao do contato: ");
            int posicao = Convert.ToInt32(Console.ReadLine());
            agenda[posicao] = null;
            
        }
        static void Editar(){
            Console.Clear();
            Remover();
            Adicionar();
        }

        static void Listar(){
            Console.Clear();
            for (int i = 0; i < agenda.Length; i++){
                Console.WriteLine(agenda[i]);
            }
            Console.ReadLine();
            Menu();
        }

        static void Popular(){
            for (int i = 0; i < agenda.Length; i++){
                agenda[i] = ($"Joazinho da Silva {i}");
            }
        }
    }
}