namespace OstreC.Services
{
    //Used to generate a charcter. Will be inherited by " CurrentPlayer "class
    public class Player:Character
    {
        int UserIdKey = 0; //Will Allow to link player instance to user. That admits we want to have multiple characters per user. 
                           //This way we will be able to link multiple characters to one user. 

        public int Hit_Dice_Nr { get; set; }// Amount of dices used to attack.
        public int Hit_Dmg { get; set; } // dmg per hit dice.
        public int Flat_damage { get; set; } // dmg added to hit dice result regardless of roll.
                                             // public List PlayerItems = new List(); //player inventory  LIST with ITEMS
        public bool isAlive { get; set; }
        public List<Items> Inventory { get; set; }//List of items in inventory.
        public List<Items> Equipped { get; set; }//List of equiped items

        List<Character> PlayerList = new List<Character>();

        public List<int> AttributePoints = new List<int>();

        public bool IsPlayerCreated = false;
        string Name;
        string Race;
        string CharClass;
        public void CreateDefaultPlayer()
        {
            base.Name = "Jaheira";
            base.Race = "Human";
            base.CharClass = "Warrior";            
            Level = 1;

            Strength = 18;
            Dexterity = 17;
            Constitution = 18;
            Intelligence = 10;
            Wisdom = 14;
            Charisma = 16;

            HealthPoints = CalculateHealthPoints();

            ModStrength = 4;
            ModDexterity = 3;
            ModConstitution = 4;
            ModIntelligence = 0;
            ModWisdom = 2;
            ModCharisma = 3;

            IsPlayerCreated = true;
        }
        public void AddName()
        {
            Name = Utilities.InputDataAsString(Utilities.rgxAZ);
        }
        public void AddRace()
        {
            Race = Console.ReadLine();
        }
        public void AddClass()
        {
            CharClass = Console.ReadLine();
        }
        public void AddValueToProperty()
        {
            base.Name = Name;
            base.Race = Race;
            base.CharClass = CharClass;
            Level = 1;

            Strength = Strength;
            Dexterity = Dexterity;
            Constitution = Constitution;
            Intelligence = Intelligence;
            Wisdom = Wisdom;
            Charisma = Charisma;

            HealthPoints = CalculateHealthPoints();

            ModStrength = CalculateModifier(Strength);
            ModDexterity = CalculateModifier(Dexterity);
            ModConstitution = CalculateModifier(Constitution);
            ModIntelligence = CalculateModifier(Intelligence);
            ModWisdom = CalculateModifier(Wisdom);
            ModCharisma = CalculateModifier(Charisma);

            IsPlayerCreated = true;
        }
        public void AddPropertiesToList()
        {
            PlayerList.Add(new Character
            {
                Name = Name,
                Race = Race,
                CharClass = CharClass,
                Strength = Strength,
                Dexterity = Dexterity,
                Constitution = Constitution,
                Intelligence = Intelligence,
                Wisdom = Wisdom,
                Charisma = Charisma,
                ModStrength = CalculateModifier(Strength),
                ModDexterity = CalculateModifier(Dexterity),
                ModConstitution = CalculateModifier(Constitution),
                ModIntelligence = CalculateModifier(Intelligence),
                ModWisdom = CalculateModifier(Wisdom),
                ModCharisma = CalculateModifier(Charisma)
            });
            IsPlayerCreated = true;
        }

        // do skończenia, trzeba obsłużyć wpisywanie wartości różnych od wartości na liście.
        public int AddAttributePoints(Attributes attribute)
        {
            //DisplayStatistics();
            int minValue = AttributePoints.Min();
            //if (minValue == -1)
            //{
            //    classCounter++;
            //    minValue = AttributePoints[classCounter];
            //}
            int maxValue = AttributePoints.Max();
            //int minValue = 1;
            //int maxValue = 6;
            int input = Utilities.InputDataAsInt(minValue, maxValue);
            switch (attribute)
            {
                case Attributes.Strength:
                    ChangeValueFromList(AttributePoints, input);
                    return Strength = input;
                case Attributes.Dexterity:
                    ChangeValueFromList(AttributePoints, input);
                    return Dexterity = input;
                case Attributes.Constitution:
                    ChangeValueFromList(AttributePoints, input);
                    return Constitution = input;
                case Attributes.Intelligence:
                    ChangeValueFromList(AttributePoints, input);
                    return Intelligence = input;
                case Attributes.Wisdom:
                    ChangeValueFromList(AttributePoints, input);
                    return Wisdom = input;
                case Attributes.Charisma:
                    ChangeValueFromList(AttributePoints, input);
                    return Charisma = input;
                default:
                    return -1;
            }
        }
        public void RemoveValueFromList(List<int> list, int input)
        {
            list.Remove(input);
        }
        public void ChangeValueFromList(List<int> list, int input, bool isID = false)
        {
            if (isID)
            {
                if (list.Contains(input))
                {
                    list.RemoveAt(input - 1);
                    list.Insert(input - 1, 0);
                }
            }
            else
            {
                if (list.Contains(input))
                {
                    list.Insert(list.IndexOf(input), 0);
                    list.Remove(input);
                }                
            }
        }
        public void DeletePlayer()
        {
            PlayerList.Clear();
            IsPlayerCreated = false;

            Strength = 0;
            Dexterity = 0;
            Constitution = 0;
            Intelligence = 0;
            Wisdom = 0;
            Charisma = 0;

            ModStrength = 0;
            ModDexterity = 0;
            ModConstitution = 0;
            ModIntelligence = 0;
            ModWisdom = 0;
            ModCharisma = 0;
        }
        public void GenerateAttributePoints()
        {
            if (!(AttributePoints.Count() == 0))
            {
                AttributePoints.Clear();
            }

            for (int i = 0; i < 6; i++)
            {
                List<int> valueRollDiceTemp = new List<int>();
                valueRollDiceTemp.Add(Utilities.DiceRoll(7));
                valueRollDiceTemp.Add(Utilities.DiceRoll(7));
                valueRollDiceTemp.Add(Utilities.DiceRoll(7));
                valueRollDiceTemp.Add(Utilities.DiceRoll(7));

                int lowestValues = valueRollDiceTemp.Min();
                int index = valueRollDiceTemp.IndexOf(lowestValues);
                valueRollDiceTemp.RemoveAt(index);
                int sum = 0;

                foreach (var item in valueRollDiceTemp)
                {
                    sum += item;
                }
                AttributePoints.Add(sum);
            }
        }
        public void DisplayStatistics(params string[] List)
        {
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
        }
        //public void DisplayStatistics()
        //{
        //    PropertyInfo[] myAttributesInfo;
        //    // Get the properties of 'Type' class object.
        //    myAttributesInfo = player.GetType().GetProperties();
        //    Console.WriteLine("Properties of System.Type are:");
        //    for (int i = 0; i < myAttributesInfo.Length; i++)
        //    {
        //        Console.WriteLine(myAttributesInfo[i].Name.ToString());
        //        attrList.Add(myAttributesInfo[i].Name.ToString());
        //    }
        //}
        ///Nie tykać, wybuchnie!!!
        //private void LoadDefaultData()
        //{
        //    try
        //    {
        //        foreach (var tuple in PlayerList.Zip(PlayerList, (x, y) => (x, y)))
        //        {
        //            tuple.x = tuple.y;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
    }
}
