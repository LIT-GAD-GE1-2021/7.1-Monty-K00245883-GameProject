using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPH : MonoBehaviour
{
    public static PPH instance;
   
    public GameObject switchA;
    public GameObject switchB;
    public GameObject switchC;
    public GameObject switchD;
    public GameObject switchE;

    private PlatformSwitch switchCtrlA;
    private PlatformSwitch switchCtrlB;
    private PlatformSwitch switchCtrlC;
    private PlatformSwitch switchCtrlD;
    private PlatformSwitch switchCtrlE;


    public GameObject platformA;
    public GameObject platformB;
    public GameObject platformC;
    public GameObject platformD;
    public GameObject platformE;
    public GameObject platformF;

    private PlatformController platCtrlA;
    private PlatformController platCtrlB;
    private PlatformController platCtrlC;
    private PlatformController platCtrlD;
    private PlatformController platCtrlE;
    private PlatformController platCtrlF;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        switchCtrlA = switchA.GetComponent<PlatformSwitch>();
        switchCtrlB = switchB.GetComponent<PlatformSwitch>();
        switchCtrlC = switchC.GetComponent<PlatformSwitch>();
        switchCtrlD = switchD.GetComponent<PlatformSwitch>();
        switchCtrlE = switchE.GetComponent<PlatformSwitch>();

        platCtrlA = platformA.GetComponent<PlatformController>();
        platCtrlB = platformB.GetComponent<PlatformController>();
        platCtrlC = platformC.GetComponent<PlatformController>();
        platCtrlD = platformD.GetComponent<PlatformController>();
        platCtrlE = platformE.GetComponent<PlatformController>();
        platCtrlF = platformF.GetComponent<PlatformController>();
    }

    void Update()
    {

    }
    public void FlipA()
    {
        platCtrlA.RotatePlatform();
        platCtrlB.RotatePlatform();
        platCtrlF.RotatePlatform();
    }
    public void FlipB()
    {
        platCtrlA.RotatePlatform();
        platCtrlC.RotatePlatform();
        platCtrlE.RotatePlatform();

    }
    public void FlipC()
    {
        platCtrlA.RotatePlatform();
        platCtrlB.RotatePlatform();
        platCtrlD.RotatePlatform();
        platCtrlE.RotatePlatform();
    }
    public void FlipD()
    {
        platCtrlA.RotatePlatform();
        platCtrlB.RotatePlatform();
        platCtrlC.RotatePlatform();
        platCtrlE.RotatePlatform();
        platCtrlF.RotatePlatform();
    }
    public void FlipE()
    {
        platCtrlA.RotatePlatform();
        platCtrlB.RotatePlatform();
        platCtrlC.RotatePlatform();
        platCtrlD.RotatePlatform();
    }
}
