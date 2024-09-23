using System;

namespace Slagsmålspelet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapa två slagskämpar med namn och hp
            Fighter fighterA = new Fighter("Slagskämpe A", 100);
            Fighter fighterB = new Fighter("Slagskämpe B", 100);

            Random random = new Random();

            // While-loop för att simulera kampen så länge båda har HP kvar
            while (fighterA.HP > 0 && fighterB.HP > 0)
            {
                // Slagskämpe A attackerar B
                int damageToB = random.Next(5, 16); // Slumpa en skada mellan 5 och 15
                fighterB.TakeDamage(damageToB);
                Console.WriteLine($"{fighterA.Name} slår {fighterB.Name} för {damageToB} skada! {fighterB.Name} har {fighterB.HP} HP kvar.");

                // Kontrollera om B är besegrad
                if (fighterB.HP <= 0) break;

                // Slagskämpe B attackerar A
                int damageToA = random.Next(5, 16);
                fighterA.TakeDamage(damageToA);
                Console.WriteLine($"{fighterB.Name} slår {fighterA.Name} för {damageToA} skada! {fighterA.Name} har {fighterA.HP} HP kvar.");

                // Kontrollera om A är besegrad
                if (fighterA.HP <= 0) break;

                // Pausa för att göra striden mer spännande
                System.Threading.Thread.Sleep(1000); // Vänta 1 sekund mellan rundorna
            }

            // Avgör vinnaren
            if (fighterA.HP <= 0 && fighterB.HP <= 0)
            {
                Console.WriteLine("Det blev oavgjort! Båda slagskämparna föll samtidigt.");
            }
            else if (fighterA.HP <= 0)
            {
                Console.WriteLine($"{fighterB.Name} vann striden!");
            }
            else if (fighterB.HP <= 0)
            {
                Console.WriteLine($"{fighterA.Name} vann striden!");
            }
            Console.ReadLine();
        }


    }

    // Skapa en Fighter-klass för att representera en slagskämpe
    class Fighter
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public Fighter(string name, int hp)
        {
            Name = name;
            HP = hp;
        }

        // Metod för att hantera när en slagskämpe tar skada
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                HP = 0; // HP kan inte gå under 0
            }
        }
    }
}
