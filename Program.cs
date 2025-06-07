using CoinVendingMachine.Models;
using CoinVendingMachine.Repositories.Interfaces;
using CoinVendingMachine.Repositories;
using CoinVendingMachine.Services;
using Microsoft.Extensions.DependencyInjection;
using CoinVendingMachine.Enums;
using CoinVendingMachine.Constants;


namespace CoinVendingMachine
{
    public class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICoinRepository, CoinRepository>();
            services.AddSingleton<IProductItemTypeRepository, ProductItemTypeRepository>();
            services.AddSingleton<CoinVendingMachineService>();
            var provider = services.BuildServiceProvider();

            var machine = provider.GetRequiredService<CoinVendingMachineService>();

            Console.WriteLine(Constant.VendingMachine);

            bool running = true;
            while (running)
            {
                Console.WriteLine(Constant.MainMenu);
                machine.ShowDisplay();
                Console.WriteLine(Constant.InsertCoinMenu);
                Console.WriteLine(Constant.SelectProductMenu);
                Console.WriteLine(Constant.ShowCoinMenu);
                Console.WriteLine(Constant.Exit);
                Console.Write(Constant.SelectMenu);

                int.TryParse(Console.ReadLine(),out int input);

                switch (input)
                {
                    case 1:
                        Console.Write(Constant.EnterCoinType);
                        var coinInput = Console.ReadLine();
                        if (!(int.TryParse(coinInput, out _)) && Enum.TryParse(coinInput, true, out CoinType coinType))
                        {
                            machine.InsertCoin(new Coins { Type = coinType });
                        }
                        else
                        {
                            Console.WriteLine(Constant.InvalidCoinType);
                        }
                        break;

                    case 2:
                        Console.Write(Constant.EnterProduct);
                        var product = Console.ReadLine();
                        machine.SelectProduct(product??string.Empty);
                        break;

                    case 3:
                        machine.ShowCoinReturn();
                        break;

                    case 4:
                        running = false;
                        break;

                    default:
                        Console.WriteLine(Constant.InvalidSelection);
                        break;
                }
            }

            Console.WriteLine(Constant.ThankYouMessage);
        }
    }
}
