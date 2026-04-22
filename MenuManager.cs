using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // UI Panelleri
    public GameObject PromotionalPanel;
    public GameObject MainMenu;
    public GameObject Help;
    public GameObject FreePlayScene;
    public GameObject TutorialScene;
    public GameObject RhythmGameScene;
    public GameObject MelodyCreatorScene;

    // 3D Sahne Nesneleri 
    public GameObject FreePlayObjects;
    public GameObject TutorialObjects;
    public GameObject RhythmGameObjects;


    public float promotional_delay = 0; // Başlangıçta PromotionalPanel ne kadar saniye gözüksün
    public int currentState; // Mevcut durumu sayısal olarak tutacağız

    private void Start()
    {
        DeactiveAll(); // Tüm panelleri ve sahne nesnelerini kapat
        ChangeState(0); // 0: PromotionalPanel, tanıtım ekranı başlangıç
    }

    void Update()
    {
        if (currentState == 0)
        {
            promotional_delay -= Time.deltaTime;
            if (promotional_delay <= 0)
            {
                ChangeState(1); // Süre bitince MainMenu'ya geç
            }
        }
    }

    public void ChangeState(int state)
    {
        currentState = state;
        DeactiveAll(); // Tüm panelleri ve objeleri kapat

        // İlgili paneli ve sahne objelerini aç
        if (currentState == 0)
            PromotionalPanel.SetActive(true);
        else if (currentState == 1)
            MainMenu.SetActive(true);
        else if (currentState == 2)
            Help.SetActive(true);
        else if (currentState == 3)
        {
            FreePlayScene.SetActive(true);
            FreePlayObjects.SetActive(true);
        }
        else if (currentState == 4)
        {
            TutorialScene.SetActive(true);
            TutorialObjects.SetActive(true);
        }
        else if (currentState == 5)
        {
            RhythmGameScene.SetActive(true);
            RhythmGameObjects.SetActive(true);
        }
         else if (currentState == 6)
        {
            MelodyCreatorScene.SetActive(true);
        }
    }

    void DeactiveAll()
    {
        // Tüm UI Panelleri kapat
        PromotionalPanel.SetActive(false);
        MainMenu.SetActive(false);
        Help.SetActive(false);
        FreePlayScene.SetActive(false);
        TutorialScene.SetActive(false);
        RhythmGameScene.SetActive(false);
        MelodyCreatorScene.SetActive(false);

        // Tüm 3D sahne objelerini kapat
        FreePlayObjects.SetActive(false);
        TutorialObjects.SetActive(false);
        RhythmGameObjects.SetActive(false);
    }
}
