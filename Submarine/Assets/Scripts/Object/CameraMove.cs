using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [HideInInspector]
    public SubMarine Player;

    [Header("Setting")]
    public Vector3 Offset;
    public float ShakeAmount = 0.05f;
    public float ShakeTime = 0.5f;

    bool shakeFlag = false;
    float shaketime;

    void Start()
    {
        GameManager.Instance.HitEvent += StartCameraShake;
        Player = GameManager.Instance.Player;
    }

    void LateUpdate()
    {
        Vector3 shakeVector = Vector3.zero;

        if (shakeFlag)
        {
            shakeVector = Random.insideUnitSphere * ShakeAmount;

            shaketime -= Time.deltaTime;
            if (shaketime < 0) shakeFlag = false;
        }
      
        transform.position = new Vector3(Player.transform.position.x, 0, 0) + Offset + shakeVector;
    }

    //void FixedUpdate()
    //{
    //    if (shakeFlag)
    //        CameraShake();
    //}

    public void StartCameraShake(int notuse = 0)
    {
        Debug.Log("Shake Start");

        shakeFlag = true;
        shaketime = ShakeTime;
    }

    //public void CameraShake()
    //{
    //    Debug.Log("Shake  " + shaketime);

    //    Vector3 originPos = transform.localPosition;
    //    transform.localPosition = originPos + Random.insideUnitSphere * ShakeAmount;

    //    shaketime -= Time.deltaTime;
    //    if (shaketime < 0) shakeFlag = false;
    //}
}
