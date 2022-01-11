using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")] 
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _slideSpeed;
    [SerializeField] private float _slideSmoothness;
    [SerializeField] private float _maxSlideAmount;
    [SerializeField] private Transform _playerVisual;
    [SerializeField] private Animator _animator;
    [SerializeField] private Camera _cam;

    private float _mousePositionX;
    private float _playerVisualPositionX;

    [SerializeField] private GameObject _tapToStartScreen;
    [SerializeField] private GameObject _loseGameScreen;
    [SerializeField] private GameObject _winRestartScreen;
    [SerializeField] private GameObject _mainStartScreen;
    

    [SerializeField] private GameObject _loseAudio;
    [SerializeField] private GameObject _winAudio;
    [SerializeField] private GameObject _mainAudio;

    private Rigidbody _rigidbody;
    private bool _isPlayerInteract;
    
    private void Update()
    {
        #region GameState

        switch (GameManager.Instance.CurrentGameState)
        {
            case GameManager.GameState.StartGame:
                _mainAudio.SetActive(true);
                break;
            case GameManager.GameState.MainGame:
                _animator.SetBool("Crouch", true);
                ForwardMovement();
                SwerveMovement();
                _tapToStartScreen.SetActive(false);
                _mainAudio.SetActive(true);
                break;
            case GameManager.GameState.LoseGame:
                _animator.SetBool("Death", true);
                _animator.SetBool("Crouch", false);
                StartCoroutine(LoseScreen());
                _loseAudio.SetActive(true);
                _mainAudio.SetActive(false);
                _mainStartScreen.SetActive(false);
                break;
            case GameManager.GameState.WinGame:
                _animator.SetBool("Dance", true);
                _animator.SetBool("Crouch", false);
                StartCoroutine(WinScreen());
                _winAudio.SetActive(true);
                _mainAudio.SetActive(false);
                _mainStartScreen.SetActive(false);
                break;
            default:
                break;
        }

        #endregion
    }

    private IEnumerator WinScreen()
    {
        yield return new WaitForSeconds(2);
        _winRestartScreen.SetActive(true);
    }

    private IEnumerator LoseScreen()
    {
        yield return new WaitForSeconds(2);
        _loseGameScreen.SetActive(true);
    }


    #region PlayerMovement

    private void ForwardMovement()
    {
        transform.Translate(Vector3.forward * _runSpeed * Time.deltaTime);
    }

    private void SwerveMovement()
    {
        if (!_isPlayerInteract)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerVisualPositionX = _playerVisual.localPosition.x;
                _mousePositionX = _cam.ScreenToViewportPoint(Input.mousePosition).x;
            }

            if (Input.GetMouseButton(0))
            {
                float currentMousePositionX = _cam.ScreenToViewportPoint(Input.mousePosition).x;
                float distance = currentMousePositionX - _mousePositionX;
                float positionX = _playerVisualPositionX + (distance * _slideSpeed);
                Vector3 position = _playerVisual.localPosition;
                position.x = Mathf.Clamp(positionX, -_maxSlideAmount, _maxSlideAmount);
                _playerVisual.localPosition = Vector3.Lerp(_playerVisual.localPosition, position, _slideSmoothness * Time.deltaTime);
            }
            else
            {
                Vector3 pos = _playerVisual.localPosition;
            }
        }
    }

    #endregion
}