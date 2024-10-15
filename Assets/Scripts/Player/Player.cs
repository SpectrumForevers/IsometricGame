using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerInvenory playerInvenory;
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerMove playerMove;

    [SerializeField] float playerHP;
    [SerializeField] float playerArmor;


    private void Start()
    {
        GameManager.Instance.SetPlayer(gameObject);
    }

    public void SetDamage(float damage)
    {

        if (playerArmor > 0)
        {
            float bufarmor = playerArmor;
            playerArmor -= damage;
            damage -= bufarmor;
        }
        if (playerArmor <= 0)
        {
            playerHP -= damage;
        }
    }
}
