using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontalInput;
    float verticalInput;
    [SerializeField] float speed;
    float xRot = 0;
    public Transform body;
    public int score;

    void Start()
    {
        body.Rotate(Vector3.up * 0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager PauseMenu = GameObject.Find("GameManager").GetComponent<GameManager>();
            PauseMenu.Pause();
        }
        
    }



    void PlayerControl()
    {
        float rotX = Input.GetAxisRaw("Mouse X") * 1000 * Time.deltaTime;

        float rotY = Input.GetAxisRaw("Mouse Y") * 1000 * Time.deltaTime;
        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -80, 80);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        body.Rotate(Vector3.up * rotX);


        if (body.transform.position.x < 11f)
        {
            body.transform.position = new Vector3(11.1f, transform.position.y, transform.position.z);

        }

        if (body.transform.position.x > 47f)
        {
            body.transform.position = new Vector3(46.9f, transform.position.y, transform.position.z);

        }

        if (transform.position.z < -22f)
        {
            body.transform.position = new Vector3(transform.position.x, transform.position.y, -21.9f);
        }
        if (transform.position.z > 25f)
        {
            body.transform.position = new Vector3(transform.position.x, transform.position.y, 24.9f);
        }

        verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        body.Translate(horizontalInput, 0, verticalInput);
    }
    private void OnTriggerEnter(Collider other)//distances are triggered by the collider and the calculation is sent to the global.
    { 
        if(other.name=="Plane"+ other.name.Substring(5))
        {
            score = int.Parse(other.name.Substring(5));
        }

    }
}
