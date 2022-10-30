using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
    //public string OptionsEnemies()
    //{
    //    Console.WriteLine("What action you want to take? \n 1) Show me all list with enemies \n 2) Compare two enemies with each other \n 3) Search in dictionary by key word");
    //    bool input = int.TryParse(Console.ReadLine(), out int result);
    //    if (input)
    //        switch
    //        {
    //            case 1:
    //                Console.WriteLine("This is list of all enemies in a game");



    //        }
    //}

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
                Console.WriteLine($"Health of Monster 1 is: {monster1.HealthPoints} \n Health of Monster 2 is {monster2.HealthPoints}");
            int result = 0;
            if(monster1.HealthPoints >= monster2.HealthPoints)
            {
                result = monster1.HealthPoints - monster2.HealthPoints;
                Console.WriteLine($"Difference between Monster 1 Health Points and Monster 2 Health Points is: {result}");
            }
            else if (monster1.HealthPoints < monster2.HealthPoints)
            {
                result = monster2.HealthPoints - monster1.HealthPoints;
                Console.WriteLine($"Difference between Monster 2 Health Points and Monster 1 Health Points is: {result}");
            }
        }
         

    public string FindEnemiesWithName(string userInput)
        {
            string txt = "";
            //Find enemy with given name in list Enemies on line 13. 
            //Add those enemies names to txt. for example:  txt += newEnemyName \n
            return txt;//Return txt. 
        }
        //public List<int> FindEnemiesWithHp(int userInput albo string userInput,out int userInput)
        //{
        //    List<int> resultList = new List<int>();
        //         //Find enemy with given HP  in list Enemies on line 13. 
                    //add those numbers to list 
        //    return //return list resultList
        //}

    }
}
