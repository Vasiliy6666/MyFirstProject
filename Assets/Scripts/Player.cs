using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text scoreText;
    public float movementSpeed;
    public float forceJump;
    public Rigidbody rigidbody;
    public int score;
    public Text healsText;
    public int health;
    public GameObject bulletPrefab;
    public Transform bulletTransform;
    public float attackTime;
    public Text attackText;
    
    private float _attackTimeNow;
    private bool _isJump;

    private void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.transform.position.y < transform.position.y)
        {
            _isJump = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.transform.position.y < transform.position.y)
        {
            _isJump = false;
        }
    }

    private void Start()
    {
        _attackTimeNow = attackTime;
    }

    private void Attack()
    {
        _attackTimeNow -= Time.deltaTime;
        if (_attackTimeNow <= 0)
        {
            attackText.text = "Attack";
        }
        else
        {
            attackText.text = "Attack Time: " + Mathf.Round(_attackTimeNow);
        }

        if (Input.GetMouseButtonDown(1) && _attackTimeNow <= 0)
        {
            GameObject instance = Instantiate(bulletPrefab, bulletTransform.position, transform.rotation);
            instance.GetComponent<Bullet>().creator = this;
            _attackTimeNow = attackTime;
        }
    }

    private void LateUpdate()
    {
        if (health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Update()
    {
       
        scoreText.text = "Score: " + score;
        healsText.text = "heals: " + health;
        Vector3 nextPosition = Vector3.zero;

        float moveHorizontal = Input.GetAxis("Horizontal"); // A D
        nextPosition += transform.right * (movementSpeed * Time.deltaTime * moveHorizontal);

        float moveVeritcal = Input.GetAxis("Vertical");
        nextPosition += transform.forward * (movementSpeed * Time.deltaTime * moveVeritcal);

        rigidbody.velocity = nextPosition;
        

        if (Input.GetKey(KeyCode.Space) && !_isJump)
        {
            rigidbody.AddForce(Vector3.up * forceJump, ForceMode.Acceleration);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 100) && Input.GetMouseButtonDown(0))
        {
            Vector3 lookRotation = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookRotation);
        }
        Attack();
    }
}
