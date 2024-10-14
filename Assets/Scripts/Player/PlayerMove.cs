using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // Базовая скорость движения персонажа
    public float speedMultiplier = 1f; // Множитель скорости для управления

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Получаем ввод по осям (WASD для движения)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Вектор движения
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Применяем перемещение к Rigidbody с учетом скорости
        rb.MovePosition(transform.position + movement * speed * speedMultiplier * Time.deltaTime);
    }
}
