using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpiritPivot : MonoBehaviour
{
    GameObject Player;

    GameObject Spirit;

    // soul fragment
    public GameObject soulFragment;

    [SerializeField]
    private float shootForce = 2f;

    [SerializeField]
    private int soulCounts = 10;

    [SerializeField]
    private float reloadDelay = 1f;

    // souls fragment texts
    public TextMeshProUGUI soulsCountText;

    public TextMeshProUGUI reloadingText;

    public TextMeshProUGUI reloadingAlertText;

    // game Manager
    GameManager gameManager;

    // animation
    Animator anim;

    // sound
    AudioSource audioSource;

    public AudioClip catAttackSound;

    // mobile button
    public Button absorbButton;

    public Button shootButton;

    private string platform;

    private bool isAbsorbButtonPressed = false;

    private bool isShootButtonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Spirit = GameObject.FindWithTag("Spirit");
        reloadingText.gameObject.SetActive(false);
        reloadingAlertText.gameObject.SetActive(false);
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GameObject.Find("spiritBody").GetComponent<Animator>();
        audioSource = Player.GetComponent<AudioSource>();

        // check platform
        platform =
            SystemInfo.deviceType == DeviceType.Desktop
                ? "Desktop"
                : "Handheld";
        if(platform == "Handheld"){
            absorbButton.gameObject.SetActive(true);
            shootButton.gameObject.SetActive(true);
        }
        if(platform == "Desktop"){
            absorbButton.gameObject.SetActive(false);
            shootButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && gameManager.isGameActive)
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
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void Update()
    {
        if (gameManager.isGameActive)
        {
            soulsCountText.text = "Souls Count : " + soulCounts;
            if (Input.GetKeyDown(KeyCode.Space) || isShootButtonPressed)
            {
                CheckSoulCounts();
                anim.SetBool("attack", true);
                isShootButtonPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.R) || isAbsorbButtonPressed)
            {
                StartCoroutine(ReloadDelay());
                isAbsorbButtonPressed = false;
            }
        }
    }

    public void CheckAbsorbSoulPressed()
    {
        isAbsorbButtonPressed = true;
    }

    public void CheckShootPressed()
    {
        isShootButtonPressed = true;
    }

    void CheckSoulCounts()
    {
        if (soulCounts > 0)
        {
            ShootSouls();
        }
        if (soulCounts == 0)
        {
            reloadingAlertText.gameObject.SetActive(true);
        }
    }

    IEnumerator ReloadDelay()
    {
        reloadingAlertText.gameObject.SetActive(false);
        reloadingText.gameObject.SetActive(true);
        yield return new WaitForSeconds(reloadDelay);
        reloadingText.gameObject.SetActive(false);
        soulCounts = 10;
        reloadDelay = 1f;
    }

    void ShootSouls()
    {
        audioSource.PlayOneShot (catAttackSound);
        Vector3 spawnPos =
            new Vector3(Spirit.transform.position.x,
                Spirit.transform.position.y + 2f);

        GameObject soulFragmentPrefab =
            Instantiate(soulFragment,
            spawnPos,
            soulFragment.transform.rotation);
        soulFragmentPrefab
            .GetComponent<Rigidbody2D>()
            .AddForce(Vector3.right * shootForce, ForceMode2D.Impulse);
        soulCounts--;
    }
}
