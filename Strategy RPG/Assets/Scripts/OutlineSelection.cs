using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{

    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private bool playerTurn;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Tile") && playerTurn)
            {
                if(highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                } 
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.white;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 5.0f;
                    
                }
            } 
            else if (highlight.CompareTag("Player"))
            {
                if(highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                } 
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 5.0f;
                }
            } 
            else
            {
                highlight = null;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(highlight)
            {
                if(selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = true;
                }
                selection = raycastHit.transform;
                if(selection.CompareTag("Player"))
                {
                    playerTurn = true;
                    selection.gameObject.GetComponent<Outline>().enabled = true;
                    highlight = null;
                }
                else
                {
                    playerTurn = false;
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
            }
            
        }
    }
}
