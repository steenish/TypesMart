using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {

    private Queue<Item> items;

    public static readonly int maxNumItems = 1;
    public static readonly int minNumItems = 5;

    private void Awake() {
        items = new Queue<Item>();

        int numItems = Random.Range(minNumItems, maxNumItems + 1);

        for (int i = 0; i < numItems; ++i) {
            string itemName = StaticData.itemNames[Random.Range(0, StaticData.itemNames.Length)];

            GameObject itemGameObject = Instantiate(DynamicData.instance.itemPrefab, transform);
            itemGameObject.name = string.Format("item{0}", i);
            Item item = (Item) itemGameObject.AddComponent(typeof(Item));
            item.itemName = itemName;
            items.Enqueue(item);
        }
    }

    public Item NextItem() {
        try {
            return items.Dequeue();
        } catch {
            return null;
        }
    }

    public bool NoMoreItems() {
        return items.Count == 0;
    }
}
