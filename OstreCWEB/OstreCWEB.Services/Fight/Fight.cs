namespace OstreCWEB.Services.Fight
{
    public class Fight
    {
        //        ProvidePossibleTargets(id ChosenAction)

        //foreach var action in Character.Actions

        //if(action.Id== ChosenAction)

        //return string[] PossibleTargets


        //Statuses most likely have to be applied in the form of " IFs" in fight script. 
        //Each character has a list of statutes applied to him. 
        //The database (or static list ) should have a list of all possible statutes applicable to characters.
        //Each spell or item used will have to search through the status list in DB and add a new status to character.Statuses 
        //If it wants to apply one. 

        //This should allow to " add" new statutes easily by just adding one to DB. Same for spells and anything else really. 

        //Alternatively each "action" can search for a specific " status" and apply it by itself. It's a bit complicated since
        //We're talking about establishing relationships between instances that don't exist yet. 
    }
}