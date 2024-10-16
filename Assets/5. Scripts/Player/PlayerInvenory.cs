using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInvenory : MonoBehaviour
{
    [SerializeField] GameObject weaponActive;
    [SerializeField] List<GameObject> weapons = new List<GameObject>();
    private int currentWeaponIndex = 0; // Индекс текущего активного оружия

    void Start()
    {
        // Убеждаемся, что первое оружие активно при старте
        SelectWeapon(currentWeaponIndex);
    }

    void Update()
    {
        // Получаем значение скролла колеса мыши
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            // Переключение на следующее оружие
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            SelectWeapon(currentWeaponIndex);
        }
        else if (scrollInput < 0f)
        {
            // Переключение на предыдущее оружие
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Count - 1; // Циклическое переключение
            }
            SelectWeapon(currentWeaponIndex);
        }
    }

    void SelectWeapon(int index)
    {
        // Проходим по всем объектам в листе и активируем только выбранное оружие
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }
}
