using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HelpButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform Button;

    // Start is called before the first frame update
    void Start()
    {
        Button.GetComponent<Animator>().Play("helpbutton off");    
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("helpbutton on");
    }
     
        public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("helpbutton off");
    }
}
