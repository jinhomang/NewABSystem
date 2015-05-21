using UnityEngine;
using System.Collections;

public class LoadAB : MonoBehaviour {

	public string bundlePath;

	private AssetBundle downloadedAB;
	private Object 		loadedObject;

	void Start() {

		Caching.CleanCache();
	
		StartCoroutine("LoadMyAB", "myzombie1");
		StartCoroutine("LoadMyAB", "myzombie2");
		StartCoroutine("LoadMyAB", "myzombie3");

	}

	IEnumerator LoadMyAB(string bundleName)
	{
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
		
		Object obj = downloadedAB.LoadAsset(bundleName);
		GameObject inst = GameObject.Instantiate(obj) as GameObject;
		if (inst == null)
		{
			return false;
		}
		inst.transform.parent = gameObject.transform.parent;
		inst.transform.position = Vector3.zero;
		//downloadedAB.mainAsset;

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