using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 2f;
    public FixedJoystick joystick; // 追加：ジョイスティックをセットする枠

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --- 移動処理（キーボード ＋ ジョイスティック両対応） ---
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ジョイスティックがセットされていれば入力を追加
        if (joystick != null)
        {
            h += joystick.Horizontal;
            v += joystick.Vertical;
        }

        Vector3 move = transform.right * h + transform.forward * v;
        if (controller != null)
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        // --- 視点回転 ---
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            transform.Rotate(0, mouseX, 0);
        }
    }
}