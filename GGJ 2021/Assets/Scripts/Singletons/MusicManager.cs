using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

//Agregarle un audioSource a la camara y asignarle es clip "dead"
//Ponerle volume 0.2 al audioSource del prefab Laser
//Poner 6 de valor desde el inspector a los clips de "Music Manager"

//EXTRAS
//se le le puede poner 0 al z del collider de la bomba? creo que se ve mejor
//Lo mismo con los torus, si se puede invertir el orden de los aros desde le parent queda mejor que frene de adentro para afuera
//Esos dos últimos puntos son sugerencias, no me quitan el sueño

//Eliminarle un script perdido que tiene la cámara

public enum Ambient{
	intro,
	noActionSync,
	actionOutSync,
	actionSync,
	flow,
	lowHealth,
}

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {
    
    public float bpm = 103.0F;
    public int numBeatsPerSegment = 51*4;

    [Header("In game music")]
    public AudioClip[] inGameMusicClips = new AudioClip[5];

    private double nextEventTime;
    public int flip = 0;
    
    private AudioSource[] musicClipsAuso_A = new AudioSource[5];
    private AudioSource[] musicClipsAuso_B = new AudioSource[5];
    private bool running = false;

    public AudioMixerGroup mixerGroup;

	public int health = 5;

	int track;

    public void StartMusic() {

		track = (int)Ambient.intro;
        int i = 0;
        while (i < 5) {
            GameObject child_A = new GameObject("MusicPlayer");
            child_A.transform.parent = gameObject.transform;
            musicClipsAuso_A[i] = child_A.AddComponent<AudioSource>();
            GameObject child_B = new GameObject("MusicPlayer");
            child_B.transform.parent = gameObject.transform;
            musicClipsAuso_B[i] = child_B.AddComponent<AudioSource>();
            musicClipsAuso_A[i].clip = inGameMusicClips[i];
            musicClipsAuso_B[i].clip = inGameMusicClips[i];
            i++;
        }
        nextEventTime = AudioSettings.dspTime + 2.0F;
        running = true;
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            //Cuando termina el nivel CAMBIAR LA CONDICION
            if (true == false)
            {
                /*
                Destruir todo cuando termina el juego
                foreach (AudioSource source in musicClipsAuso_A)
                {
                    Destroy(source);
                }
                                foreach (AudioSource source in musicClipsAuso_B)
                {
                    Destroy(source);
                }
                Camera.main.GetComponent<AudioSource>().Play();
                */
            }

            if (!running)
                return;

            double time = AudioSettings.dspTime;
            if (time + 1.0F > nextEventTime)
            {
                AudioSource[] ausos = flip == 0? musicClipsAuso_A: musicClipsAuso_B;
                foreach(AudioSource auso in ausos){
                    auso.PlayScheduled(nextEventTime);
                }
                nextEventTime += 60.0F / bpm * numBeatsPerSegment;
                flip = 1 - flip;
            }
        }
    }
}
