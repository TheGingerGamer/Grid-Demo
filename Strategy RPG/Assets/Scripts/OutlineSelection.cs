using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{

    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(highlight != null){
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)){
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Tile") && highlight != selection){
                if(highlight.gameObject.GetComponent<Outline>() != null){
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                } else{
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.white;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 3.0f;
                }
            } else{
                highlight = null;
            }
        }

    }
}
