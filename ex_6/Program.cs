using System;

namespace ex_6
{
    internal class Program
    {
        private static void ShowRules()
        {
            Console.WriteLine();
            Console.WriteLine("========RULES========");
            Console.WriteLine("Условия завершения игры:");
            Console.WriteLine("  1. ХП игрока опустилось ниже нуля");
            Console.WriteLine("  2. ХП врага опустилось ниже нуля");
            Console.WriteLine();
            Console.WriteLine("Условия использования заклинаний:");
            Console.WriteLine("  1. Призыв существа");
            Console.WriteLine("    1.1 Поглощает 100 хп призывателя, возможен призыв только одного существа");
            Console.WriteLine("    1.2 Наносит 100 единиц урона каждый следующий ход, теряя 100 своих хп");
            Console.WriteLine("    1.3 У существа 400 единиц здоровья");
            Console.WriteLine("  2. Хаганзакура");
            Console.WriteLine("    2.1 Можно использовать, только если было призвано существо");
            Console.WriteLine("    2.2 Наносит 100 единиц урона");
            Console.WriteLine("  3. Межпространственный разлом");
            Console.WriteLine("    3.1 Персонаж уходит в Межпространственный разлом, игнорирует атаку врага и регенерирует 200хп");
            Console.WriteLine("  4. Фаерболл");
            Console.WriteLine("    4.1 Наносит 200 единиц урона");
            Console.WriteLine("    4.2 Можно использовать, только если хп игрока превышает 400");
            Console.WriteLine("  5. Авада Кедавра");
            Console.WriteLine("    5.1 Добивающее заклинание, можно использовать только если хп врага меньше 100хп");
            Console.WriteLine("    5.2 Запрещенное заклинание, после использования вы будете вне закона");
            Console.WriteLine("=====================");
            Console.WriteLine();
        }

        private static void ShowState()
        {
            Console.WriteLine("Состояние персонажей:");
            Console.WriteLine($"  Босс  - {bossHitPoint} хп");
            Console.WriteLine($"  Игрок - {playerHitPoint} хп");
            if (unitHitPoint > 0)
            {
                Console.WriteLine($"  Призванное существо - {unitHitPoint} хп");
            }
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("  0 - Посмотреть правила и условия использования заклинаний");
            Console.WriteLine("  1 - Использовать заклинание \"Призыв Существа\"");
            Console.WriteLine("  2 - Использовать заклинание \"Хаганзакура\"");
            Console.WriteLine("  3 - Использовать заклинание \"Межпространственный разлом\"");
            Console.WriteLine("  4 - Использовать заклинание \"Фаерболл\"");
            Console.WriteLine("  5 - Использовать заклинание \"Авада Кедавра\"");
        }

        private static bool ChooseAttack()
        {
            var state = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (state)
            {
                case 0:
                    ShowRules();
                    break;

                case 1:
                    if (unitHitPoint <= 0 && playerHitPoint > 100)
                    {
                        unitHitPoint = 400;
                        playerHitPoint -= 100;
                        Console.WriteLine("Вы призвали существо, потратив 100хп, которое будет наносить 100 единиц урона каждый ход\r\n");
                        return true;
                    }
                    Console.WriteLine("Существо уже было призвано, или хп игрока меньше сотни");
                    return false;

                case 2:
                    if (unitHitPoint > 0)
                    {
                        Console.WriteLine("Вы нанесли 100 единиц урона");
                        bossHitPoint -= 100;
                        Console.WriteLine("Существо нанесло 100 единиц урона и потратило 100хп");
                        bossHitPoint -= 100;
                        unitHitPoint -= 100;
                        return true;
                    }

                    return false;

                case 3:
                    if (!isHide)
                    {
                        Console.WriteLine("Вы ушли в Пространственный разлом и восстановили 200хп");
                        Console.WriteLine("Вы игнорируете один удар босса");
                        playerHitPoint += 200;
                        isHide = true;
                        isAttackable = false;
                        return true;
                    }
                    Console.WriteLine("Войти в пространственный разлом дважды нельзя");
                    return false;

                case 4:
                    if (unitHitPoint > 0 && playerHitPoint >= 400)
                    {
                        Console.WriteLine("Вы нанесли 200 единиц урона");
                        bossHitPoint -= 200;
                        Console.WriteLine("Существо нанесло 100 единиц урона и потратила 100хп");
                        bossHitPoint -= 100;
                        unitHitPoint -= 100;
                        return true;
                    }

                    Console.WriteLine("Использовать заклинание \"Фаерболл\" в таких условиях нельзя");
                    return false;

                case 5:
                    if (bossHitPoint <= 100)
                    {
                        Console.WriteLine("Вы добили Босса, использовав заклинание \"Авада Кедавра\"");
                        Console.WriteLine("Теперь вы вне закона!");
                        bossHitPoint = 0;
                        isAttackable = false;
                        return true;
                    }

                    Console.WriteLine("Использовать заклинание \"Авада Кедавра\" в таких условиях нельзя");
                    return false;

                default:
                    Console.WriteLine("Вы сделали неправильный выбор, попробуйте снова)");
                    return false;
            }

            return false;
        }

        private static void bossAttack()
        {
            var rnd = new Random();
            var straigt = rnd.Next(100, 150);

            Console.WriteLine($"Босс нанес вам {straigt} единиц урона");
            playerHitPoint -= straigt;
        }

        private static int bossHitPoint;
        private static int playerHitPoint;
        private static int unitHitPoint = 0;
        private static bool isHide = false;
        private static bool isAttackable = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Вы – теневой маг и" +
                              " у вас в арсенале есть несколько заклинаний, которые" +
                              " вы можете использовать против Босса. Вы должны уничтожить" +
                              " босса и только после этого будет вам покой.\r\n");
            Random rnd = new Random();
            bossHitPoint = rnd.Next(400, 550);
            playerHitPoint = rnd.Next(300, 400);


            bool isPlayerFirst = Convert.ToBoolean(rnd.Next(0, 2));
            

            while (bossHitPoint > 0 && playerHitPoint > 0)
            {
                ShowState();

                if (isPlayerFirst)
                {
                    var isCorrect = ChooseAttack();
                    while (!isCorrect)
                    {
                        ShowState();
                        isCorrect = ChooseAttack();
                    }
                }

                if (isAttackable)
                {
                    bossAttack();
                }
                isAttackable = true;
                isPlayerFirst = true;
            }
        }
    }
}
