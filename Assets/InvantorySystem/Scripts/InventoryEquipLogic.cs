using UnityEngine;

public enum EquipType
{
	Standard,
	Custom
}

[System.Serializable]
public class InventoryEquipLogic
{
	public EquipType equipType;

	public void EquipItem (InvantoryObject obj, Transform hand)
	{
		Debug.Log ("Equipping inventory object " + obj);
		GameObject newObj = GameObject.Instantiate (obj.objectPrefab, Vector3.zero, hand.rotation, hand) as GameObject;
		newObj.gameObject.transform.localPosition = Vector3.zero;
		CollectableObject collectable = obj.objectPrefab.GetComponent<CollectableObject> ();
		hand.localRotation = Quaternion.Euler(collectable.offsetXRot, collectable.offsetYRot, collectable.offsetZRot);

		// disable rigidbody
		Rigidbody rb = newObj.GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.isKinematic = true;
		rb.detectCollisions = false;

		newObj.gameObject.GetComponent<Light> ().enabled = false;
		if (equipType == EquipType.Custom) {
			newObj.GetComponent<RuntimeEquipLogic> ().Equip (newObj);
		}
	}
}