using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController : MonoBehaviour
{
    public Image overlay;
    float power = 0;
    bool goingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(power > 1) {
            goingUp = false;
        }
        else if(power < 0) {
            goingUp = true;
        }

        if(goingUp) {
            power += 0.03f;
        }
        else {
            power -= 0.03f;
        }
        SetPowerImage();
    }

    void SetPowerImage() {
        overlay.GetComponent<RectTransform>().anchorMin = new Vector2(0, power);
    }

    public float GetPower() {
        return power;
    }
}
