using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Components")] 
    public Text scoreText;
    public GameObject bulletPrefab;
    public Transform bulletTransform;
    public Text healsText;
    public Text attackText;
    public Transform groundCheck;
    
    [Header("Parametrs")] 
    public float rotationSpeed;
    public float movementSpeed;
    public float jumpHeight;
    public int score;
    public int health;
    public float attackTime;
    public float groundDistance;
    public LayerMask groundMask;

    private float _attackTimeNow;
    private SurfaceSlider _surfaceSlider;
    private bool _isGround;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _surfaceSlider = GetComponent<SurfaceSlider>();
        _rigidbody = GetComponent<Rigidbody>();
        _attackTimeNow = attackTime;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
        healsText.text = "Healths: " + health;
        
        Rotation();
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.zero;
        
        nextPosition += transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        
        _isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (nextPosition != Vector3.zero)
        {
            var offset = _surfaceSlider.Project(nextPosition * (movementSpeed * Time.deltaTime));
            _rigidbody.position += offset;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody.AddForce(new Vector3(0, 5 * jumpHeight, 0), ForceMode.Impulse);
        }
    }

    private void Rotation()
    {
        // var offsetMousePosition = Screen.width / 2 - Input.mousePosition.x;
        // if (offsetMousePosition < Screen.width / 5)
        // {
        //     return;
        // }
        // transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 
        //     transform.rotation.z - offsetMousePosition / Screen.width * 0.05f * rotationSpeed);
    }
    
    private void LateUpdate()
    {
        if (health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
            attackText.text = "Time to attack: " + Mathf.Round(_attackTimeNow);
        }

        if (Input.GetMouseButtonDown(1) && _attackTimeNow <= 0)
        {
            GameObject instance = Instantiate(bulletPrefab, bulletTransform.position, transform.rotation);
            instance.GetComponent<Bullet>().creator = this;
            _attackTimeNow = attackTime;
        }
    }
}
