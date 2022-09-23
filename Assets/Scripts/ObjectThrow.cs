using UnityEngine;
using UnityEngine.UI;

public class ObjectThrow : MonoBehaviour
{
   [SerializeField] private float distance = 5f;
    public  bool isTaked;
    public Image cross;
    public Transform pivot;
    GameObject item;
    float forceModeValue = 0;
    [SerializeField] private int Force=10;
    private void Update()
    {

        if (isTaked == true)
        {   
            Object objComp=item.GetComponent<Object>();
            Text ForceText = GameObject.FindGameObjectWithTag("box").GetComponent<Counter>().Force;
            GameManager gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
            if (objComp.taken == false)
            {
                isTaked = false;
            }
            
            
            if (Input.GetKey(KeyCode.Mouse0))
            {


                forceModeValue += Force* 1 * Time.deltaTime;
               
                forceModeValue= Mathf.Clamp(forceModeValue, 0, 40);
                ForceText.text = "Force: " +(int)forceModeValue * 5;
                gameManager.ForceSlider(forceModeValue / 40);

            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                objComp.Force(forceModeValue); 
                isTaked = false;
                objComp.taken = false;
                forceModeValue = 0;
                ForceText.text = "Force: " + forceModeValue;
                gameManager.ForceSlider(forceModeValue);
            }
            cross.color = Color.white;  
        }
        if(isTaked == false)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if(Physics.Raycast(ray, out hit, distance)&&hit.collider.gameObject.tag=="takeAble")
            {
                cross.color = Color.red;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    item = hit.collider.gameObject;
                    item.GetComponent<Object>().hasReseted = false;
                    item.GetComponent<Object>().taken = true;
                    isTaked = true;
                }
            }
            else
            {
                cross.color = Color.white;
            }
        }
    }

   

}
