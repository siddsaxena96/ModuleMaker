using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour {

    public Rigidbody2D endPointRb;
    public int value;
    public bool isActive=false;
    private LineRenderer lineRenderer;
    private bool touched = false;
    private GameObject prevNode;
    private int operation;

	// Use this for initialization
	void Start (){
        lineRenderer = GetComponent<LineRenderer> ();       
        lineRenderer.SetPosition (1, new Vector3 (transform.position.x,transform.position.y, 0.5f));
        lineRenderer.SetPosition (0, transform.position);              
        operation = 1;
	}
	
    void OnMouseDrag(){        
        if (isActive) {
            lineRenderer.SetPosition (1, Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.5f)));
            endPointRb.position = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
        }
    }
        
    void OnTriggerEnter2D(Collider2D col){        
        if (col.transform.parent.name != transform.name) {
            Debug.Log ("Connect");
            isActive = true;
            prevNode = col.transform.parent.gameObject;
            if (prevNode.GetComponent<StarBehaviour> ().value + operation == value) {
                Debug.Log ("Correct");
                Color corr = Color.green;
                lineRenderer.startColor = corr;
                lineRenderer.endColor = corr;              
                lineRenderer.material.color = corr;
                Debug.Log (lineRenderer.material.color);
            } else {
                Debug.Log ("Wrong");
            }                           
        }     
    }

    void OnTriggerExit2D(Collider2D col){                 
        if (col.transform.parent.name != transform.name) {            
            Debug.Log (prevNode);
            Debug.Log ("Disconnect");
        }
    }

}
