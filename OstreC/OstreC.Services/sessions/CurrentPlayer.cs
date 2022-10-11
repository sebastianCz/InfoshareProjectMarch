using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstreC.Services;
namespace OstreC.Services
{
    public class CurrentPlayer : Player
    {
        int userIdKey = 0; //Allows to link player instance to user. When character is created this INT should be assigned as follows:
        //userIdKey = CurrentPlayer.Id;
        //This way I will be able to link multiple characters to one user. 



    }
}
