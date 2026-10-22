using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
	[SerializeField] float moveSpeed = 0.01f; // 移動の速度
	[SerializeField] float deceleration = 1.0f; // 移動の速度
	private Vector3 velocity; // 現在の移動速度（勢い）
	bool isTouching;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update()
	{
		if (Pointer.current != null)
		{
			// 画面をタッチ・クリックしているか
			bool isTouching = Pointer.current.press.isPressed;

			if (isTouching)
			{
				// スワイプの移動量を取得
				Vector2 delta = Pointer.current.delta.ReadValue();

				// delta.x（横の移動）を使い、YとZは 0 に固定
				Vector3 targetVelocity = new Vector3(delta.x, 0, 0) * moveSpeed;

				// 滑らかにスワイプに追従させる
				velocity = Vector3.Lerp(velocity, targetVelocity, Time.deltaTime * 15f);
			}
			else
			{
				// 離したら徐々に減速して止まる
				velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * deceleration);
			}
		}

		// 計算されたX方向の速度だけで移動
		transform.Translate(velocity * Time.deltaTime, Space.World);
	}
}

