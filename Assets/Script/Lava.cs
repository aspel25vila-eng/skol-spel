using Unity.VisualScripting;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.GetComponent<PlayerJump>())
            {

                collision.GetComponent<PlayerJump>().Die();
            }
        }



    }


