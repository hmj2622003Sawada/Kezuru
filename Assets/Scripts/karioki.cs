using UnityEngine;

public class karioki : MonoBehaviour
{
	[SerializeField] GameObject AstartPos;
	[SerializeField] GameObject AendPos;
	[SerializeField] GameObject APos; // 鉋（かんな）

	Vector3 initialScale = new Vector3(0f, 0.0001f, 0.058f);
	float totalDistanceX;

	[SerializeField] float maxScaleX = 1f;

	void Start()
	{
		// 最初の見た目を反映
		transform.localScale = initialScale;

		// 総距離を計算（スタートからゴールまで）
		totalDistanceX = AendPos.transform.position.x - AstartPos.transform.position.x;
	}

	void Update()
	{
		if (totalDistanceX == 0) return;

		// 1. 鉋がスタートからどれくらい進んだかの割合（0.0 ～ 1.0）を計算
		float currentProgressX = APos.transform.position.x - AstartPos.transform.position.x;
		float ratio = Mathf.Clamp01(currentProgressX / totalDistanceX);

		// 2. 割合に応じたXスケールを計算して代入
		float targetScaleX = maxScaleX * ratio;
		transform.localScale = new Vector3(targetScaleX, initialScale.y, initialScale.z);

		// 3. 【ここを修正】基準を「鉋の中心」にする
		Vector3 kannaCenter = APos.transform.position; // 鉋の現在の中心座標
		Vector3 extendDirection = transform.right;    // 削りカスの右向きのベクトル

		// 鉋の中心から、伸びた長さの「半分」だけ進行方向とは【逆】にずらす
		// ※もし伸びる方向が逆（鉋の前に飛び出す）になった場合は、最後の「-」を「+」に変えてください
		transform.position = kannaCenter - (extendDirection * (targetScaleX / 2f));
	}
}
