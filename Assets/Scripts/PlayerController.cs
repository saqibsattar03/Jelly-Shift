using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 temp;
    private Rigidbody playerRb;
    [SerializeField] float playerSpeed;
    [SerializeField] float gravityModifier;
    private AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerSpeed = 500.0f;
        Physics.gravity *= gravityModifier;
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerSizeChange();
        
    }

    void PlayerMovement()
    { 
        playerRb.AddForce(Vector3.forward * playerSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    void PlayerSizeChange() 
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.localScale.y <= 3.0f && transform.localScale.x >= 0)
        {

           temp = transform.localScale;
            temp.y += 0.1f;
            temp.x -= 0.1f;
            transform.localScale = temp;
        }

        if (Input.GetKey(KeyCode.DownArrow) && transform.localScale.x <= 3.0f && transform.localScale.y >= 0) 
        {
            temp = transform.localScale;
            temp.x += 0.1f;
            temp.y -= 0.1f;
            transform.localScale = temp;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("audioCube")) 
        {
            Debug.Log("working");
            audioPlayer.Play();
        }
	}

}
