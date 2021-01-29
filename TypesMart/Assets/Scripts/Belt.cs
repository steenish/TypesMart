using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour {

	public float beltSpeed;
	public float newCustomerInterval;
	public Transform customerContainer;
	public Transform itemContainer;
	public Transform itemSpawnPoint;

	public Item currentItem { get { return spawnedItems.Peek(); } }

	private Customer currentCustomer { get { return customerQueue.Peek(); } }

	private Queue<Customer> customerQueue;
	private Queue<Item> spawnedItems;

	public static Belt instance;

	private bool moving = true;
	private bool spawning = true;

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this);
		}

		customerQueue = new Queue<Customer>();
		AddCustomer();

		spawnedItems = new Queue<Item>();

		InvokeRepeating("AddCustomer", newCustomerInterval, newCustomerInterval);
	}

	public void CheckOutItem() {
		try {
			Item lastItem = spawnedItems.Dequeue();
			Destroy(lastItem);
		} catch (Exception e) {
			Debug.Log(e.StackTrace);
		}

		if (currentCustomer.NoMoreItems()) {
			try {
				Customer lastCustomer = customerQueue.Dequeue();
				Destroy(lastCustomer.gameObject);
			} catch {
				Debug.Log("customer queue empty");
			}
		}
	}

	public void StopSpawning() {
		spawning = false;
	}

	public void StartSpawning() {
		spawning = true;
	}

	public void StopMoving() {
		moving = false;
	}

	public void StartMoving() {
		moving = true;
	}

	private void Update() {
		if (moving) {
			MoveItems();
		}

		if (spawning) {
			SpawnItem();
		}
	}

	private void AddCustomer() {
		customerQueue.Enqueue(CreateCustomer());
	}

	private Customer CreateCustomer() {
		GameObject customerGameObject = new GameObject("customer");
		customerGameObject.transform.parent = customerContainer;
		customerGameObject.transform.position = customerContainer.position;
		Customer customer = (Customer) customerGameObject.AddComponent(typeof(Customer));
		return customer;
	}

	private void MoveItems() {
		foreach (Item item in spawnedItems) {
			if (item != null) {
				item.transform.position += Vector3.down * beltSpeed * Time.deltaTime;
			}
		}
	}

	private void SpawnItem() {
		Item spawnedItem = currentCustomer.NextItem();
		if (spawnedItem != null) {
			spawnedItems.Enqueue(spawnedItem);
			spawnedItem.gameObject.transform.parent = itemContainer;
			spawnedItem.gameObject.transform.position = itemSpawnPoint.position;
		}
	}
}
