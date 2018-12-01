// using UnityEngine;
// using System.Collections;

// public class Enemy : MonoBehaviour
// {
//     private float speed = 3f;
//     private bool isCoroutineUp = false;
//     private float magnitude = 0.3f;
//     private float frequency = 10f;
//     private float leftBoundary;
//     private float rightBoundary;
//     private float yOffset;
//     private Vector3 pos, localScale;
//     private bool facingRight;

//     private void Start()
//     {
//         leftBoundary = Mathf.Max(-6f, this.transform.position.x - 3f);
//         rightBoundary = Mathf.Min(6f, this.transform.position.x + 3f);
//         yOffset = this.transform.position.y;
//         pos = this.transform.position;
//         localScale = transform.localScale;
//     }
//     private void Update()
//     {
//         checkWhereToFace();
//         float newX;
//         if (facingRight)
//         {
//             newX = Time.deltaTime * speed;
//         }
//         else
//         {
//             newX = -Time.deltaTime * speed;
//         }

//         Vector3 movement = new Vector3(newX, Mathf.Sin(Time.deltaTime * frequency) * magnitude, 0.0f);

//         pos = this.transform.position;

//         this.transform.position += movement;

//     }

//     void checkWhereToFace()
//     {
//         if (pos.x < leftBoundary)
//         {
//             facingRight = true;
//         }


//         else if (pos.x >= rightBoundary)
//         {
//             facingRight = false;
//         }


//         if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
//             localScale.x *= -1;

//         transform.localScale = localScale;

//     }

//     // protected override void OnCanMove<T>(T component)
//     // {
//     //     throw new System.NotImplementedException();
//     // }
// }