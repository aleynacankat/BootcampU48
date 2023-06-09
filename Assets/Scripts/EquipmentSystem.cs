
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject weaponSheath;

    private GameObject currentWeaponInHand;
    private GameObject currentWeaponInSheath;

    private void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
    }

    public void DrawWeapon()
    {
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        Destroy(currentWeaponInSheath);
    }

    public void SheatWeapon()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        Destroy(currentWeaponInHand);
    }
}
