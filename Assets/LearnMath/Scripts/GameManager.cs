using RangerRPG.Core;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace LearnMath {
    public class GameManager : SingletonBehaviour<GameManager> {
        public GarbageManager garbageManager;
        public NumbersManager numbersManager;
        public TMP_Text scoreText;
        public TMP_Text timerText;
        public GameObject gameOverScreen;
        public PlayerInput input;

        public AudioClip successClip;
        
        public int score = 0;
        public float elapsedTime = 0;
        public float maxTime = 60;

        private void Start() {
            Random.InitState((int) Time.time);
            scoreText.text = $"Score: {score}";
        }
        
        public void UpdatedNumber(Bucket bucket, int currentNumber) {
            if (garbageManager.RemoveGarbageUsingNumber(currentNumber)) {
                bucket.Reset();
                score += 10;
                scoreText.text = $"Score: {score}";
                AudioManager.Instance.Play(successClip);
            }
        }

        private void Update() {
            elapsedTime += Time.deltaTime;
            int timeLeft = (int) (maxTime - elapsedTime);
            timerText.text = $"Time Left: {timeLeft}";
            if (timeLeft <= 0) {
                EndGame();
            }
        }
        
        private void EndGame() {
            input.SwitchCurrentActionMap("GameEndMenu");
            gameOverScreen.SetActive(true);
        }

        public void Reload() {
            SceneManager.LoadScene("MathScene");
        }
    }
}