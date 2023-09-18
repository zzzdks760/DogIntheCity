using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Opbutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public RectTransform Button;

    // Start is called before the first frame update
    void Start()
    {
        Button.GetComponent<Animator>().Play("opbutton on");    
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("opbutton off");
    }
     
        public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("opbutton on");
    }
}
