using RPG_OOP.classy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using RPG_OOP.Source_codes;
using System.Runtime.Versioning;
using RPG_OOP.Properties;
using RPG_OOP.Source_codes.Gamemanager;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace RPG_OOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameService gameMaster = new GameService();
            GameRepository gameRepository = gameMaster.gameRepository;

            //Prvně ho spustíme
            while (gameRepository.startGame)
            {
                //Vypiš text z resourcesu a vytvoř hráče pomocí GameMastera
                Console.Write(Resources.welcomeText);
                gameMaster.SetPlayer(Console.ReadLine());
                Console.WriteLine("-----------------");
            }

        zacatek:

            string input = "";

            while (input == "" || gameRepository.config.comb == false)
            {
                input = Console.ReadLine();
                if (input == "")
                {
                    krok();
                }


                if (gameRepository.player.hp <= 0 || input == "exit")
                {
                    Console.WriteLine("zemřel jsi");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Zemřel hrdina jménem: " + gameRepository.player.name);
                    Console.WriteLine("S počtem kroků: " + gameRepository.player.stepCounter);
                    Console.ReadLine();
                    break;
                }

                if (input == "help")
                {

                    Console.WriteLine("Všechny použitelné příkazy");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("exit  příkaz pro opuštění programu");
                    Console.WriteLine("help pro zobrazeni tohoto menu");
                    Console.WriteLine("postava pro výpis atributů a inventáře tvé postavy");
                    Console.ReadLine();

                }

                if (input == "postava")
                {
                    Console.Clear();
                    Console.WriteLine("Tvá postava");
                    Console.WriteLine("-----------");
                    Console.WriteLine("Jméno: " + gameRepository.player.name);
                    Console.WriteLine("Životy: " + gameRepository.player.hp);
                    Console.WriteLine("Počet kroků: " + gameRepository.player.stepCounter);
                    Console.WriteLine("Coiny: " + gameRepository.player.coins);
                    if (gameRepository.player.items.Count == 0)
                    {
                        Console.WriteLine("Tvůj inventář: " + "Tvůj Inventář je prázdný");
                    }
                    else
                    {
                        Console.WriteLine("-Tvůj inventář-");
                        Console.WriteLine("       ↓      ");
                        for (int i = 0; i < gameRepository.player.items.Count; i++)
                        {
                            Console.WriteLine(gameRepository.player.items[i].Name);
                        }
                    }

                    Console.ReadLine();

                }


                if (gameRepository.config.comb == true)
                {
                    break;
                }




            }

            void krok()
            {
                //Když nemám file, nejede hra, nicméně file by se měl načíst pouze jednou, ne více krát
                //string filePath = @"C:\\Users\\PCnetz\\Desktop\\PRG\\RPG-OOP\\negr.txt";

                //Soubor byl uložen lokálně, tedy je vždy k dispozici v projektu na deploy
                //string[] lines = File.ReadAllLines(filePath);
                string[] lines = Resources.File.Split(new[] { "\r\n" }, StringSplitOptions.None);

                Random random = new Random();
                int randomIndex = random.Next(lines.Length);

                string selectedLine = lines[randomIndex];
                string[] parts = selectedLine.Split(';');
                double iD = double.Parse(parts[0]);
                string text = parts[1];
                gameRepository.player.stepCounter++;

                Console.WriteLine(text);


                if (iD == 0.00)
                {

                }
                else if (iD == 1.01)
                {
                    //Můžu nahradit že .enemy = new Entity("Krysa", 4, 1, false, 5);
                    //Entity krysa = new Entity("Krysa", 4, 1, false, 5);
                    Console.WriteLine("-----------------");
                    gameRepository.enemy = new Entity("Krysa", 4, 1, false, 5);
                    while (gameRepository.enemy.Hp > 0)
                    {

                        combat();

                    }

                    if (gameRepository.enemy.Hp <= 0)
                    {
                        gameRepository.config.heavy = true;
                        gameRepository.config.kro = true;
                        gameRepository.config.utek = true;
                        int vysledek = gameRepository.player.coins + gameRepository.enemy.Reward;
                        gameRepository.player.coins = vysledek;


                    }

                }
                else if (iD == 1.02)
                {
                    //Můžu nahradit že .enemy = new Entity("Vlk", 6, 3, false, 8);
                    //Entity Vlk = new Entity("Vlk", 6, 3, false, 8);
                    Console.WriteLine("-----------------");
                    gameRepository.enemy = new Entity("Vlk", 6, 3, false, 8);
                    while (gameRepository.enemy.Hp > 0)
                    {

                        combat();

                    }

                    if (gameRepository.enemy.Hp <= 0)
                    {
                        gameRepository.config.heavy = true;
                        gameRepository.config.kro = true;
                        gameRepository.config.utek = true;
                        int vysledek = gameRepository.player.coins + gameRepository.enemy.Reward;
                        gameRepository.player.coins = vysledek;


                    }


                }
                else if (iD == 2.00)
                {
                    bool tra = true;
                    while (tra == true)
                    {
                        Console.WriteLine("Chceš začít obchodovat?");
                        Console.WriteLine("1 Ano, ukaž mi co nabízíš");
                        Console.WriteLine("2 Ne, momentálně obchodovat nechci");
                        string trad = Console.ReadLine();
                        if (trad == "1")
                        {
                            trade();
                            tra = false;
                        }
                        else if (trad == "2")
                        {
                            tra = false;
                        }
                        else
                        {

                        }
                    }
                }

                //Jsou 4h rano a mam v sobe 4ty kafe, miluju svuj zivot xD
                //o tejden pozdejs a nic se nezmenilo :D

                //Pohoda, uděláme GameManagera, ten se postará o gamesu
            }


            void combat()
            {
                gameRepository.config.comb = true;


                Console.WriteLine();

                Console.WriteLine("Vyber jednu z nasledujících možností");
                Console.WriteLine("1 pro základní útok");
                Console.WriteLine("2 pro těžký útok");
                Console.WriteLine("3 pro pokus o útěk");

                string comba = Console.ReadLine();
                if (gameRepository.enemy.Hp <= 0)
                {
                    krok();
                }

                if (comba == "1")
                {
                    int result1 = gameRepository.enemy.Hp - gameRepository.player.dmg;
                    gameRepository.enemy.Hp = result1;
                    //Zobrazuj jednoduché infomace ať player a entita ať vypíšou své stavy, pravidlo "Do not repeat yourself" viz "https://en.wikipedia.org/wiki/Don%27t_repeat_yourself"
                    Console.WriteLine(gameRepository.player.PlayerFeedbackOnDamage());
                    Console.WriteLine(gameRepository.enemy.EntityFeedback());
                    Console.ReadLine();
                    if (gameRepository.enemy.Hp > 0)
                    {
                        enemyAtt();
                    }


                }
                if (comba == "2" && gameRepository.config.heavy == false)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Teď nemůžeš použít těžký útok");
                    Console.ReadLine();
                }

                if (comba == "2" && gameRepository.config.heavy == true)
                {
                    gameRepository.config.heavy = false;
                    int result2 = (int)(gameRepository.enemy.Hp - (gameRepository.player.dmg * gameRepository.player.multiplier));
                    gameRepository.enemy.Hp = result2;
                    Console.WriteLine("Zasadil jsi nepříteli " + gameRepository.enemy.Name + " těžký úder a zbývá mu " + gameRepository.enemy.Hp);
                    Console.ReadLine();
                    if (gameRepository.enemy.Hp > 0)
                    {
                        enemyAtt();
                    }


                }

                if (comba == "3" && gameRepository.config.utek == false)
                {
                    Console.WriteLine("O útěk jsi se již pokusil a nevyšlo to");

                }

                if (comba == "3" && gameRepository.config.utek == true)
                {
                    bool GeneratorBool()
                    {
                        Random random = new Random();
                        return random.Next(100) < 20;
                    }
                    bool sance = GeneratorBool();
                    if (sance == true)
                    {
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Povedlo se ti utéct");
                        gameRepository.enemy.Hp = 0;
                    }
                    if (sance == false)
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Nepovedlo se ti utéct");
                        gameRepository.config.utek = false;
                    }


                }

            }

            void enemyAtt()
            {

                int result2 = gameRepository.player.hp - gameRepository.enemy.Dmg;
                gameRepository.player.hp = result2;
                Console.WriteLine("Nepřítel " + gameRepository.enemy.Name + " ti udělil " + gameRepository.enemy.Dmg + " poškození a zbívá ti " + gameRepository.player.hp + " životů.");
                Console.ReadLine();

            }

            if (gameRepository.config.kro == true)
            {
                goto zacatek;
            }

            void trade()
            {
                Console.WriteLine("--Itemy nabýzené traderem--");
                Console.WriteLine("1 pro zakoupení topůrka za 5 Coinů");
                Console.WriteLine("2 pro zakoupení čepele sekery za 3 Coiny");
                Console.WriteLine("3 pro zakoupení obvazu za 10 Coinů");
                Console.WriteLine("4 pro odchod");

                string tradeRoz = Console.ReadLine();

                if (tradeRoz == "1" && gameRepository.player.coins >= 5)
                {
                    Item topurko = new Item("Topůrko", 0, 0, true, 4, 0);
                    gameRepository.player.items.Add(topurko);
                    Console.WriteLine("Zakoupil jsi topůrko za 5 coinů, bylo ti přidáno do Inventáře");


                }
                if (tradeRoz == "1" && gameRepository.player.coins < 5)
                {
                    Console.WriteLine("Nemáš dostatek Coinů");
                }


                if (tradeRoz == "2" && gameRepository.player.coins >= 3)
                {
                    Item cepel = new Item("Čepel sekery", 0, 0, true, 2, 0);
                    gameRepository.player.items.Add(cepel);
                    Console.WriteLine("Zakoupil jsi čepel sekery za 3 coiny, byla ti přidáno do Inventáře");

                }
                if (tradeRoz == "2" && gameRepository.player.coins < 3)
                {
                    Console.WriteLine("Nemáš dostatek Coinů");
                }


                if (tradeRoz == "3" && gameRepository.player.coins >= 10)
                {
                    Item obvaz = new Item("Obvaz", 0, 0, false, 0, 10);
                    gameRepository.player.items.Add(obvaz);
                    Console.WriteLine("Zakoupil jsi obvaz za 10 Coinů, byl ti přidán do Inventáře ");

                }
                if (tradeRoz == "3" && gameRepository.player.coins < 10)
                {
                    Console.WriteLine("Nemáš dostatek Coinů");
                }

            }

        }
    }
}
