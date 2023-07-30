using UnityEngine;

public class BulletMaker : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform startBulletTransform;
    [SerializeField]
    private Vector3 bulletStartScale;
    [SerializeField]
    private Vector3 bulletStartRotation;

    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = startBulletTransform.position;
        bullet.transform.localScale = bulletStartScale;
        bullet.transform.localRotation = Quaternion.Euler(bulletStartRotation);
        AudioManager.Instance.PlayShotEffect();
    }
}