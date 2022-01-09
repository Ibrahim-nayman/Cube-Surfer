using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _runSpeed = 0;
    [SerializeField] private float _slideSpeed;
    [SerializeField] private float _maxSlideAmount;
    [SerializeField] private float _slideSmoothness;
    [SerializeField] private Transform _playerVisual;
    [SerializeField] private GameObject _tapToStartScreen;
    [SerializeField] private GameObject _loseGameScreen;
    [SerializeField] private GameObject _winRestartScreen;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject loseAudio;
    [SerializeField] private GameObject winAudio;
    [SerializeField] private GameObject mainAudio;

    private Rigidbody _rigidbody;

    private float _playerVisualPositionX;
    private float _mousePositionX;


    private void Update()
    {
        #region GameState

        switch (GameManager.Instance.CurrentGameState)
        {
            case GameManager.GameState.StartGame:
                Starting();
                mainAudio.SetActive(true);
                break;
            case GameManager.GameState.MainGame:
                _animator.SetBool("Crouch", true);
                ForwardMovement();
                SwerveMovement();
                _tapToStartScreen.SetActive(false);
                mainAudio.SetActive(true);
                break;
            case GameManager.GameState.LoseGame:
                _animator.SetBool("Death", true);
                _animator.SetBool("Crouch", false);
                StartCoroutine(loseScreen());
                loseAudio.SetActive(true);
                mainAudio.SetActive(false);
                break;
            case GameManager.GameState.WinGame:
                _animator.SetBool("Dance", true);
                _animator.SetBool("Crouch", false);
                StartCoroutine(winScreen());
                winAudio.SetActive(true);
                mainAudio.SetActive(false);
                break;
            default:
                break;
        }

        #endregion
    }

    private void Starting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.CurrentGameState = GameManager.GameState.MainGame;
        }
    }

    private IEnumerator winScreen()
    {
        yield return new WaitForSeconds(2);
        _winRestartScreen.SetActive(true);
    }

    private IEnumerator loseScreen()
    {
        yield return new WaitForSeconds(0.5f);
        _loseGameScreen.SetActive(true);
    }


    #region PlayerMovement

    private void ForwardMovement()
    {
        transform.Translate(Vector3.forward * _runSpeed * Time.deltaTime);
    }

    private void SwerveMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerVisualPositionX = _playerVisual.localPosition.x;
            _mousePositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            float currentMousePositionX = Input.mousePosition.x;
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

    #endregion
}