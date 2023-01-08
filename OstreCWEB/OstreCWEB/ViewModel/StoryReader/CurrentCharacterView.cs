namespace OstreCWEB.ViewModel.StoryReader
{
    public class CurrentCharacterView
    {
        public string CharacterName { get; set; }
        public int MaxHealthPoints { get; set; }
        public int CurrentHealthPoints { get; set; }
        public int Level { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int Discriminator { get; set; }
        public int CurrentHealthPercentage { get { return CalculateCurrentHealthPercentage(); } }

        public int CalculateCurrentHealthPercentage()
        {
            return (CurrentHealthPoints/MaxHealthPoints)*100;
        }
    }
}
