using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _runSpeed = 0;
    [SerializeField] private float _slideSpeed;
    [SerializeField] private float _maxSlideAmount;
    [SerializeField] private float _slideSmoothness;
    [SerializeField] private Transform _playerVisual;
    [SerializeField] private GameObject tapToStartScreen;
    [SerializeField] private GameObject loseGameScreen;


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
                break;
            case GameManager.GameState.MainGame:
                ForwardMovement();
                SwerveMovement();
                tapToStartScreen.SetActive(false);
                break;
            case GameManager.GameState.LoseGame:
                tapToStartScreen.SetActive(false);
                loseGameScreen.SetActive(true);
                break;
            case GameManager.GameState.WinGame:
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