﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Interface
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
