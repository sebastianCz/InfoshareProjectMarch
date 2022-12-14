using OstreCWEB.Data.Enums;

namespace OstreCWEB.Data.Repository.Items
{
    public abstract class Item
    {
        public Item() { }
        public Item(int id, string name, ItemType itemType)
        {
            Id = id;
            Name = name;
            ItemType = itemType;
        }

        public int? Id { get; set; }
        public string? Name { get; set; }
        public ItemType? ItemType { get;set; } 
    }
}
