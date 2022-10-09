using OstreC.Services;
using OstreC;
using OstreC.Interface;

namespace OstreC.ManageInput
{
    public class StoryBuliderInput : IuiInput
    {
        public PageType Type => PageType.Story_Bulider;
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
