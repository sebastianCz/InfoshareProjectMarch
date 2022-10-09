using OstreC.Interface;

namespace OstreC.ManageInput
{
    public class ParagraphInput : IuiInput
    {
        public PageType Type => PageType.Paragraph;
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
