using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private static GameController _instanceGC;
    public static GameController InstanceGC {
		get {
			return _instanceGC;
		}
	}

	private void Awake()
	{
		if(_instanceGC == null) {
			_instanceGC = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			//Nunca debería entrar acá
			Destroy(this);
		}
	}
    public void UnloadCaveScene(){
        UIController.InstanceUI.FadeWhite(EFade.Out);
        StartCoroutine(WaitForFadeIn(1f));        
    }

    private IEnumerator WaitForFadeIn(float time){
        yield return new WaitForSeconds(time);
        SceneManager.UnloadSceneAsync("Cave");

		SceneManager.LoadSceneAsync("Center", LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("Heiser", LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("NorEste", LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("Norte", LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("SurEste", LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("SurOeste", LoadSceneMode.Additive);
        UIController.InstanceUI.FadeWhite(EFade.In);
    }

	public void StartGame(){
				AudioController.InstanceAC.music.StartMusic();
		SceneManager.LoadSceneAsync("Cave", LoadSceneMode.Additive);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
