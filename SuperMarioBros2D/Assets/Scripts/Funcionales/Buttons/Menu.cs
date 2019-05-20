﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	void Start () {
		//Iniciamos una corrutina
		StartCoroutine(LoadScene());
	}

	//Corrutina
	IEnumerator LoadScene()
	{
		AsyncOperation loading;

		//Iniciamos la carga asíncrona de la escena y guardamos el proceso en 'loading'
		loading = SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);

		//Bloqueamos el salto automático entre escenas para asegurarnos el control durante el proceso
		loading.allowSceneActivation = false;

		//Cuando la escena llega al 90% de carga, se produce el cambio de escena
		while (loading.progress < 0.9f) {

			//Esperamos un frame
			yield return null;
		}
		//Activamos el salto de escena.
		loading.allowSceneActivation = true;


	}

}

