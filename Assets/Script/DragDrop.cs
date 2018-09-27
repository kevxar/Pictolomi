using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    // touch offset allows ball not to shake when it starts moving
    float deltaX, deltaY;



    // Representa componente rigidbody(pictograma)
    Rigidbody2D rb;

    // El movimiento estara permitido siempre y cuando se toque el rigidbody(pictograma) primero
    bool moveAllowed = false;

    GameObject frame;
    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        

    }

    void Update()
    {

        // Se identifica un touch event
        if (Input.touchCount > 0)
        {

            //se obtiene el evento touch para interactuar
            Touch touch = Input.GetTouch(0);

            //posicion touch
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            // fases del touch
            switch (touch.phase)
            {

                // se detecta touch en la pantalla
                case TouchPhase.Began:

                    // if you touch the ball
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {

                        // get the offset between position you touhes
                        // and the center of the game object
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;

                        // if touch begins within the ball collider
                        // then it is allowed to move
                        moveAllowed = true;

                       
                        GetComponent<CircleCollider2D>().sharedMaterial = null;
                    }
                    break;

                // you move your finger
                case TouchPhase.Moved:
                    // if you thouches the ball and movement is allowed then move
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                        rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;

                // you release your finger
                case TouchPhase.Ended:

                    // restore initial parameters
                    // when thouch is ended
                    moveAllowed = false;
                    PhysicsMaterial2D mat = new PhysicsMaterial2D();

                    verifyFrame(touchPos);

                    break;
            }
        }
    }

    void verifyFrame(Vector2 touchpos)
    {
        frame = GameObject.Find("frame1");
        Vector2 framePos = frame.transform.position;
        Debug.Log(framePos);
        
        
    }
}