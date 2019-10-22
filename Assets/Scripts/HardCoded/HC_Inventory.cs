using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linear
{
    public class HC_Inventory : MonoBehaviour
    {

        public GUISkin invSkin;
        public GUIStyle boxStyle;
        #region Variables
        public List<Item> inv = new List<Item>();
        public Item selectedItem;
        public bool showInv;

        public Vector2 scr;
        public Vector2 scrollPos;

        public int money;

        public ItemType sortType;

        public Transform dropLocation;
        [System.Serializable]
        public struct equipment
        {
            public string name;
            public Transform location;
            public GameObject curItem;
        };
        public equipment[] equipmentSlots;
        #endregion

        private void Start()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            inv.Add(ItemData.CreateItem(500));
            inv.Add(ItemData.CreateItem(501));
            inv.Add(ItemData.CreateItem(502));
            inv.Add(ItemData.CreateItem(503));
            inv.Add(ItemData.CreateItem(504));
            inv.Add(ItemData.CreateItem(400));
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                showInv = !showInv;
                if (showInv)
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    return;
                }
                else
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    return;
                }
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                inv.Add(ItemData.CreateItem(Random.Range(500, 505)));
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                inv[2].Amount += 3;
            }
        }
        private void OnGUI()
        {
           
            if (showInv)
            {
                //Make that more efficient by only calling when you need to
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
                GUI.skin = invSkin;
                GUI.Box(new Rect(0, 0, scr.x * 8, Screen.height), "");
        
                if (GUI.Button(new Rect(0f * scr.x, 0, 1.6f * scr.x, 0.75f * scr.y), "All"))
                {
                    sortType = ItemType.All;
                }
                for (int i = 0; i < 9; i++) // creates buttons using for loop instead of having to individually write each
                {
                    ItemType t = (ItemType)i;
                    if (GUI.Button(new Rect(1.5f * scr.x + (i * 1.6f * scr.x), 0, 1.6f * scr.x, 0.75f * scr.y), t.ToString()))
                    {
                        sortType = t;
                    }
                }

                /*if(GUI.Button(new Rect(4f* scr.x,0,scr.x,0.25f*scr.y),"All")) - Creates individual buttons 
                {
                    sortType = "All"; sort type by string 
                }
                if (GUI.Button(new Rect(5f * scr.x, 0, scr.x, 0.25f * scr.y), "Food"))
                {
                    sortType = "Food";
                }
                if (GUI.Button(new Rect(6f * scr.x, 0, scr.x, 0.25f * scr.y), "Armour"))
                {
                    sortType = "Armour";
                }
                if (GUI.Button(new Rect(7f * scr.x, 0, scr.x, 0.25f * scr.y), "Weapon"))
                {
                    sortType = "Weapon";
                }
                if (GUI.Button(new Rect(8f * scr.x, 0, scr.x, 0.25f * scr.y), "Ingredient"))
                {
                    sortType = "Ingredient";
                }
                */
                Display();
                if (selectedItem != null)
                {
                    GUI.skin = invSkin;
                    GUI.Box(new Rect(4.375f * scr.x, 1f * scr.y, 3 * scr.x, .75f * scr.y), selectedItem.Name, boxStyle);
                    GUI.Box(new Rect(4.375f * scr.x, 1.75f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Icon, boxStyle);
                    GUI.Box(new Rect(4.375f * scr.x, 4.9f * scr.y, 3 * scr.x, 1 * scr.y), selectedItem.Description, boxStyle);
                    ItemUse();
                }
                else
                {
                    { return; }
                }
            }
        }
        void Display()
        {
            if (!(sortType == ItemType.All))
            {
               // ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType); - converts enum to string for sorttype
                int a = 0; // amount of that type
                int s = 0; // slot pos
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == sortType) // finding type
                    {
                        a++;
                    }
                }
                if (a <= 11)
                {
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (inv[i].Type == sortType)
                        {
                            if (GUI.Button(new Rect(.4f * scr.x, 1f * scr.y + s * (.75f * scr.y), 3 * scr.x, .75f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                            }
                            s++;
                        }
                    }
                }
                else
                {
                    scrollPos = GUI.BeginScrollView(new Rect(0f, 1f * scr.y, 4f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 11) * (0.25f * scr.y))), false, true);
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (inv[i].Type == sortType)
                        {
                            if (GUI.Button(new Rect(.4f * scr.x, .25f * scr.y + s * (.75f * scr.y), 3 * scr.x, .75f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                            }
                            s++;
                        }
                    }
                    GUI.EndScrollView();
                }
            }
            else
            {
                GUI.skin = invSkin;
                if (inv.Count <= 11)
                {
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (GUI.Button(new Rect(0.4f * scr.x, 1f * scr.y + i * (.75f * scr.y), 3 * scr.x, .75f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                    }
                }
                else
                {
                    scrollPos = GUI.BeginScrollView(new Rect(0.4f, 1f * scr.y, 4f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 11) * (0.25f * scr.y))), false, true);
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (GUI.Button(new Rect(.4f * scr.x, .25f * scr.y + i * (.75f * scr.y), 3 * scr.x, .75f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                    }
                    GUI.EndScrollView();
                }
            }
        }
        void ItemUse()
        {
            switch (selectedItem.Type)
            {
                case ItemType.Ingredient:
                    break;
                case ItemType.Food:
                    break;
                case ItemType.Potion:
                    break;
                case ItemType.Scroll:
                    break;
                case ItemType.Armour:
                    if (equipmentSlots[1].curItem == null || selectedItem.Name != equipmentSlots[1].curItem.name)
                    {
                        if (GUI.Button(new Rect(6f * scr.x, 8f * scr.y, 1.5f * scr.x, .75f * scr.y), "Equip"))
                        {
                            if (equipmentSlots[1].curItem != null)
                            {
                                Destroy(equipmentSlots[1].curItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.ItemMesh, equipmentSlots[1].location);
                            equipmentSlots[1].curItem = curItem;
                            curItem.name = selectedItem.Name;
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(6f * scr.x, 8f * scr.y, 1.5f * scr.x, .75f * scr.y), "Unequip"))
                        {
                            Destroy(equipmentSlots[1].curItem);
                        }
                    }
                    break;
                case ItemType.Weapon:
                    if (equipmentSlots[0].curItem == null || selectedItem.Name != equipmentSlots[0].curItem.name)
                    {
                        if (GUI.Button(new Rect(6f * scr.x, 8f * scr.y, 1.5f * scr.x, .75f * scr.y), "Equip"))
                        {
                            if (equipmentSlots[0].curItem != null)
                            {
                                Destroy(equipmentSlots[1].curItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.ItemMesh, equipmentSlots[0].location);
                            equipmentSlots[0].curItem = curItem;
                            curItem.name = selectedItem.Name;
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(6f * scr.x, 8f * scr.y, 1.5f * scr.x, .75f * scr.y), "Unequip"))
                        {
                            Destroy(equipmentSlots[0].curItem);
                        }
                    }

                    break;
                case ItemType.Quest:
                    break;
                case ItemType.Misc:
                    break;
                case ItemType.Money:
                    break;
                default:
                    break;
            }
            if (GUI.Button(new Rect(4.375f * scr.x, 6f * scr.y, 3 * scr.x, .75f * scr.y), "Discard"))
            {

                for (int i = 0; i < equipmentSlots.Length; i++)
                {
                    if (equipmentSlots[i].curItem != null && selectedItem.Name == equipmentSlots[i].curItem.name)
                    {
                        Destroy(equipmentSlots[i].curItem);
                    }
                }
                GameObject droppedItem = Instantiate(selectedItem.ItemMesh, dropLocation.position, Quaternion.identity);
                droppedItem.name = selectedItem.Name;
                droppedItem.AddComponent<Rigidbody>().useGravity = true;
                if (selectedItem.Amount > 1)
                {
                    selectedItem.Amount--;
                }
                else
                {
                    inv.Remove(selectedItem);
                    selectedItem = null;
                    return;
                }
            }
        }
    }
}







