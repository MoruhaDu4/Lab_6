namespace Lab_6
{
    class Bell
    {
        public event Action Event1;
        public event Action Event2;
        public event Action Event3;

        private int n;

        public Bell(int number)
        {
            n = number;
        }

        public void Ring()
        {
            if (n == 1)
            {
                Event1?.Invoke();
            }
            else if (n == 2)
            {
                Event2?.Invoke();
            }
            else if (n == 3)
            {
                Event3?.Invoke();
            }
        }

        private void OnEvent1()
        {
            Console.WriteLine($"Дзвiнок {n}. Увага!!");
        }

        private void OnEvent2()
        {
            Console.WriteLine($"Дзвiнок {n}. Пiдготуватися!");
        }

        private void OnEvent3()
        {
            Console.WriteLine($"Дзвiнок {n}. Вистава починається.");
        }

        public void Subscribe()
        {
            Event1 += OnEvent1;
            Event2 += OnEvent2;
            Event3 += OnEvent3;
        }
    
    }
    class Actor
    {
        private string name;

        public Actor(string actorName)
        {
            name = actorName;
        }

        public void OnEvent1()
        {
            Console.WriteLine($"Актор {name} гримується.");
        }

        public void OnEvent2()
        {
            Console.WriteLine($"Актор {name} пiдготувався.");
        }

        public void OnEvent3()
        {
            Console.WriteLine($"Актор {name} на сцену.");
        }
    }

    class Spectator
    {
        private string name;

        public Spectator(string spectatorName)
        {
            name = spectatorName;
        }

        public void OnEvent1()
        {
            Console.WriteLine($"Глядач {name} зайшов у театр.");
        }

        public void OnEvent2()
        {
            Console.WriteLine($"Глядач {name} здає одяг у гардероб.");
        }

        public void OnEvent3()
        {
            Console.WriteLine($"Глядач {name} зайшов до зали.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Actor actor = new Actor("Олександр");
            Spectator spectator = new Spectator("Василь");

            Bell bell1 = new Bell(1);
            bell1.Subscribe();
            bell1.Ring();
            actor.OnEvent1();
            spectator.OnEvent1();

            Bell bell2 = new Bell(2);
            bell2.Subscribe();
            bell2.Ring();
            actor.OnEvent2();
            spectator.OnEvent2();
           
            Bell bell3 = new Bell(3);
            bell3.Subscribe();
            bell3.Ring();
            actor.OnEvent3();
            spectator.OnEvent3();
           
        }
    }
}