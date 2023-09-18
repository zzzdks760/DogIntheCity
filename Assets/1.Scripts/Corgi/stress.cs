using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stress : MonoBehaviour
{
    public Slider StressSlider;
    Animator _animator;
    public float Stress;
    float maxStress = 100f;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StressSlider.value = Stress;
        if(Stress >= 100f)
        {
            Stress = 100f;
        }
        else if(Stress <= 0f)
        {
            Stress = 0f;
        }
    }
}
