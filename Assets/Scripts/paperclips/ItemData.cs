using UnityEngine;
namespace Claire
{
    public static class ItemData
    {
        public static Item CreateItem(int itemID)
        {
            string _name = "";
            string _description = "";
            int _value = 0;
            int _amount = 0;
            string _icon = "";
            string _mesh = "";
            ItemType _type = ItemType.Apparel;
            int _damage = 0;
            int _armour = 0;
            int _heal = 0;
            switch(itemID)
            {
                #region Foood         0 -  99
                case 0:
                    _name = "Apple";
                    _description = "Munchies and crunchies!";
                    _value = 1;
                    _amount = 1;
                    _icon = "Foood/Apple";
                    _mesh = "Foood/Apple";
                    _type = ItemType.Foood;
                    _heal = 10;
                    break;
                case 1:
                    _name = "Meat";
                    _description = "Keep it TAFE...";
                    _value = 1;
                    _amount = 1;
                    _icon = "Foood/Meat";
                    _mesh = "Foood/Meat";
                    _type = ItemType.Foood;
                    _heal = 25;
                    break;
                #endregion
                #region Weapon      100 - 199
                case 100:
                    _name = "Axe";
                    _description = "It'll tell no lies.";
                    _value = 150;
                    _amount = 1;
                    _icon = "Weapon/Axe";
                    _mesh = "Weapon/Axe";
                    _type = ItemType.Weapon;
                    _damage = 50;
                    break;
                case 101:
                    _name = "Sword";
                    _description = "Stick 'em with the pointy end.";
                    _value = 200;
                    _amount = 1;
                    _icon = "Weapon/Sword";
                    _mesh = "Weapon/Sword";
                    _type = ItemType.Weapon;
                    _damage = 40;
                    break;
                case 102:
                    _name = "Bow";
                    _description = "Aren't you polite.";
                    _value = 75;
                    _amount = 1;
                    _icon = "Weapon/Bow";
                    _mesh = "Weapon/Bow";
                    _type = ItemType.Weapon;
                    _damage = 25;
                    break;
                #endregion
                #region Appearal    200 - 299
                case 200:
                    _name = "Pants";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Pants";
                    _mesh = "Apparel/Pants";
                    _type = ItemType.Apparel;
                    break;
                case 201:
                    _name = "Belt";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Belt";
                    _mesh = "Apparel/Belt";
                    _type = ItemType.Apparel;
                    break;
                case 202:
                    _name = "Chest Plate";
                    _description = "";
                    _value = 75;
                    _amount = 1;
                    _icon = "Apparel/Armour/ChestPlate";
                    _mesh = "Apparel/Armour/ChestPlate";
                    _type = ItemType.Apparel;
                    _armour = 45;
                    break;
                case 203:
                    _name = "Boots";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Armour/Boots";
                    _mesh = "Apparel/Armour/Boots";
                    _type = ItemType.Apparel;
                    _armour = 0;
                    break;
                case 204:
                    _name = "Gloves";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Armour/Gloves";
                    _mesh = "Apparel/Armour/Gloves";
                    _type = ItemType.Apparel;
                    _armour = 0;
                    break;
                case 205:
                    _name = "Braces";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Armour/Braces";
                    _mesh = "Apparel/Armour/Braces";
                    _type = ItemType.Apparel;
                    _armour = 0;
                    break;
                case 206:
                    _name = "Pauldrons";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Armour/Pauldrons";
                    _mesh = "Apparel/Armour/Pauldrons";
                    _type = ItemType.Apparel;
                    _armour = 0;
                    break;
                case 207:
                    _name = "Helmet";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Armour/Helmet";
                    _mesh = "Apparel/Armour/Helmet";
                    _type = ItemType.Apparel;
                    _armour = 0;
                    break;
                case 208:
                    _name = "Shield";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Armour/Shield";
                    _mesh = "Apparel/Armour/Shield";
                    _type = ItemType.Apparel;
                    _armour = 0;
                    break;
                case 209:
                    _name = "Cloak";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Cloak";
                    _mesh = "Apparel/Cloak";
                    _type = ItemType.Apparel;
                    break;
                case 210:
                    _name = "Necklace";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Necklace";
                    _mesh = "Apparel/Necklace";
                    _type = ItemType.Apparel;
                    break;
                case 211:
                    _name = "Ring";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Apparel/Ring";
                    _mesh = "Apparel/Ring";
                    _type = ItemType.Apparel;
                    break;
                #endregion
                #region Crafting    300 - 399
                case 300:
                    _name = "Ingot";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Crafting/Ingot";
                    _mesh = "Crafting/Ingot";
                    _type = ItemType.Crafting;
                    break;
                case 301:
                    _name = "Gem";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Crafting/Gem";
                    _mesh = "Crafting/Gem";
                    _type = ItemType.Crafting;
                    break;
                #endregion
                #region Ingredients 400 - 499

                #endregion
                #region Potions     500 - 599
                case 500:
                    _name = "Health Potion";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Potions/HealthPotion";
                    _mesh = "Potions/HealthPotion";
                    _type = ItemType.Potions;
                    _heal = 0;
                    break;
                case 501:
                    _name = "Mana Potion";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Potions/ManaPotion";
                    _mesh = "Potions/ManaPotion";
                    _type = ItemType.Potions;
                    _heal = 0;
                    break;
                #endregion
                #region Scrolls     600 - 699
                case 600:
                    _name = "Scroll";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Scrolls/Scroll";
                    _mesh = "Scrolls/Scroll";
                    _type = ItemType.Scrolls;
                    break;
                case 601:
                    _name = "Book";
                    _description = "";
                    _value = 0;
                    _amount = 1;
                    _icon = "Scrolls/Book";
                    _mesh = "Scrolls/Book";
                    _type = ItemType.Scrolls;
                    break;
                #endregion
                #region Quest       700 - 799

                #endregion
                default:
                    itemID = 0;
                    _name = "Apple";
                    _description = "Munchies and crunchies!";
                    _value = 1;
                    _amount = 1;
                    _icon = "Foood/Apple";
                    _mesh = "Foood/Apple";
                    _type = ItemType.Foood;
                    _heal = 10;
                    break;
            }
            Item temp = new Item
            {
                ID = itemID,
                Name = _name,
                Description = _description,
                Value = _value,
                Amount = _amount,
                Icon = Resources.Load("IconSprite/" + _icon) as Texture2D,
                Mesh = Resources.Load("Mesh/" + _mesh) as GameObject,
                Type = _type,
                Damage = _damage,
                Armour = _armour,
                Heal = _heal
            };
            return temp;
        }
    }
}