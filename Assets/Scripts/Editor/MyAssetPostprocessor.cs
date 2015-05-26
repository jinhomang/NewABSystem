using UnityEngine;
using UnityEditor;

public class MyAllPostprocessor : AssetPostprocessor {
	
	public void OnPostprocessAssetbundleNameChanged( string assetPath, string previousAssetBundleName, string newAssetBundleName)
	{
		Debug.Log("Asset " + assetPath + " has been moved from assetBundle " + previousAssetBundleName + " to assetBundle " + newAssetBundleName + ".");
	}
}