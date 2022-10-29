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
        

       public string LoadEnemies()
        {
            Enemies = JsonFile.DeserializeFile<List<Enemy>>("Enemy");
            string message = "\n";
            foreach (var item in Enemies)
            {
                message += item.Name + "\n";
            }
            return message;
         
        }
        public List<Enemy> Enemies { get; set; }

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
