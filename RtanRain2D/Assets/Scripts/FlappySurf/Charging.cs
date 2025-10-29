using UnityEngine;
using UnityEngine.UI;
namespace RtanMetaverse
{
    public class Charging : MonoBehaviour//길게 누를때 점프력을 결정하는 클래스
    {
        private Image energeBar;
        private RtanSurf rtanSurf;
        private void Awake()
        {
            energeBar = GetComponent<Image>();
            rtanSurf = FindAnyObjectByType<RtanSurf>();
        }
        void Update()
        { energeBar.fillAmount = rtanSurf.RtanJumping / 8f; }
    }
}
