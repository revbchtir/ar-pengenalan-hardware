using UnityEngine;
using TMPro;

public class ARInteractionManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject infoPanel;
    public TMP_Text textNama;   // Khusus Nama Hardware
    public TMP_Text textKonten; // Khusus Paragraf Definisi / Fungsi

    private HardwareInfo currentHardware;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                HardwareInfo info = hit.transform.GetComponentInParent<HardwareInfo>();
                if (info != null)
                {
                    BukaPanel(info);
                }
            }
        }
    }

    public void BukaPanel(HardwareInfo info)
    {
        currentHardware = info;
        infoPanel.SetActive(true);
        textNama.text = info.namaHardware;

        // Default langsung menampilkan definisi saat panel terbuka
        TampilkanDefinisi();
    }

    public void TampilkanDefinisi()
    {
        if (currentHardware != null)
        {
            textKonten.text = currentHardware.definisi;
        }
    }

    public void TampilkanFungsi()
    {
        if (currentHardware != null)
        {
            textKonten.text = currentHardware.fungsi;
        }
    }

    public void TutupInfo()
    {
        infoPanel.SetActive(false);
        currentHardware = null;
    }
}