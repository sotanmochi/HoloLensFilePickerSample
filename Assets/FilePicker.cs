using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if !UNITY_EDITOR && UNITY_WSA
using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
#endif

public class FilePicker : MonoBehaviour
{
	void Start ()
	{
#if !UNITY_EDITOR && UNITY_WSA_10_0
		Debug.Log("File Picker start.");

		UnityEngine.WSA.Application.InvokeOnUIThread(async () =>
		{
			var filepicker = new FileOpenPicker();
			filepicker.FileTypeFilter.Add("*");
			var file = await filepicker.PickSingleFileAsync();
			UnityEngine.WSA.Application.InvokeOnAppThread(() => 
			{
				Debug.Log((file != null) ? file.Name : "No data");
			}, false);
		}, false);

		Debug.Log("File Picker end.");
#endif
	}
}
