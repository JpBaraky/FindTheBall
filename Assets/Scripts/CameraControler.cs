using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class CameraControler : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float zoomSpeed = 20f;
    public float panSpeed = 10f;

    public float dutchSpeed = 20;
    private AudioClip shutter;
    private AudioSource audioSource;

    void Start(){
        
        audioSource = GetComponent<AudioSource>();
        shutter = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sounds/Sound Effects/Shutter.wav");
    }


    // Update is called once per frame
    void Update()
    {
     
            RotateCameraGamepad();
            ZoomCameraGamepad();
            PanCameraGamepad();
            DutchAngle();
            if(Gamepad.current.buttonWest.IsActuated()){
                CaptureScreen();
            }
        


    }

  
    void RotateCameraGamepad()
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        Vector2 rightStickInput = Gamepad.current.rightStick.ReadValue();
        rotation.y += rightStickInput.x * rotationSpeed * Time.deltaTime;

        Vector2 leftStickInput = Gamepad.current.rightStick.ReadValue();
        rotation.x -= leftStickInput.y * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(rotation);
    }

     void PanCameraGamepad()
    {
        Vector3 pos = transform.position;

        Vector2 panInput = Gamepad.current.leftStick.ReadValue();

        pos.x += panInput.x * panSpeed * Time.deltaTime;
        pos.z += panInput.y * panSpeed * Time.deltaTime;

        transform.position = pos;
    }

    void ZoomCameraGamepad()
    {
        float zoomInput = Gamepad.current.rightTrigger.ReadValue() - Gamepad.current.leftTrigger.ReadValue();

        Vector3 pos = transform.position;
        pos.y += zoomInput * zoomSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, 1f, 80f);

        transform.position = pos;
    }
    void DutchAngle(){
       Vector3 rotation = transform.rotation.eulerAngles;

        float zRotationInput = Gamepad.current.rightShoulder.ReadValue() - Gamepad.current.leftShoulder.ReadValue();
        rotation.z += zRotationInput * -dutchSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(rotation);
    }
    void CaptureScreen()
    {
        if(audioSource != null && shutter != null){
        audioSource.PlayOneShot(shutter);
        }
        // Define the custom directory path (change this to your desired path)
        string customDirectory = "C:/Users/Jpbar/Desktop/Screenshots/" + PlayerSettings.productName+"/";

        // Ensure the directory exists, create it if not
        if (!System.IO.Directory.Exists(customDirectory))
        {
            System.IO.Directory.CreateDirectory(customDirectory);
        }

        // Capture a screenshot and save it to the custom directory with a unique filename
        string screenshotFileName = customDirectory + "Screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        ScreenCapture.CaptureScreenshot(screenshotFileName);

        Debug.Log("Screenshot captured: " + screenshotFileName);
    }
}