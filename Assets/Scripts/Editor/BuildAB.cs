using UnityEngine;
using System.Collections;
using UnityEditor;

public class BuildAB : MonoBehaviour {

	[MenuItem ("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles ()
	{
		BuildPipeline.BuildAssetBundles ("Assets/ExportedAssets/AssetBundles");
	}
}
