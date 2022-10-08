using OstreC.Interface;

namespace OstreC.ManageInput
{
    public class LoadGameInput : IuiInput
    {

        
        public PageType Type => PageType.Load_Game;
        public void checkUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            
            



        }

    }
}
