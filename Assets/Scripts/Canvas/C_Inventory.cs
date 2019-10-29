using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class C_Inventory : MonoBehaviour
{

    #region Variables
    public List<Item> inv = new List<Item>();
    public Item selectedItem;




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
    public GameObject invPanel;
    public GameObject invButton;
    public ScrollRect view;
    public RectTransform content;

    public int objName;
    public int description;

    public RawImage icon;
    public Text objNameText;
    public Text descriptionText;

    public void Start()
    {
        content.sizeDelta = new Vector2(0, 25);
        Time.timeScale = 1;

        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(502));
        inv.Add(ItemData.CreateItem(503));
        inv.Add(ItemData.CreateItem(504));
        inv.Add(ItemData.CreateItem(400));
        for (int i = 0; i < inv.Count; i++)
        {
            GameObject clone = Instantiate(invButton, content);
            clone.name = inv[i].Name;
            clone.GetComponentInChildren<Text>().text = inv[i].Name;

        }
    }
    public void Update()
    {
        content.sizeDelta = new Vector2(0, 25 * inv.Count);
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(Random.Range(500, 505)));
            GameObject clone = Instantiate(invButton, content);
            clone.name = inv[inv.Count - 1].Name;
            clone.GetComponentInChildren<Text>().text = inv[inv.Count - 1].Name;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            inv[2].Amount += 3;
        }
    }
    public void WeaponButton()
    {
        sortType = ItemType.Weapon;
    }
    #region nope
    /* public void AllButton()
     {
         sortType = ItemType.All;
     }

     public void IngredientButton()
     {
         sortType = ItemType.Ingredient;
     }
     public void FoodButton()
     {
         sortType = ItemType.Food;
     }
     public void PotionButton()
     {
         sortType = ItemType.Potion;
     }
     public void ScrollButton()
     {
         sortType = ItemType.Scroll;
     }
     public void ArmourButton()
     {
         sortType = ItemType.Armour;
     }
     public void WeaponButton()
     {
         sortType = ItemType.Weapon;
     }
     public void QuestButton()
     {
         sortType = ItemType.Quest;
     }*/
    #endregion

    public void ShowInvButton()
     {
         invPanel.SetActive(true);
         Time.timeScale = 0;


     }
     public void CloseInv()
     {
         invPanel.SetActive(false);
         Time.timeScale = 1;

     }
}
