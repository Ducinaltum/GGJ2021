using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    private static UIController _ui;
    [SerializeField]
    TextMeshProUGUI textContent;
    [SerializeField]
    RectTransform textBubble;
    [SerializeField]
    Image fade;
    [SerializeField]
    float translationDur = 1;
    [SerializeField]
    Vector2 onScreenPos;
    [SerializeField]
    Vector2 outScreenPos;
    float elapsedTime = 0;
    bool isOnScreen = false;
    public static UIController InstanceUI {
		get {
			return _ui;
		}
	}

	private void Awake()
	{
		if(_ui == null) {
			_ui = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			//Nunca debería entrar acá
			Destroy(this);
		}
	}
    void Start()
    {
        Debug.Log(textBubble.position);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetSimpleText(string text){
        elapsedTime = 0;
        textContent.text = text;
        StartCoroutine(EnterText(onScreenPos));
    }
    public void DismissText(){
        elapsedTime = 0;
        StartCoroutine(QuitText(outScreenPos));
    }
    private IEnumerator EnterText(Vector3 target){
        while (elapsedTime < translationDur)
        {
            textBubble.anchoredPosition  = Vector2.Lerp(outScreenPos, onScreenPos, (elapsedTime/translationDur));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isOnScreen = true;
        yield return null;    
    }

    private IEnumerator QuitText(Vector3 target){
        while (elapsedTime < translationDur)
        {
            textBubble.anchoredPosition = Vector2.Lerp(onScreenPos, outScreenPos, (elapsedTime / translationDur));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isOnScreen = false;
        yield return null;    
    }

    public void FadeWhite(EFade f){
        Debug.Log(f);
        elapsedTime = 0;
        Color from, to;
        if(f == EFade.In){

            from = Color.white;
            to = Color.clear;
        }
        else{
            fade.gameObject.SetActive(true);
            from = Color.clear;
            to = Color.white;
        }
        StartCoroutine(Fade(fade, from, to));
    }

    private IEnumerator Fade(Image target, Color from, Color to){
        while (elapsedTime < translationDur)
        {
            target.color = Color.Lerp(from, to, (elapsedTime / translationDur));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if(to == Color.clear) fade.gameObject.SetActive(false);
        yield return null;
    }
}

public enum EFade{
    In,
    Out
}
