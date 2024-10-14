using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // ������� �������� �������� ���������
    public float speedMultiplier = 1f; // ��������� �������� ��� ����������

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �������� ���� �� ���� (WASD ��� ��������)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ������ ��������
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ��������� ����������� � Rigidbody � ������ ��������
        rb.MovePosition(transform.position + movement * speed * speedMultiplier * Time.deltaTime);
    }
}
