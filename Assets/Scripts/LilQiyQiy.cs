using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilQiyQiy : MonoBehaviour
{
    //Qiy bullet positions
    public Transform LQQBP1;
    public Transform LQQBP2;
    public Transform LQQBP3;
    public Transform LQQBP4;
    public Transform LQQBP5;

    public GameObject QiyBulletPrefab;

    public float QiyBulletSpeed;

    public float QiyReloadTime;
    private float QiyReloadTimeSaver;
    private Vector3 LQQP = new Vector3(0, 2, 0);

    public float QiySpeed;

    public float QiyHealth;


    
    // Start is called before the first frame update
    void Start()
    {
        QiyReloadTimeSaver = QiyReloadTime;

    }

    // Update is called once per frame
    void Update()
    {

        //move 
        if (transform.position.x > 5){

            QiySpeed = -QiySpeed;
        } else if (transform.position.x < -5)
        {
            QiySpeed = -QiySpeed;
        }

        transform.position = transform.position + (transform.right * QiySpeed * Time.deltaTime);

        QiyReloadTime -= Time.deltaTime;
        Vector3 difference1 = LQQBP1.position - (LQQBP1.position + LQQP);
        Vector3 difference2 = LQQBP2.position - (LQQBP2.position + LQQP);
        Vector3 difference3 = LQQBP3.position - (LQQBP3.position + LQQP);
        Vector3 difference4 = LQQBP4.position - (LQQBP4.position + LQQP);
        Vector3 difference5 = LQQBP5.position - (LQQBP5.position + LQQP);
        
        difference1.Normalize();
        difference2.Normalize();
        difference3.Normalize();
        difference4.Normalize();
        difference5.Normalize();

        if (QiyReloadTime < 0)
        {
            fireBullet(difference1, LQQBP1.position);
            fireBullet(difference2, LQQBP2.position);
            fireBullet(difference3, LQQBP3.position);
            fireBullet(difference4, LQQBP4.position);
            fireBullet(difference5, LQQBP5.position);
            QiyReloadTime = QiyReloadTimeSaver;
        }

        if (QiyHealth < 0){
            Destroy(gameObject);
        }
        

    }

    void fireBullet(Vector2 direction, Vector3 position)
    {
        GameObject b = Instantiate(QiyBulletPrefab) as GameObject;
        b.transform.position = position;
        b.GetComponent<Rigidbody2D>().velocity = direction * QiyBulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D col){
        QiyHealth -= 1;
    }

}
