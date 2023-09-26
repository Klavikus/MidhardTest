using System;
using System.Threading;
using Codebase.Presentation.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private const string GameLoopScene = "GameLoop";

        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private double _resourceFakeLoadingDuration;

        private readonly CancellationTokenSource _destroyCancellationTokenSource = new CancellationTokenSource();

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            _destroyCancellationTokenSource.Cancel();
            _destroyCancellationTokenSource.Dispose();
        }

        public async void Initialize()
        {
            try
            {
                _loadingCurtain.Show();
                await EmulateResourceLoading();
                _loadingCurtain.Hide();
                await SceneManager.LoadSceneAsync(GameLoopScene, LoadSceneMode.Single);
            }
            catch (Exception ex) when (ex is OperationCanceledException)
            {
                Debug.LogWarning($"Async cancelled at the {nameof(Initialize)} of {nameof(Bootstrap)}");
            }
        }

        private async UniTask EmulateResourceLoading()
        {
            double currentDuration = 0;

            while (currentDuration < _resourceFakeLoadingDuration)
            {
                float progressAsPercentage = (float) (currentDuration / _resourceFakeLoadingDuration);
            
                _loadingCurtain.HandleProgress(progressAsPercentage);
            
                await UniTask.WaitForEndOfFrame(this, cancellationToken: _destroyCancellationTokenSource.Token);
                currentDuration += Time.deltaTime;
            }

            _loadingCurtain.HandleProgress(1f);
        }
    }
}