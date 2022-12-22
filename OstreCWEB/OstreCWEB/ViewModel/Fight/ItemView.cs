﻿using OstreCWEB.Data.Repository.Characters.CoreClasses;
using OstreCWEB.Data.Repository.Items;

namespace OstreCWEB.ViewModel.Fight
{
    public class ItemView
    {
        public ItemType ItemType { get; set; }
        public int ArmorClass { get; set; }
        public string ArmorType { get; set; }
        public int? Id { get; set; }
        public string? Name { get; set; }
        public CharacterActions ActionToTrigger { get; set; }
    }
}
