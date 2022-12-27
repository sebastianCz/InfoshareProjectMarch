﻿using OstreCWEB.Data.Repository.Characters.CoreClasses;
using OstreCWEB.Data.Repository.Characters.Enums;

namespace OstreCWEB.ViewModel.Fight
{
    public class CharacterActionView
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public CharacterActionType ActionType { get; set; }
        public bool SavingThrowPossible { get; set; }
        public int Max_Dmg { get; set; }
        public int Flat_Dmg { get; set; }
        public int Hit_Dice_Nr { get; set; }
        public string PossibleTargets { get; set; }
        public bool InflictsStatus { get; set; }
        public Status Status { get; set; }
        public Statistics StatForTest { get; set; }
        //Defined for actions reseting with rest.
        public int UsesMaxBeforeRest { get; set; }

        //Defined after game start and saved to DB in GameSession in the form of serialised object. 
        public int UsesLeftBeforeRest { get; set; }
        //Defined for items which have max use before disapearing.
        public int UsesMax { get; set; }
        public bool AggressiveAction { get; set; }
    }
}
