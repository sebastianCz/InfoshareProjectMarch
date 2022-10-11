using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
    public class ProgramSession
    {
        public CurrentUser currentUser = new CurrentUser(1, "Admin", "AdminPass", false);//Instancied on init so UI can call it's methods                                                                                   //If set to true program exits on next loop completion.
        public bool exit { get; set; } = false;
    }
}
