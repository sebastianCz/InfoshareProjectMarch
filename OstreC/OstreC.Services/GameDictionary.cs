using System.Reflection;

namespace OstreC.Services
{
    public  class GameDictionary
    {
        public List<Enemy> Enemies = JsonFile.DeserializeFile<List<Enemy>>("Enemy");

        public string ShowEnemies()
        {
            string message = "\n";
            foreach (var item in Enemies)
            {
                message += item.Name + "\n";
            }
            return message;
        }
        public void CompareEnemies(Enemy monster1, Enemy monster2)
        {
            var message = "";
                Console.WriteLine($"Health of {monster1.Name} is: {monster1.HealthPoints} \t\tHealth of {monster2.Name} is: {monster2.HealthPoints}");
            int result = 0;
            if(monster1.HealthPoints >= monster2.HealthPoints)
            {
                result = monster1.HealthPoints - monster2.HealthPoints;
                Console.WriteLine($"Difference between {monster1.Name} Health and {monster2.Name} Health is: {result}");
            }
            else if (monster1.HealthPoints < monster2.HealthPoints)
            {
                result = monster2.HealthPoints - monster1.HealthPoints;
                Console.WriteLine($"Difference between {monster2.Name} Health and {monster1.Name} Health is: {result}");
            }

            Console.WriteLine($"\nCharisma of {monster1.Name} is: {monster1.Charisma} \t\tCharisma of {monster2.Name} is: {monster2.Charisma}");
            if (monster1.Charisma >= monster2.Charisma)
            {
                result = monster1.Charisma - monster2.Charisma;
                Console.WriteLine($"Difference between {monster1.Name} Charisma and {monster2.Name} Charisma is: {result}");
            }
            else if(monster1.Charisma < monster2.Charisma)
            {
                result = monster2.Charisma - monster1.Charisma;
                Console.WriteLine($"Difference between {monster2.Name} Charisma and {monster1.Name} Charisma is: {result}");
            }

            Console.WriteLine($"\nLevel of {monster1.Name} is: {monster1.Level}  \t\tLevel of {monster2.Name} is: {monster2.Level}");
            if(monster1.Level >= monster2.Level)
            {
                result = monster1.Level - monster2.Level;
                Console.WriteLine($"Difference between {monster1.Name} Level and {monster2.Name} Level is: {result}");
            }
            else if(monster1.Level < monster2.Level)
            {
                result = monster2.Level - monster1.Level;
                Console.WriteLine($"Difference between {monster2.Name} Level and {monster1.Name} Level is: {result}");
            }

            Console.WriteLine($"\nStrength of {monster1.Name} is: {monster1.Strength} \t\tStrength of {monster2.Name} is: {monster2.Strength}");
            if(monster1.Strength >= monster2.Strength)
            {
                result = monster1.Strength - monster2.Strength;
                Console.WriteLine($"Difference between {monster1.Name} Strength and {monster2.Name} Strength is: {result}");
            }
            else if(monster1.Strength < monster2.Strength)
            {
                result = monster2.Strength - monster1.Strength;
                Console.WriteLine($"Difference between {monster2.Name} Strength and {monster1.Name} Strength is: {result}");
            }

            Console.WriteLine($"\nIntelligence of {monster1.Name} is: {monster1.Intelligence} \t\tIntelligence of {monster2.Name} is: {monster2.Intelligence}");
            if(monster1.Intelligence >= monster2.Intelligence)
            {
                result = monster1.Intelligence - monster2.Intelligence;
                Console.WriteLine($"Difference between {monster1.Name} Intelligence and {monster2.Name} Intelligence is: {result}");
            }
            else if(monster1.Intelligence < monster2.Intelligence)
            {
                result = monster2.Intelligence - monster1.Intelligence;
                Console.WriteLine($"Difference between {monster2.Name} Intelligence and {monster1.Name} Intelligence is: {result}");
            }
        }
        public void ShowAllEnemiesData()
        {
            foreach (var enemy in Enemies)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n==============================================\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Enemy Name : ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy.Name + "\n");

                foreach (PropertyInfo prop in enemy.GetType().GetProperties())
                {

                    if (prop != null)
                    {
                        var propertyValue = "";
                        if (prop.Name == "Name") { continue; }
                        string propertyName = prop.Name;

                        if (prop.GetValue(enemy) != null)
                        {

                            if (prop.GetValue(enemy).GetType() == typeof(List<EnemyAction>)) { continue; }
                            propertyValue = prop.GetValue(enemy, null).ToString();

                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(propertyName + " : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(propertyValue + "\n");

                    }
                }
            }
        }
    }
}
