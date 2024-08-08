using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UI : MonoBehaviour
{
    [SerializeField] float animationDuration = 0.5f;
    [SerializeField] Ease ease;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        RectTransform panelTransform = panel.GetComponent<RectTransform>();
        //sizeDelta is a vector2 containong the wodth/heigjt of a rect transform
        panelTransform.DOMove(panelTransform.position - Vector3.up * panelTransform.sizeDelta.y, animationDuration)
            .From().SetEase(ease);
    }
    public void ClosePanel(GameObject panel)
    {
        RectTransform panelTransform = panel.GetComponent<RectTransform>();
        //sizeDelta is a vector2 containong the wodth/heigjt of a rect transform
        panelTransform.DOMove(panelTransform.position - Vector3.up * panelTransform.sizeDelta.y, animationDuration)
            .SetEase(ease);
        panel.SetActive(false);
    }

}
