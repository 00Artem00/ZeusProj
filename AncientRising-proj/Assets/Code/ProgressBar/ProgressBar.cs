using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.ProgressBar
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _imageFill;
        [SerializeField] private TextMeshProUGUI _textScore;

        public void SetupProgressBar(int score)
        {
            _imageFill.fillAmount = Random.Range(0f, 1f);
            _textScore.text = Random.Range(100, 500).ToString();
        }
    }
}