using System;

namespace PrimeiroAPP;

public class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<int>> registeredBands = new Dictionary<string, List<int>>();
        Dictionary<string, string> normalizedBandNames = new Dictionary<string, string>();

        bool TryGetKeyFromValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue value, out TKey key)
            where TKey : notnull
            where TValue : notnull
        {
            try
            {
                // Makes sure the dictionary's values are all unique
                Dictionary<TValue, TKey> reversedDictionary = new Dictionary<TValue, TKey>();
                foreach (KeyValuePair<TKey, TValue> kvp in dictionary)
                {
                    reversedDictionary.Add(kvp.Value, kvp.Key);
                }

                key = reversedDictionary[value];
                return true;
            }
            catch (KeyNotFoundException)
            {
                key = default!;
                return false;
            }
            catch (Exception ex)
            {
                key = default!;
                Console.WriteLine($"Erro: {ex}");
                return false;
            }
        }

        void UpdateBandNameCache()
        {
            // Adds and updates cached band names
            foreach (string bandName in registeredBands.Keys)
            {
                if (normalizedBandNames.ContainsKey(bandName))
                    continue;

                string normalizedBandName = bandName.ToLower();
                normalizedBandNames.Add(bandName, normalizedBandName);
            }

            // Removes band names that are no longer registered
            foreach (string bandName in normalizedBandNames.Keys)
            {
                if (!registeredBands.Keys.Contains(bandName))
                    normalizedBandNames.Remove(bandName);
            }
        }

        // Checks if a band name is already registered
        void CheckBeforeAddBand(string bandName, out bool result)
        {
            if (normalizedBandNames.Values.Contains(bandName.ToLower()))
            {
                result = false;
            }
            else
            {
                registeredBands.Add(bandName, new List<int>());
                UpdateBandNameCache();
                result = true;
            }
        }

        string CleanASCIIArt(string asciiArt)
        {
            // Splits the ASCII art into lines
            string[] splitASCII = asciiArt.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Trims the leading spaces from each line, except the first one
            for (int i = 1; i < splitASCII.Length; i++)
            {
                splitASCII[i] = splitASCII[i].TrimStart(' ');
            }

            // Creates a new array to hold the trimmed lines
            string[] resultASCII = new string[splitASCII.Length - 1];
            for (int i = 1; i < splitASCII.Length; i++)
            {
                resultASCII[i - 1] = $"* {splitASCII[i]} *";
            }

            return String.Join(Environment.NewLine, resultASCII);
        }

        void DisplayTitle(string title)
        {
            title = CleanASCIIArt(title);
            // Creates a string of asterisks with the same length as the ASCII art
            string asterisks = new string('*', title.Split(new [] {Environment.NewLine}, StringSplitOptions.None)[0].Length);

            Console.Clear();
            Console.WriteLine(asterisks);
            Console.WriteLine(title);
            Console.WriteLine(asterisks);
            Console.WriteLine();
        }

        bool TryYesOrNo(string userInput, out int response)
        {
            string[] confirm = { "sim", "s", "yes", "y" };
            string[] deny = { "não", "n", "no" };

            if (confirm.Contains(userInput))
            {
                response = 0;
                return true;
            }
            else if (deny.Contains(userInput))
            {
                response = 1;
                return true;
            }
            response = default;
            return false;
        }

        void DisplayMenu()
        {
            Console.WriteLine("Digite 1 para registrar uma banda.");
            Console.WriteLine("Digite 2 para mostrar as bandas registradas.");
            Console.WriteLine("Digite 3 para avaliar uma banda.");
            Console.WriteLine("Digite 4 para mostrar a média de uma banda.");
            Console.WriteLine("Digite -1 para sair.");
            Console.WriteLine();

            string userInput = String.Empty;
            int convertedInput = 0;

            while (true)
            {
                try
                {
                    Console.Write("Digite a opção desejada: ");
                    userInput = Console.ReadLine()!;
                    convertedInput = int.Parse(userInput);
                    if ((convertedInput >= 1 && convertedInput <= 4) || convertedInput == -1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                        Console.WriteLine();
                    }
                }
                catch (FormatException ex)
                {
                    // User input couldn't be converted into a number. E.g.: "Hello", "", "Cat".
                    Console.WriteLine($"Erro: {ex}.");
                    Console.WriteLine();
                }
                catch (OverflowException ex)
                {
                    // User input is too large a number. E.g.: 99999999999999999999999999999.
                    Console.WriteLine($"Erro: {ex}.");
                    Console.WriteLine();
                }
            }

            switch (convertedInput)
            {
                case -1:
                    Console.WriteLine("Saindo do programa...");
                    break;
                case 1:
                    Console.WriteLine($"Você escolheu a opção {convertedInput}, registrar uma banda.");
                    RegisterBand();
                    break;
                case 2:
                    Console.WriteLine($"Você escolheu a opção {convertedInput}, mostrar as bandas registradas.");
                    ShowRegisteredBands();
                    break;
                case 3:
                    Console.WriteLine($"Você escolheu a opção {convertedInput}, avaliar uma banda.");
                    RateBands();
                    break;
                case 4:
                    Console.WriteLine($"Você escolheu a opção {convertedInput}, mostrar a média de uma banda.");
                    ShowBandAverage();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    break;
            }
        }

        // Displays the main menu
        void DisplayMainMenu()
        {
            string title = @"
                ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
                ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
                ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
                ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
                ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
                ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";
            DisplayTitle(title);
            DisplayMenu();
        }

        // Registers a band
        void RegisterBand()
        {
            string title = @"
                ██████╗░███████╗░██████╗░██████░░██████╗╔██████╗██████╗░░█████╗░██████╗░
                ██╔══██╗██╔════╝██╔════╝░╚═██╔╝░██╔════╝╚══██╔═╝██╔══██╗██╚═╗██╗██╔══██╗
                ██████╔╝█████╗░░██║████╗░░░██║░░╚█████╗░░░░██║░░██████╔╝██░░╚██║██████╔╝
                ██╔══██╗██╔══╝░░██║╚═██║░░╔██║░░░╚═══██╗░░╔██║░░██╔══██╗███████║██╔══██╗
                ██║░░██║███████╗╚██████╝░██████░██████╔╝░░╚██║░░██║░░██║██╚══██║██║░░██║
                ╚═╝░░╚═╝╚══════╝░╚════╝░░╚════╝░╚═════╝░░░░╚═╝░░╚═╝░░╚═╝╚╝░░░╚═╝╚═╝░░╚═╝";
            DisplayTitle(title);
            Console.WriteLine("Registro de bandas:");
            Console.WriteLine();
            AddBandToDictionary();
            DisplayMainMenu();
        }

        // Formats the band name to be capitalized
        string FormatBandName(string bandName)
        {
            string[] dontCapitalize = { "da", "de", "do", "das", "dos", "e", "a", "o", "as", "os", "an", "the", "and", "of", "for", "in", "on", "at", "to", "with" };
            string[] bandNameSplit = bandName.Split(' ');
            for (int i = 0; i < bandNameSplit.Length; i++)
            {
                if (!char.IsLetter(bandNameSplit[i][0]))
                    continue;
                if (i == 0 || !dontCapitalize.Contains(bandNameSplit[i].ToLower()))
                    bandNameSplit[i] = bandNameSplit[i][0].ToString().ToUpper() + bandNameSplit[i].Substring(1);
                if (dontCapitalize.Contains(bandNameSplit[i].ToLower()))
                    continue;
            }

            return String.Join(' ', bandNameSplit);
        }

        // Logic to add a band to the list
        void AddBandToDictionary()
        {
            while (true)
            {
                Console.Write("Digite o nome da banda que deseja registrar, ou digite -1 para retornar: ");
                string userInputBandName = Console.ReadLine()!;
                if (userInputBandName == "-1")
                {
                    break;
                }
                else if (!String.IsNullOrWhiteSpace(userInputBandName))
                {
                    bool bandExists;
                    CheckBeforeAddBand(FormatBandName(userInputBandName), out bandExists);
                    if (bandExists)
                    {
                        Console.Write($"A banda {userInputBandName} foi registrada com sucesso!");
                        Thread.Sleep(2000);
                        break;
                    }
                    Console.WriteLine($"A banda {userInputBandName} já foi registrada. Por favor, tente novamente.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"A banda ou comando inserido (\"{userInputBandName}\") é inválido. Por favor, tente novamente.");
                    Console.WriteLine();
                }
            }
        }

        // Shows the registered bands
        void ShowRegisteredBands()
        {
            string title = @"
                ██████░░░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
                ██░░╚██╗██╚═╗██╗████╗░██║██╔══██╗██╚═╗██╗██╔════╝
                ██████═╝██░░╚██║██╔██╗██║██║░░██║██░░╚██║╚█████╗░
                ██╚══██╗███████║██║╚████║██║░░██║███████║░╚═══██╗
                ███████║██╚══██║██║░╚███║██████╔╝██╚══██║██████╔╝
                ╚══════╝╚╝░░░╚═╝╚═╝░░╚══╝╚═════╝░╚╝░░░╚═╝╚═════╝░";
            DisplayTitle(title);

            if (registeredBands.Count > 0)
            {
                Console.WriteLine("Bandas registradas: ");
                foreach (string band in registeredBands.Keys)
                {
                    Console.WriteLine($"- {band}");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.WriteLine($"Total de bandas registradas: {registeredBands.Count}.");
                Console.Write("Pressione enter para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.Write("Nenhuma banda registrada.");
                Thread.Sleep(2000);
            }
            DisplayMainMenu();
        }

        // Rates a band
        void RateBands()
        {
            string title = @"
                ░█████╗░██░░╔██╗░█████╗░██╗░░░░░░██████░░█████╗░██████╗░
                ██╚═╗██╗██░░╚██╝██╚═╗██╗██║░░░░░░╚═██╔╝░██╚═╗██╗██╔══██╗
                ██░░╚██║╚██░██║░██░░╚██║██║░░░░░░░░██║░░██░░╚██║██████╔╝
                ███████║░██░██║░███████║██╝░░╔═╗░░╔██║░░███████║██╔══██╗
                ██╚══██║░╚███╚╝░██╚══██║███████╝░██████░██╚══██║██║░░██║
                ╚╝░░░╚═╝░░╚═╝░░░╚╝░░░╚═╝╚═════╝░░╚════╝░╚╝░░░╚═╝╚═╝░░╚═╝";
            DisplayTitle(title);

            if (registeredBands.Count > 0)
            {
                Console.WriteLine("Avaliação de bandas: ");
                
                while (true)
                {
                    Console.Write("Digite o nome de uma banda que deseja avaliar, ou digite -1 para voltar ao menu principal: ");
                    string userInputBandRating;
                    string userInputBandName = Console.ReadLine()!.ToLower();
                    if (userInputBandName == "-1")
                    {
                        break;
                    }
                    else if (normalizedBandNames.Values.Contains(userInputBandName))
                    {
                        string chosenBand = "";
                        TryGetKeyFromValue(normalizedBandNames, userInputBandName, out chosenBand);
                        
                        Console.WriteLine($"Você escolheu a banda {chosenBand}.");                        
                        while (true)
                        {
                            Console.Write($"Digite uma nota de 0 a 10 para a banda {chosenBand}, ou digite -1 para voltar: ");
                            userInputBandRating = Console.ReadLine()!;
                            int userInputBandRatingInt;

                            while (!int.TryParse(userInputBandRating, out userInputBandRatingInt) || userInputBandRatingInt < -1 || userInputBandRatingInt > 10)
                            {
                                Console.WriteLine();
                                Console.Write($"Comando inválido: {userInputBandRating}. Digite -1 para voltar, ou uma nota de 0 a 10 para avaliar a banda {chosenBand}: ");
                                userInputBandRating = Console.ReadLine()!;
                            }

                            if (userInputBandRatingInt == -1)
                            {
                                Console.WriteLine();
                                break;
                            }
                            else
                            {
                                registeredBands[chosenBand].Add(userInputBandRatingInt);
                                Console.Write($"Você avaliou a banda {chosenBand} com a nota {userInputBandRating}!");
                                Thread.Sleep(2000);
                                break;
                            }
                        }
                        if (userInputBandRating != "-1")
                            break;
                    }
                    else if (!String.IsNullOrWhiteSpace(userInputBandName) && !normalizedBandNames.Values.Contains(userInputBandName.ToLower()))
                    {
                        Console.WriteLine($"Comando inválido, ou a banda não foi registrada: (\"{userInputBandName}\").");
                        while (true)
                        {
                            Console.Write("Você gostaria de registrar como uma banda (sim/não)? ");
                            string userInputResponse = Console.ReadLine()!.ToLower();
                            string[] confirm = { "sim", "s", "yes", "y" };
                            string[] deny = { "não", "n", "no" };
                            if (confirm.Contains(userInputResponse))
                            {
                                registeredBands.Add(userInputBandName, new List<int>());
                                UpdateBandNameCache();
                                Console.WriteLine("Você escolheu sim.");
                                Thread.Sleep(2000);
                                break;
                            }
                            else if (deny.Contains(userInputResponse))
                            {
                                Console.Write("Você escolheu não.");
                                Thread.Sleep(2000);
                                break;
                            }
                            Console.WriteLine($"Comando inválido (\"{userInputResponse}\"). Por favor, tente novamente.");
                        }                        
                    }
                    else
                    {
                        Console.WriteLine($"Comando inválido ou a banda não foi registrada: (\"{userInputBandName}\"). Por favor, tente novamente.");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.Write("Nenhuma banda registrada.");
                Thread.Sleep(2000);
            }
            DisplayMainMenu();
        }

        // Shows a band's average rating
        void ShowBandAverage()
        {
            string title = @"
                ██░░╔██╗███████╗██████╗░░██████░░█████╗░
                ███╔███║██╔════╝██╔══██╗░╚═██╔╝░██╚═╗██╗
                ███████║█████╗░░██║░░██║░░░██║░░██░░╚██║
                ██░█╔██║██╔══╝░░██║░░██║░░╔██║░░███████║
                ██░█╚██╝███████╗██████╔╝░██████░██╚══██║
                ╚╝░╚══╝░╚══════╝╚═════╝░░╚════╝░╚╝░░░╚═╝";
            DisplayTitle(title);

            Console.WriteLine("Média de uma banda: ");
            Console.WriteLine();

            if (registeredBands.Count > 0)
            {
                while (true)
                {
                    Console.Write("Digite o nome de uma banda que você deseja ver a média, ou digite -1 para voltar ao menu principal: ");
                    string userInputBandName = Console.ReadLine()!.ToLower();
                    string chosenBand = "";

                    if (userInputBandName == "-1")
                    {
                        break;
                    }
                    else if (TryGetKeyFromValue(normalizedBandNames, userInputBandName, out chosenBand))
                    {
                        Console.WriteLine($"Você escolheu a banda {chosenBand}.");
                        if (registeredBands[chosenBand].Count == 0)
                        {
                            Console.WriteLine("A banda escolhida não possui avaliações.");
                            string userInput;
                            bool rateAgain;
                            while (true)
                            {
                                Console.Write("Você gostaria de ver a média de outra banda (sim/não)? ");
                                userInput = Console.ReadLine()!;
                                if (TryYesOrNo(userInput, out int response))
                                {
                                    if (response == 0)
                                    {
                                        Console.WriteLine();
                                        rateAgain = true;
                                        break;
                                    }
                                    else if (response == 1)
                                    {
                                        Console.WriteLine();
                                        rateAgain = false;
                                        break;
                                    }
                                }
                                Console.WriteLine($"Comando inválido (\"{userInput}\"). Por favor, tente novamente.");
                                Console.WriteLine();
                            }
                            if (!rateAgain)
                                break;
                        }
                        else
                        {
                            int average = 0;
                            foreach (int rating in registeredBands[chosenBand])
                            {
                                average += rating;
                            }

                            Console.WriteLine($"A média da banda escolhida é: {average / registeredBands[chosenBand].Count}.");
                            string userInput;
                            bool rateAgain;

                            while (true)
                            {
                                while (true)
                                {
                                    Console.Write("Você gostaria de ver a média de outra banda (sim/não)? ");
                                    userInput = Console.ReadLine()!;
                                    if (TryYesOrNo(userInput, out int response))
                                    {
                                        if (response == 0)
                                        {
                                            Console.WriteLine();
                                            rateAgain = true;
                                            break;
                                        }
                                        else if (response == 1)
                                        {
                                            Console.WriteLine();
                                            rateAgain = false;
                                            break;
                                        }
                                    }
                                    Console.WriteLine($"Comando inválido (\"{userInput}\"). Por favor, tente novamente.");
                                    Console.WriteLine();
                                }
                                break;
                            }
                            if (!rateAgain)
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Comando inválido ou a banda não foi registrada: (\"{userInputBandName}\"). Por favor, tente novamente.");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.Write("Nenhuma banda registrada.");
                Thread.Sleep(2000);
            }
            DisplayMainMenu();
        }

        DisplayMainMenu();

        Console.WriteLine("Aperte enter para sair...");
        Console.ReadLine();
    }
}

