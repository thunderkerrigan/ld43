using UnityEngine;
using System.Collections;

public class MovableEnemy : MonoBehaviour
{
    private float speed = 3f;
    private bool isCoroutineUp = false;
    private float magnitude = 0.3f;
    private float frequency = 10f;
    private float leftBoundary;
    private float rightBoundary;
    private float yOffset;
    private Vector3 pos, localScale;
    private bool facingRight;

    private void Start()
    {
        leftBoundary = Mathf.Max(-6f, this.transform.position.x - 3f);
        rightBoundary = Mathf.Min(6f, this.transform.position.x + 3f);
        yOffset = this.transform.position.y;
        pos = this.transform.position;
        localScale = transform.localScale;
    }
    private void Update()
    {
        checkWhereToFace();
        float newX;
        if (facingRight)
        {
            newX = Time.deltaTime * speed;
        }
        else
        {
            newX = -Time.deltaTime * speed;
        }

        Vector3 movement = new Vector3(newX, Mathf.Sin(Time.time * frequency) * magnitude, 0.0f);

        pos = this.transform.position;
        GameObject player = GameObject.FindWithTag("Player");
        // this.transform.LookAt(player.transform.position);
        // this.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        // if (Vector3.Distance(pos, player.transform.position) > 2.5f)
        // {//move if distance from target is greater than 1
        float distance =  Vector3.Distance(pos, player.transform.position);
        if (!isCoroutineUp)
        {
            StartCoroutine(reachPLayer(player.transform.position, distance));
        }
        // }
    }

    private IEnumerator reachPLayer(Vector3 position, float kinetic){
        isCoroutineUp = true;
        while (kinetic > 0)
        {
            Vector3 movement = Vector3.MoveTowards(this.transform.position, position, kinetic * speed * Time.deltaTime);
        //  this.transform.Translate(new Vector3(kinetic * speed * Time.deltaTime, 0, 0));
        this.transform.position = movement;
         kinetic -= .01f;
        //  kinetic = Mathf.Max(3.0f, kinetic - 5.0f);
        yield return null;
        }
    }

    void checkWhereToFace()
    {
        if (pos.x < leftBoundary)
        {
            facingRight = true;
        }


        else if (pos.x >= rightBoundary)
        {
            facingRight = false;
        }


        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }
}