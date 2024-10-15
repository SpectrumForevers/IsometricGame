using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInvenory : MonoBehaviour
{
    [SerializeField] GameObject weaponActive;
    [SerializeField] List<GameObject> weapons = new List<GameObject>();
    private int currentWeaponIndex = 0; // ������ �������� ��������� ������

    void Start()
    {
        // ����������, ��� ������ ������ ������� ��� ������
        SelectWeapon(currentWeaponIndex);
    }

    void Update()
    {
        // �������� �������� ������� ������ ����
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            // ������������ �� ��������� ������
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            SelectWeapon(currentWeaponIndex);
        }
        else if (scrollInput < 0f)
        {
            // ������������ �� ���������� ������
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Count - 1; // ����������� ������������
            }
            SelectWeapon(currentWeaponIndex);
        }
    }

    void SelectWeapon(int index)
    {
        // �������� �� ���� �������� � ����� � ���������� ������ ��������� ������
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }
}
