using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritPivot : MonoBehaviour
{
    GameObject Player;

    GameObject Spirit;

    // soul fragment
    public GameObject soulFragment;

    [SerializeField]
    private float shootForce = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Spirit = GameObject.FindWithTag("Spirit");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // get mouse position direction
            Vector3 difference =
                -(
                Camera.main.ScreenToWorldPoint(Input.mousePosition) -
                transform.position
                );
            difference.Normalize();

            // get degrees
            float rotationZ =
                Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            // when rotate to the other side only flip on x axis
            if (rotationZ < -90 || rotationZ > 90)
            {
                if (Player.transform.eulerAngles.y == 0)
                {
                    transform.localRotation =
                        Quaternion.Euler(180, 0, -rotationZ);
                }
                else if (
                    Player.transform.eulerAngles.y == 180 // when player face left
                )
                {
                    transform.localRotation =
                        Quaternion.Euler(180, 180, -rotationZ);
                }
            }

            // spirit attack still obstacles
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -60f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos =
                new Vector3(Spirit.transform.position.x,
                    Spirit.transform.position.y + 0.5f);
            GameObject soulFragmentPrefab =
                Instantiate(soulFragment,
                spawnPos,
                soulFragment.transform.rotation);
            soulFragmentPrefab
                .GetComponent<Rigidbody2D>()
                .AddForce(Vector3.right * shootForce, ForceMode2D.Impulse);
        }
    }
}
