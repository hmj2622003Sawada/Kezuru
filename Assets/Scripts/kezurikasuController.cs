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
	Vector3 Positioning;
	float diff;
	Vector3 velocity;
	public void SetVelocity(Vector3 v) {  velocity = v; }
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		// 最初の角度と位置を取得
		transform.localScale = new Vector3(0f, 0.0001f, 0.058f);
		position = new Vector3(-0.015f,-0.085f,0.015f);

		// 端までの距離の計算
		ePos = endPos.transform.localPosition;		// 端の位置
		Positioning = Pos.transform.localPosition;  // 最初の鉋の位置
		diff = ePos.x - Positioning.x; // 差分
		increaseAmount = diff / 1000; // 動くたびに伸びる長さ
	}

    // Update is called once per frame
    void Update()
    {
		// クリックしたときのスケール取得
		Vector3 currentScale = transform.localScale;

		// 動いた距離を出す
		Positioning = Pos.transform.localPosition;  // 最初の鉋の位置
		float x = Positioning.x / diff; // 仮置き
		int times = (int)x;  // 伸ばす回数

		// Xのスケールを大きくしたVector3の作成
		Vector3 newScale = new(currentScale.x + increaseAmount, currentScale.y, currentScale.z);

		// オブジェクトに適応
		transform.localScale = newScale;
		Vector3 diffPos = (newScale - currentScale) / 2;
		Quaternion rotation = Quaternion.Euler(0, 0, -63f);

		transform.position -= rotation * diffPos;
		//transform.position = position;
		
	}
}
