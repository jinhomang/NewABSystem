using UnityEngine;
using System.Collections;

public class LoadAB : MonoBehaviour {

	public string bundlePath;

	private AssetBundle downloadedAB;
	public GameObject 	loadedModel_;
	public Object 		loadedObject;

	void Start() {

		Caching.CleanCache();
	
		StartCoroutine("LoadZombies");
	}


	IEnumerator LoadZombieModel()
	{
		string bundleName = "zombie_model";
		string assetName = "zombie";
		string url = string.Format("file://{0}/{1}/{2}", Application.dataPath, bundlePath, bundleName);
		
		WWW www = WWW.LoadFromCacheOrDownload(url, 0);
		yield return www;
		
		if(!string.IsNullOrEmpty(www.error))
		{
			Debug.LogError(www.error);
			return false;
		}

		downloadedAB = www.assetBundle;
		if (downloadedAB == null)
		{
			Debug.LogError("can't load assetbundle");
			return false;
		}

		loadedModel_ = downloadedAB.LoadAsset (assetName) as GameObject;
		Debug.Log ("Model| instanceID: " + loadedModel_.GetInstanceID ());
		Debug.Log ("Model| Animator instanceID: " + loadedModel_.GetComponent<Animator> ().GetInstanceID ());
		Debug.Log ("Model| Avatar instanceID: " + loadedModel_.GetComponent<Animator> ().avatar.GetInstanceID ());
		Debug.Log ("---------------------------------------------------");

		//downloadedAB.LoadAsset (assetName);
	}


	IEnumerator LoadZombies()
	{
		yield return StartCoroutine ("LoadZombieModel");

		yield return StartCoroutine("LoadZombie", 0);
		yield return StartCoroutine("LoadZombie", 1);

	}

	IEnumerator LoadZombie(int index)
	{
		string bundleName = string.Format("myzombie{0}", index);
		string assetName = string.Format("myzombie{0}", index);
		string url = string.Format("file://{0}/{1}/{2}", Application.dataPath, bundlePath, bundleName);
		
		WWW www = WWW.LoadFromCacheOrDownload(url, 0);
		yield return www;
		
		if(!string.IsNullOrEmpty(www.error))
		{
			Debug.LogError(www.error);
			return false;
		}
		
		downloadedAB = www.assetBundle;
		if (downloadedAB == null)
		{
			Debug.LogError("can't load assetbundle");
			return false;
		}
		
		/*
		Object[] objs = downloadedAB.LoadAllAssets();
		foreach(Object o in objs)
		{
			Debug.Log(string.Format("object name: {0}", o.name));
		}
		*/
		
		Object obj = downloadedAB.LoadAsset(assetName);
		GameObject inst = Instantiate(obj) as GameObject;
		if (inst == null)
		{
			return false;
		}
		Debug.Log ("Prefab| instanceID: " + inst.GetInstanceID ());
		Debug.Log ("Prefab| Animator instanceID: " + inst.GetComponent<Animator> ().GetInstanceID ());
		Debug.Log ("Prefab| Avatar instanceID: " + inst.GetComponent<Animator> ().avatar.GetInstanceID ());
		Debug.Log ("---------------------------------------------------");
		//inst.transform.parent = gameObject.transform.parent;
		inst.transform.position = Vector3.zero;
		//downloadedAB.Unload (false);
	}
}

/*
using UnityEngine;
using System.Collections;

public class LoadFromCacheOrDownloadExample : MonoBehaviour
{
	IEnumerator Start ()
	{
		var www = WWW.LoadFromCacheOrDownload("http://myserver.com/myassetBundle.unity3d", 5);
		yield return www;
		if(!string.IsNullOrEmpty(www.error))
		{
			Debug.Log(www.error);
			return;
		}
		var myLoadedAssetBundle = www.assetBundle;
		
		var asset = myAssetBundle.mainAsset;
	}
}*/