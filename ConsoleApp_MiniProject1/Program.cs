using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MiniProject_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int AssetLifeTime = 1095;// 3 years(1095 days) of asset Lifetime
            List<storeInventory> storeData = new List<storeInventory>();
            Console.WriteLine("Main Menu: \n");

            try
            {
                while (true)
                {
                    Console.Write("Please Enter Your Choice:  \n ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("1. Register a new asset \n 2. Show List of all Assets \n 3. Exit \n >>");
                    Console.ResetColor();
                    string Choice = Console.ReadLine();
                    if (Choice == "1")
                    {
                        Console.Write("Input Asset ID(like: LM-400 for Laptops and MP-400 for Mobilile Phones):");
                        string Asset_ID = Console.ReadLine();
                        if (string.IsNullOrEmpty(Asset_ID))
                        {
                            Console.Write("Asset type  can't be empty! Input the asset type again:");
                            Asset_ID = Console.ReadLine();
                        }
                        if (Asset_ID.StartsWith("LA"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("CORRECT: This asset a laptop computer");
                        }
                        //else if (Asset_ID.ToLower().Trim().StartsWith('M'))
                        else if (Asset_ID.ToLower().Trim().StartsWith("MPH"))
                        {
                            Console.WriteLine("This asset is stored as a mobile phone");
                            Console.ResetColor();
                        }
                        //Model Name input
                        Console.Write("Input the model name of the asset:");
                        string Model_Name = Console.ReadLine();
                        if (string.IsNullOrEmpty(Model_Name))
                        {
                            Console.Write("Model name can't be empty! Input the model of the asset again:");
                            Model_Name = Console.ReadLine();
                        }
                        // Office location
                        Console.Write("Input location of the asset(You can choose only: Sweden, USA or Japan):");
                        string Bramch_Name = Console.ReadLine();
                        if (Bramch_Name == "Sweden" || Bramch_Name == "Japan" || Bramch_Name == "USA")
                        {
                            //Bramch_Name = Console.ReadLine();
                        }
                        else
                            Console.Write("Sorry! We did not open an office in this country yet,input another location : ");

                        // Currency of the location

                        //Purchase Date input
                        Console.Write("Input the purchase date of the asset(FORMAT: 12/28/2019):");
                        DateTime purchase_date_input = DateTime.Parse(Console.ReadLine());
                        // Price input
                        Console.Write("Input the price of the asset(Default: SEK):");
                        int pr_price = int.Parse(Console.ReadLine());

                        storeInventory AssetsObj = new storeInventory(Asset_ID, Model_Name, Bramch_Name, purchase_date_input, pr_price);
                        storeData.Add(AssetsObj);


                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("A new asset has been successfully registered!");
                        Console.ResetColor();
                        Console.WriteLine("======================================");
                    }
                    else if (Choice == "2")
                    {
                        //Presenting assets ordered by office location
                        List<storeInventory> sortedProducts1 = storeData.OrderBy(si1 => si1.BranchLocations).ToList();
                        Console.WriteLine("Registered Assets SORTED by Office :  ");

                        Console.WriteLine("Asset ID".PadRight(20) + "Asset Model".PadRight(20) + "Office".PadRight(20) + "Purchase Date".PadRight(20) + "Price");
                        foreach (storeInventory si1 in sortedProducts1)
                        {
                            var CurrentDate1 = DateTime.Now;
                            var date1 = CurrentDate1.Date;
                            TimeSpan days1 = CurrentDate1 - si1.PurchaseDate;
                            double NumberofDays1 = AssetLifeTime - days1.Days;
                            if (NumberofDays1 < 90)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(si1.AssetID.PadRight(20) + si1.ModelName.PadRight(20) + si1.BranchLocations.PadRight(20) + si1.PurchaseDate.ToString("d").PadRight(20) + si1.Price);
                                double Rate_USD = 0.12; // 1SEK = 0.12USD  based on todays currency exchange rage                         
                                double Price_US = storeData.Sum(si1 => si1.Price * (Rate_USD));
                                double Rate_yen = 13.01; // 1SEK = 13,01JPY based on todays currency exchange rage
                                double Price_JP = storeData.Sum(si1 => si1.Price * (Rate_yen));
                                Console.WriteLine("Price in USD is  $" + Price_US + "  and in Japanese Yen is: JPY" + Price_JP);
                                Console.ResetColor();
                            }
                            else if (NumberofDays1 < 180)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(si1.AssetID.PadRight(20) + si1.ModelName.PadRight(20) + si1.BranchLocations.PadRight(20) + si1.PurchaseDate.ToString("d").PadRight(20) + si1.Price);
                                double Rate_USD = 0.12; // 1SEK = 0.12USD                              
                                double Price_US = storeData.Sum(si1 => si1.Price * (Rate_USD));
                                double Rate_yen = 13.01; // 1SEK = 13,01JPY
                                double Price_JP = storeData.Sum(si1 => si1.Price * (Rate_yen));

                                Console.WriteLine("Price in USD is  $" + Price_US + "  and in Japanese Yen is: JPY" + Price_JP);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine(si1.AssetID.PadRight(20) + si1.ModelName.PadRight(20) + si1.BranchLocations.PadRight(20) + si1.PurchaseDate.ToString("d").PadRight(20) + si1.Price);
                                double Rate_USD = 0.12; // 1SEK = 0.12USD                              
                                double Price_US = storeData.Sum(si1 => si1.Price * (Rate_USD));
                                double Rate_yen = 13.01; // 1SEK = 13,01JPY
                                double Price_JP = storeData.Sum(si1 => si1.Price * (Rate_yen));
                                Console.WriteLine("Price in USD is  $" + Price_US + "  and in Japanese Yen is: JPY" + Price_JP);

                            }

                        }


                        List<storeInventory> sortedProducts = storeData.OrderBy(si => si.PurchaseDate).ToList();
                        Console.WriteLine(" \n\n Registered Assets SORTED by Purchase Date: ");

                        Console.WriteLine("Asset ID".PadRight(20) + "Asset Model".PadRight(20) + "Office".PadRight(20) + "Purchase Date".PadRight(20) + "Price");
                        foreach (storeInventory si in sortedProducts)
                        {
                            var CurrentDate = DateTime.Now;
                            var date = CurrentDate.Date;
                            TimeSpan days = CurrentDate - si.PurchaseDate;
                            double NumberofDays = AssetLifeTime - days.Days;
                            if (NumberofDays < 90)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(si.AssetID.PadRight(20) + si.ModelName.PadRight(20) + si.BranchLocations.PadRight(20) + si.PurchaseDate.ToString("d").PadRight(20) + si.Price);

                                double Rate_USD = 0.12; // 1SEK = 0.12USD                              
                                double Price_US = storeData.Sum(si => si.Price * (Rate_USD));
                                double Rate_yen = 13.01; // 1SEK = 13,01JPY
                                double Price_JP = storeData.Sum(si => si.Price * (Rate_yen));

                                Console.WriteLine("Price in USD is  $" + Price_US + "  and in Japanese Yen is: JPY" + Price_JP);
                                Console.ResetColor();
                            }
                            else if (NumberofDays < 180 && NumberofDays > 90)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(si.AssetID.PadRight(20) + si.ModelName.PadRight(20) + si.BranchLocations.PadRight(20) + si.PurchaseDate.ToString("d").PadRight(20) + si.Price);

                                double Rate_USD = 0.12; // 1SEK = 0.12USD                              
                                double Price_US = storeData.Sum(si => si.Price * (Rate_USD));
                                double Rate_yen = 13.01; // 1SEK = 13,01JPY
                                double Price_JP = storeData.Sum(si => si.Price * (Rate_yen));

                                Console.WriteLine("Price in USD is  $" + Price_US + "  and in Japanese Yen is: JPY" + Price_JP);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine(si.AssetID.PadRight(20) + si.ModelName.PadRight(20) + si.BranchLocations.PadRight(20) + si.PurchaseDate.ToString("d").PadRight(20) + si.Price);
                                double Rate_USD = 0.12; // 1SEK = 0.12USD                              
                                double Price_US = storeData.Sum(si => si.Price * (Rate_USD));
                                double Rate_yen = 13.01; // 1SEK = 13,01JPY
                                double Price_JP = storeData.Sum(si => si.Price * (Rate_yen));
                                Console.WriteLine("Price in USD is  $" + Price_US + "  and in Japanese Yen is: JPY" + Price_JP);
                            }
                        }
                    }
                    else if (Choice == "3")// Exit
                    {
                        break;
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

    }
}