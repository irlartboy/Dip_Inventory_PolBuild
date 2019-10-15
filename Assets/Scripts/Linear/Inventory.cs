using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linear
{
    public class Inventory : MonoBehaviour
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

        public string sortType = "";

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

                GUI.Box(new Rect(0, 0, scr.x * 8, Screen.height), "", boxStyle);
                Display();
                if (selectedItem != null)
                {
                    GUI.skin = invSkin;
                    GUI.Box(new Rect(4.375f * scr.x, 0.2f * scr.y, 3 * scr.x, 0.5f * scr.y), selectedItem.Name);


                    GUI.Box(new Rect(4.375f * scr.x, 0.7f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Icon);

                    GUI.Box(new Rect(4.375f * scr.x, 3.7f * scr.y, 3 * scr.x, 1 * scr.y), selectedItem.Description);
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
            GUI.skin = invSkin;
            if (inv.Count <= 11)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(.4f * scr.x, .25f * scr.y + i * (.75f * scr.y), 3 * scr.x, .75f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0, 0.4f * scr.y, 4f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 11) * (0.25f * scr.y))), false, true);
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
                    break;
                case ItemType.Weapon:
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
            if (GUI.Button(new Rect(4.375f * scr.x, 7.75f * scr.y, 3 * scr.x, .75f * scr.y), "Discard"))
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
                if (selectedItem.Amount >1)
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







