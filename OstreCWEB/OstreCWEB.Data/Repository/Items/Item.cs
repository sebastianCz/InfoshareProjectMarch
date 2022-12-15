using OstreCWEB.Data.Enums;

namespace OstreCWEB.Data.Repository.Items
{
     public abstract class Item
    {
        int Id { get; set; }
        string Name { get; set; }
        ItemType ItemType { get;set; } 
    }
}
