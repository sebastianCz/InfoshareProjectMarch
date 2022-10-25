using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
    
    public  class GameDictionary
    {
        public List<Enemy> Enemies = new List<Enemy>();

        public GameDictionary()
        {
           LoadEnemies();

        }

       public  void LoadEnemies()
        {
            Enemies = JsonFile.DeserializeFile<List<Enemy>>("Enemy");
         
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
