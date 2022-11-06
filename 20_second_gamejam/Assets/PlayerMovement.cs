using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 7f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontalInput;
        float verticalInput;

        horizontalInput = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        verticalInput = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        transform.Translate(horizontalInput, verticalInput,0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
        if(other.gameObject.name == "lvl_end")
        {
            Destroy(other.gameObject);
        }
    }
}
