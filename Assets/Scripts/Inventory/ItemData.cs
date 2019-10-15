using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        ItemType _type = ItemType.Food;
        int _amount = 0;
        int _value = 0;

        int _heal = 0;
        int _damage = 0;
        int _armour = 0;

        string _name = "";
        string _description = "";

        string _icon = "";
        string _mesh = "";
        switch (itemID)
        {
            #region Ingreient 0 - 99
            case 0:
                _name = "Acorn";
                _value = 3;
                _description = "It's an acorn";
                _icon = "Ingredients/Acorn_Icon";
                _mesh = "Ingredients/Acorn_Mesh";
                _type = ItemType.Ingredient;
                _amount = 1;
                break;
            case 1:
                _name = "Egg";
                _value = 5;
                _description = "An egg";
                _icon = "Ingredients/Egg_Icon";
                _mesh = "Ingredients/Egg_Mesh";
                _type = ItemType.Ingredient;
                _amount = 1;
                break;
            case 2:
                _name = "Mushroom";
                _value = 5;
                _description = "Wild Mushroom";
                _icon = "Ingredients/Mushroom_Icon";
                _mesh = "Ingredients/Mushroom_Mesh";
                _type = ItemType.Ingredient;
                _amount = 1;
                break;
            #endregion
            #region Food 100 - 199
            case 100:
                _name = "Meat";
                _value = 15;
                _description = "Mystery Meat";
                _icon = "Food/Meat_Icon";
                _mesh = "Food/Meat_Mesh";
                _type = ItemType.Food;
                _heal = 17;
                _amount = 1;
                break;
            case 101:
                _name = "Chicken";
                _value = 10;
                _description = "It's a bird";
                _icon = "Food/Chicken_Icon";
                _mesh = "Food/Chicken_Mesh";
                _type = ItemType.Food;
                _heal = 10;
                _amount = 1;
                break;
            case 102:
                _name = "Bread";
                _value = 5;
                _description = "Fresh Bread";
                _icon = "Food/Bread_Icon";
                _mesh = "Food/Bread_Mesh";
                _type = ItemType.Food;
                _heal = 2;
                _amount = 1;
                break;
            case 3:
                _name = "Apple";
                _value = 5;
                _description = "An apple";
                _icon = "Food/Apple_Icon";
                _mesh = "Food/Apple_Mesh";
                _type = ItemType.Food;
                _heal = 2;
                _amount = 1;
                break;
            #endregion
            #region Potion 200 - 299
            case 200:
                _name = "Small Health Potion";
                _value = 20;
                _description = "A small health potion";
                _icon = "Potions/S_Health_Icon";
                _mesh = "Potions/S_Health_Mesh";
                _type = ItemType.Potion;
                _heal = 20;
                _amount = 1;
                break;
            case 201:
                _name = "Medium Health Potion";
                _value = 30;
                _description = "A medium health potion";
                _icon = "Potions/M_Health_Icon";
                _mesh = "Potions/M_Health_Mesh";
                _type = ItemType.Potion;
                _heal = 50;
                _amount = 1;
                break;
            case 202:
                _name = "Large Health Potion";
                _value = 50;
                _description = "A large health potion";
                _icon = "Potions/L_Health_Icon";
                _mesh = "Potions/L_Health_Mesh";
                _type = ItemType.Potion;
                _heal = 100;
                _amount = 1;
                break;
            #endregion
            #region Scroll 300 - 399
            case 300:
                _name = "History Scroll";
                _value = 5;
                _description = "A scroll about history";
                _icon = "Scrolls/Scroll_1_Icon";
                _mesh = "Scrolls/Scroll_1_Mesh";
                _type = ItemType.Scroll;
                _amount = 1;
                break;
            case 301:
                _name = "Cooking Scroll";
                _value = 5;
                _description = "A Scroll about cooking";
                _icon = "Scrolls/Scroll_0_Icon";
                _mesh = "Scrolls/Scroll_0_Mesh";
                _type = ItemType.Scroll;
                _amount = 1;
                break;
            case 302:
                _name = "Magic Scroll";
                _value = 20;
                _description = "A scroll about magic";
                _icon = "Scrolls/Scroll_2_Icon";
                _mesh = "Scrolls/Scroll_2_Mesh";
                _type = ItemType.Scroll;
                _amount = 1;
                break;

            #endregion
            #region Armour 400 - 499
            case 400:
                _name = "Hat";
                _value = 20;
                _description = "A hat";
                _icon = "Armour/Hat_Icon";
                _mesh = "Armour/Hat_Mesh";
                _type = ItemType.Armour;
                _armour = 5;
                _amount = 1;
                break;
            case 401:
                _name = "Cloak";
                _value = 20;
                _description = "A cloak";
                _icon = "Armour/Cloak_Icon";
                _mesh = "Armour/Cloak_Mesh";
                _type = ItemType.Armour;
                _armour = 5;
                _amount = 1;
                break;
            case 402:
                _name = "Chest Piece";
                _value = 20;
                _description = "A chest piece";
                _icon = "Armour/ChestPiece_Icon";
                _mesh = "Armour/ChestPiece_Mesh";
                _type = ItemType.Armour;
                _armour = 5;
                _amount = 1;
                break;
            case 203:
                _name = "Boots";
                _value = 20;
                _description = "A pair of boots";
                _icon = "Armour/Boots_Icon";
                _mesh = "Armour/Boots_Mesh";
                _type = ItemType.Armour;
                _armour = 5;
                _amount = 1;
                break;
            #endregion
            #region Weapon 500 - 599
            case 500:
                _name = "Short Sword";
                _value = 50;
                _description = "A shortsword";
                _icon = "Weapon/ShortSword_Icon";
                _mesh = "Weapon/ShortSword_Mesh";
                _type = ItemType.Weapon;
                _damage = 30;
                _amount = 1;
                break;
            case 501:
                _name = "Long Sword";
                _value = 75;
                _description = "A long sword";
                _icon = "Weapon/LongSword_Icon";
                _mesh = "Weapon/LongSword_Mesh";
                _type = ItemType.Weapon;
                _damage = 50;
                _amount = 1;
                break;
            case 502:
                _name = "Axe";
                _value = 30;
                _description = "An axe";
                _icon = "Weapon/Axe_Icon";
                _mesh = "Weapon/Axe_Mesh";
                _type = ItemType.Weapon;
                _damage = 15;
                _amount = 1;
                break;
            case 503:
                _name = "Ice Staff";
                _value = 150;
                _description = "An Ice Staff";
                _icon = "Weapon/IceStaff_Icon";
                _mesh = "Weapon/IceStaff_Mesh";
                _type = ItemType.Weapon;
                _damage = 15;
                _amount = 1;
                break;
            case 504:
                _name = "Magic Sword";
                _value = 300;
                _description = "A Magic Staff";
                _icon = "Weapon/MagicSword_Icon";
                _mesh = "Weapon/MagicSword_Mesh";
                _type = ItemType.Weapon;
                _damage = 15;
                _amount = 1;
                break;
            #endregion
            #region Quest 600 - 699
            case 600:
                _name = "Ring";
                _value = 20;
                _description = "Stolen Ring";
                _icon = "Quest/Ring_Icon";
                _mesh = "Quest/Ring_Mesh";
                _type = ItemType.Quest;
                _amount = 1;
                break;
            case 601:
                _name = "Diamond";
                _value = 20;
                _description = "Diamond";
                _icon = "Quest/Diamond_Icon";
                _mesh = "Quest/Diamond_Mesh";
                _type = ItemType.Quest;
                _amount = 1;
                break;
            case 602:
                _name = "Golden Cup";
                _value = 20;
                _description = "A Golden Cup";
                _icon = "Quest/Cup_Icon";
                _mesh = "Quest/Cup_Mesh";
                _type = ItemType.Quest;
                _amount = 1;
                break;
            #endregion
            #region Misc 700 - 799
            case 700:
                _name = "Bag";
                _value = 20;
                _description = "leather bag";
                _icon = "Misc/Bag_Icon";
                _mesh = "Misc/Bag_Mesh";
                _type = ItemType.Misc;
                _amount = 1;
                break;
            case 701:
                _name = "Lamp";
                _value = 20;
                _description = "lamp";
                _icon = "Misc/Lamp_Icon";
                _mesh = "Misc/Lamp_Mesh";
                _type = ItemType.Misc;
                _amount = 1;
                break;
            case 702:
                _name = "Crate";
                _value = 20;
                _description = "Wooden Crate";
                _icon = "Misc/Crate_Icon";
                _mesh = "Misc/Crate_Mesh";
                _type = ItemType.Misc;
                _amount = 1;
                break;
            #endregion
            #region Money 800 - 899
            case 800:
                _name = "Bronze Pieces";
                _value = 10;
                _description = " Bronze Pieces";
                _icon = "Money/Bronze_Icon";
                _mesh = "Money/Bronze_Mesh";
                _type = ItemType.Money;
                _amount = 1;
                break;
            case 801:
                _name = "Silver Pieces";
                _value = 25;
                _description = "Silver Pieces";
                _icon = "Money/Silver_Icon";
                _mesh = "Money/Silver_Mesh";
                _type = ItemType.Money;
                _amount = 1;
                break;
            case 802:
                _name = "Gold Pieces";
                _value = 50;
                _description = "Gold Pieces";
                _icon = "Money/Gold_Icon";
                _mesh = "Money/Gold_Mesh";
                _type = ItemType.Money;
                _amount = 1;
                break;
            #endregion
            default:
                itemID = 0;
                _name = "Acorn";
                _value = 3;
                _description = "It's an acorn";
                _icon = "Ingredients/Acorn_Icon";
                _mesh = "Ingredients/Acorn_Mesh";
                _type = ItemType.Ingredient;
                _amount = 1;
                break;


        }

        Item temp = new Item
        {
            Type = _type,
            Amount = _amount,
            Value = _value,

            Heal = _heal,
            Damage = _damage,
            Armour = _armour,

            Name = _name,
            Description = _description,

            Icon = Resources.Load("Icons/" + _icon) as Texture2D,
            ItemMesh = Resources.Load("Mesh/" + _mesh) as GameObject

        };
        return temp;
    }
}
