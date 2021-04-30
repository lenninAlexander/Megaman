using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    float balas_disparadas = 0;
    float balas_necesarias = 5;
    float balas_necesarias1 = 3;
    float balas_necesarias2 = 1;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Plataforma")
        {
            speed *= -1;
            this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bala1")
        {
            balas_disparadas += 1;
            Destroy(collision.gameObject);//Destruye la bala.
            if (balas_necesarias == balas_disparadas)//Si han tocado al jugador el número de balas necesarias.
            {

                Destroy(this.gameObject);//Destruye este objeto.
                
            }
        }
        if (collision.gameObject.tag == "bala2")
        {
            balas_disparadas += 1;
            Destroy(collision.gameObject);//Destruye la bala.
            if (balas_necesarias1 == balas_disparadas)//Si han tocado al jugador el número de balas necesarias.
            {

                Destroy(this.gameObject);//Destruye este objeto.
            }
        }
        if (collision.gameObject.tag == "bala3")
        {
            balas_disparadas += 1;
            Destroy(collision.gameObject);
            if (balas_necesarias2 == balas_disparadas)//Si han tocado al jugador el número de balas necesarias.
            {
                
                Destroy(this.gameObject);//Destruye este objeto.
            }
        }
    }




}
