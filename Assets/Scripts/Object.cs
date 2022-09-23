using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Object : MonoBehaviour
{
    Rigidbody objectRb;
    public bool taken=false;

    public bool hasReseted;

    [SerializeField] private AudioClip balleffect;
    private AudioSource balleffectSource;
    private void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        balleffectSource = GetComponent<AudioSource>();
 
    }
    private void Update()
    {

        if (taken == true)
        {

            GameObject obj = GameObject.FindGameObjectWithTag("pivot");
            objectRb.MovePosition(obj.transform.position);
            objectRb.MoveRotation(Quaternion.LookRotation(Camera.main.transform.forward));
            objectRb.useGravity = false;

        }
        else
        {
            
            objectRb.useGravity = true;
        }
   
        if(hasReseted == false)
        {
            ResetForce();
            hasReseted = true;       
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        taken = false;
        balleffectSource.PlayOneShot(balleffect);
        if (collision.gameObject.CompareTag("ceilingwall"))
        {
            balleffectSource.Stop();
        }
    }
    public void ResetForce()
    {
        objectRb.isKinematic = true;
        objectRb.isKinematic = false;
    }
    public void Force(float force)
    {
        objectRb.AddForce(Camera.main.transform.forward*force,ForceMode.Impulse);
        objectRb.AddTorque(Vector3.left * force*10);

    }
}
