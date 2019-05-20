﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingWorld : MonoBehaviour {

	//Esta es la forma correcta de mostrar variables privadas en el inspector. 
	//No se deben hacer public variables que no queremos sean accesibles desde otras clases-


	// En cuanto se active el objeto, se inciará el cambio de escena
	void Start () {
		//Iniciamos una corrutina, que es un método que se ejecuta 
		//en una línea de tiempo diferente al flujo principal del programa
		StartCoroutine(LoadScene());
	}

	//Corrutina
	IEnumerator LoadScene()
	{
		AsyncOperation loading;

		//Iniciamos la carga asíncrona de la escena y guardamos el proceso en 'loading'
		loading = SceneManager.LoadSceneAsync("World 1-1", LoadSceneMode.Single);

		//Bloqueamos el salto automático entre escenas para asegurarnos el control durante el proceso
		loading.allowSceneActivation = false;

		//Cuando la escena llega al 90% de carga, se produce el cambio de escena
		while (loading.progress < 0.9f) {

			//Esperamos un frame
			yield return null;
		}

		//Mostramos la carga como finalizada
		

		//Activamos el salto de escena.
		loading.allowSceneActivation = true;


	}

}
