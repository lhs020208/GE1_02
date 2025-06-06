using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    PlayerStatusManager Status;
    public float shootForce = 10.0f;

    float verticalInput;
    bool isPressed = false;
    private float shootTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Status = GetComponent<PlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // ShootType==2일 때, 시프트키가 눌려 있으면 매 프레임 shoot()
        if (Status.ShootType == 2 && isPressed && Status.checkufos.cnt > 0)
        {
            // 연사 속도 제한(원하지 않으면 shootTimer 부분 제거)
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                shoot();
            }
        }
        else
        {
            // 버튼을 뗐을 때 쿨타임 초기화 (원치 않으면 생략)
            shootTimer = 0f;
        }
    }

    private void shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
        BulletMove bulletStatus = newBullet.GetComponent<BulletMove>();
        bulletStatus.CloseUFO = Status.CloseUFO;

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (Status.CloseUFO.transform.position - transform.position).normalized;
            rb.AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }

    void OnAttack(InputValue value)
    {
        verticalInput = value.Get<float>();
        isPressed = verticalInput > 0;
        if (Status.ShootType != 2 && isPressed && Status.checkufos.cnt > 0)
            shoot();
    }

}
