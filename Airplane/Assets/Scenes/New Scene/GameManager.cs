using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int attackScore
    {
        get 
        {
            return instance._attackScore;
        }
        set 
        {
            instance._attackScore = value;
            instance.attack.text = instance._attackScore + "";

            if (instance._attackScore + instance._destroyScore > instance._bestScore)
            {
                instance._bestScore = instance._attackScore + instance._destroyScore;
                instance.best.text = instance._bestScore + "";
                PlayerPrefs.SetInt("BestScore", instance._bestScore);
            }
        }
    }
    public static int destroyScore
    {
        get
        {
            return instance._destroyScore;
        }
        set
        {
            instance._destroyScore = value;
            instance.destroy.text = instance._destroyScore + "";

            if (instance._attackScore + instance._destroyScore > instance._bestScore)
            {
                instance._bestScore = instance._attackScore + instance._destroyScore;
                instance.best.text = instance._bestScore + "";
                PlayerPrefs.SetInt("BestScore", instance._bestScore);
            }
        }
    }

    private int _attackScore = 0;
    private int _bestScore = 0;
    private int _destroyScore = 0;

    public TextMeshProUGUI attack;
    public TextMeshProUGUI best;
    public TextMeshProUGUI destroy;

    private void Awake()
    {
        instance = this;

        _bestScore = PlayerPrefs.GetInt("BestScore", 0);

        attack.text = _attackScore + "";
        best.text = _bestScore + "";
        destroy.text = _destroyScore + "";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
