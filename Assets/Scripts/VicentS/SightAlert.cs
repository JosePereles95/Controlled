using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightAlert : MonoBehaviour {

    public Sprite alertSprite;
    public Sprite lostSprite;

    private SpriteRenderer theRenderer;

    private void Start()
    {
        theRenderer = GetComponent<SpriteRenderer>();
        this.gameObject.SetActive(false);
    }

    public void ActivateAlert()
    {
        theRenderer.sprite = alertSprite;
        this.gameObject.SetActive(true);

        StartCoroutine("DeactivateAlarm");
    }

    public void ActivaLost()
    {
        theRenderer.sprite = alertSprite;
        this.gameObject.SetActive(true);

        StartCoroutine("DeactivateAlarm");
    }

    private IEnumerator DeactivateAlert()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }


}
