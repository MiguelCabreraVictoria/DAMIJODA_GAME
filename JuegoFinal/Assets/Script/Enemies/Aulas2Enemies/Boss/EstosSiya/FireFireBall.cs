using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFireBall : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 10;

    [SerializeField] private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    public Terminiti terminiti;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 3f);        
    }

    private void Fire()
    {
        if (terminiti.vida <= 0) {
            CancelInvoke();
            return;
        }
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = FireBallPool.bulletPoolInstance.GetBullet(); 
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<FireBall>().SetMoveDirection(bulDir);
            
            angle += angleStep;
        }
    }
}
