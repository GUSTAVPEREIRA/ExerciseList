using System;
using ExerciseList.DTO.Product;
using ExerciseList.DTO.User;
using ExerciseList.Exercise4.Controller;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ExerciseList.Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = InitializeServices();
            ProductController productController = new ProductController(serviceProvider.GetService<IProductService>());
            UserController userController = new UserController(serviceProvider.GetService<IUserService>());
            CartController cartController = new CartController(serviceProvider.GetService<ICartService>(), serviceProvider.GetService<ICalculationService>());

            UserDTO currentUser = null;

            int option = 0;

            do
            {
                var signIn = currentUser != null;
                option = Menu(signIn);

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Encerrando".PadLeft(100, '.'));
                        break;
                    case 1:
                        var userName = Console.ReadLine();
                        currentUser = userController.SignIn(userName);

                        if (currentUser != null)
                        {
                            Console.WriteLine($"Bem vindo {currentUser.Name}");
                            cartController.OpenCart(currentUser);
                        }
                        else
                        {
                            Console.WriteLine($"Usuário inválido!");
                        }

                        break;
                    case 2:
                        ShowProductList(productController);

                        break;
                    case 3:

                        if (signIn)
                        {
                            ShowProductList(productController);
                            var addProduct = productController.GetProduct(GetConsoleActionKey("\nDigite o id do produto:"));
                            cartController.AddItem(addProduct, GetConsoleActionKey("Digite as quantidade:"));
                        }

                        break;
                    case 4:

                        if (signIn)
                        {
                            ShowProductList(productController);
                            var removeProduct = productController.GetProduct(GetConsoleActionKey("\nDigite o id do produto"));
                            cartController.RemoveItem(removeProduct, GetConsoleActionKey("Digite as quantidade:"));
                        }

                        break;

                    case 5:

                        if (signIn)
                        {
                            Console.WriteLine(cartController.GetReportShip());
                        }

                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

            } while (option != 0);
        }

        private static int GetConsoleActionKey(string message)
        {
            int key = 0;
            Console.WriteLine(message);
            int.TryParse(Console.ReadLine(), out key);

            return key;
        }

        private static void ShowProductList(ProductController productController)
        {
            Console.WriteLine($"ID\t{"Nome".PadRight(70)} Valor");

            foreach (var product in productController.GetProducts())
            {
                Console.WriteLine($"{product.Id}\t{product.Name.PadRight(70)} {product.Price:C2}");
            }
        }

        private static ServiceProvider InitializeServices()
        {
            return new ServiceCollection()
                        .AddSingleton<ICorreiosService, CorreiosService>()
                        .AddSingleton<IProductService, ProductService>()
                        .AddSingleton<IUserService, UserService>()
                        .AddSingleton<ICartService, CartService>()
                        .AddSingleton<ICalculationService, CalculationService>()
                        .BuildServiceProvider();
        }

        private static int Menu(bool userSignIn)
        {
            int key;
            Console.WriteLine("\n------ Menu ------");
            Console.WriteLine("1 Logar com o Usuário!");
            Console.WriteLine("2 Lista de Produtos");

            if (userSignIn)
            {
                Console.WriteLine("3 Inserir produto");
                Console.WriteLine("4 Remover Produto");
                Console.WriteLine("5 Relatório de compras");
            }

            Console.WriteLine("0 Sair");

            Console.Write("Opção:");
            int.TryParse(Console.ReadLine(), out key);
            Console.WriteLine("\n");

            return key;
        }
    }
}