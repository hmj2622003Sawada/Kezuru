using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class kezurikasuController : MonoBehaviour
{
	[SerializeField] GameObject startPos;
	[SerializeField] GameObject endPos;
	[SerializeField] GameObject Pos;
	float increaseAmount;
	Vector3 position;
	Vector3 ePos;
	Vector3 sPos;
	Vector3 Positioning;
	Vector3 nowdiff;
	float diff;
	Vector3 velocity;
	float a;
	public void SetVelocity(Vector3 v) { velocity = v; }
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// 最初の角度と位置を取得
		transform.localScale = new Vector3(0f, 0.0001f, 0.058f);
		position = new Vector3(-0.015f, -0.085f, 0.015f);

		// 端までの距離の計算
		ePos = endPos.transform.position;       // 端の位置
		Positioning = Pos.transform.position;  // 最初の鉋の位置
		diff = ePos.x - Positioning.x; // 端までの距離
		increaseAmount = diff / 1000; // 動くたびに伸びる長さ(距離の長さの0.1%)

		// スタート地点の取得
		sPos = startPos.transform.position;

		a = (Positioning.x - sPos.x) / (ePos.x - sPos.x);
	}

	void Update()
	{
		//float ratio = (Positioning.x - sPos.x) /(ePos.x - sPos.x);
		// クリックしたときのスケール取得
		Vector3 currentScale = transform.localScale;

		// 動いた距離を出す
		Vector3 pos = transform.parent.position; // 木屑の生成位置の座標
		Positioning = Pos.transform.position;  // 現在の生成位置の位置
		nowdiff = Positioning - sPos; // スタート地点と生成位置の位置の差
		float b = (Positioning.x - sPos.x) / (ePos.x - sPos.x);
	//	Debug.Log(Positioning);
	//	Debug.Log(b - a);
		//float x = nowdiff.x / diff; // 
		//int times = (int)x;  // 伸ばす回数

		//// Xのスケールを大きくしたVector3の作成
		//Vector3 newScale = new(currentScale.x + increaseAmount, currentScale.y, currentScale.z);

		//// オブジェクトに適応
		//transform.localScale = newScale;
		//Vector3 diffPos = (newScale - currentScale) / 2;
		//Quaternion rotation = Quaternion.Euler(0, 0, -63f);

		//transform.position -= rotation * diffPos;
		////transform.position = position;

	}
}
