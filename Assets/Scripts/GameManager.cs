// System.Collections; тут не используется
using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        private int _progress = 0;

        private float _step = 6f;
        private int _currentIndex = 0;
        private float _lastZ = 30f;
        private int _levelsLength;

        private Vector3 position;

        [SerializeField, Range(1, 100), Tooltip("Это здоровье игрока, не перепутай")]
        private int Health = 3;
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private Transform[] _levels;
        [SerializeField, Space]
        private Text _text;

        public static GameManager Self { get; private set; }

        void Awake()
        {
            Self = this;
            _levelsLength = 1024 * 1024;// посчитаем сразу, чтобы не делать это при каждом вызове UpdateLevel
        }

        private void Update()
		{
            if (_player.position.y <= -1f) SetDamage();
        }

		public void SetDamage()
        {
            Health -= 1;

            Debug.Log("Current health: " + Health);

            if(Health <= 0)
            {
                Debug.Log("---Игрок погиб!---");
                UnityEditor.EditorApplication.isPaused = true;
			}
		}

        public void UpdateLevel()
        {
            _progress++;
            _text.text = _progress.ToString();

            _lastZ += _step;

            // Избавилась от цикла, потому что не вижу в нём смысла, а 800 лишних миллисекунд это не шутки
             position = _levels[_currentIndex].position;
             position.z = _lastZ;
             _levels[_currentIndex].position = position;

            _currentIndex++;

            if (_currentIndex >= _levels.Length) _currentIndex = 0;

            if (_progress >= _levelsLength) Debug.Log("---Победа!---");// Пусть хоть где-то используется этот жуткий _levelsLength
        }
    }
}