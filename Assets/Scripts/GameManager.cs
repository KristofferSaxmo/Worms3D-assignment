using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] [Range(2, 4)] private int teamAmount;
    [SerializeField] [Range(1, 4)] private int wormsPerTeam;
    [SerializeField] private List<Vector3> teamStartingPositions;
    [SerializeField] private List<Vector3> wormStartingPositions;
    [SerializeField] private List<Color> teamColors;
    private List<List<GameObject>> _teamsOfWorms;
    public GameObject CurrentWorm { get; private set; }
    public Camera playerCamera;
    private Queue<GameObject> _wormQueue;
    
    private void Start()
    {
        _teamsOfWorms = new List<List<GameObject>>();
        for (int i = 0; i < teamAmount; i++)
        {
            _teamsOfWorms.Add(new List<GameObject>());
            for (int j = 0; j < wormsPerTeam; j++)
            {
                _teamsOfWorms[i].Add(Instantiate(Resources.Load("Prefabs/Worm")) as GameObject);
                DisableWorm(_teamsOfWorms[i][j]);
                _teamsOfWorms[i][j].transform.position = teamStartingPositions[i] + wormStartingPositions[j];
                _teamsOfWorms[i][j].GetComponent<Worm>().TeamNumber = i;
                TextMeshProUGUI teamText = _teamsOfWorms[i][j].transform.GetChild(2).GetChild(4).GetComponent<TextMeshProUGUI>();
                teamText.color = teamColors[i];
                teamText.text = "Team " + (i + 1);
            }
        }
        _wormQueue = new Queue<GameObject>();
        for (int i = 0; i < wormsPerTeam; i++)
            for (int j = 0; j < teamAmount; j++)
                _wormQueue.Enqueue(_teamsOfWorms[j][i]);

        CurrentWorm = _wormQueue.Dequeue();
        EnableWorm(CurrentWorm);
    }

    public void RemoveWorm(GameObject worm)
    {
        _wormQueue = new Queue<GameObject>(_wormQueue.Where(x => x != worm));
        for (int i = 0; i < _teamsOfWorms.Count; i++)
        {
            if (!_teamsOfWorms[i].Contains(worm)) continue;
            _teamsOfWorms[i].Remove(worm);
            
            if (_teamsOfWorms[i].Count != 0) break;
            _teamsOfWorms.Remove(_teamsOfWorms[i]);
            
            if (_teamsOfWorms.Count != 1) break;
            
            int winningTeam = _teamsOfWorms[0][0].GetComponent<Worm>().TeamNumber;
            GameObject endScene = Instantiate(Resources.Load("prefabs/EndScene") as GameObject);
            TextMeshProUGUI endSceneText = endScene.GetComponentInChildren<TextMeshProUGUI>();
            endSceneText.text = "Team " + (winningTeam + 1) + " Wins!";
            endSceneText.color = teamColors[winningTeam];
        }
    }

    private void DisableWorm(GameObject worm)
    {
        worm.GetComponentInChildren<WeaponHandler>().enabled = false;
        worm.GetComponent<WormMovement>().enabled = false;
    }

    private void EnableWorm(GameObject worm)
    {
        worm.GetComponentInChildren<WeaponHandler>().enabled = true;
        worm.GetComponent<WormMovement>().enabled = true;
        playerCamera.GetComponent<CameraMovement>().target = worm.transform;
    }
    
    public void SwitchWorm()
    { 
        DisableWorm(CurrentWorm);
        
        _wormQueue.Enqueue(CurrentWorm);
        CurrentWorm = _wormQueue.Dequeue();
        
        EnableWorm(CurrentWorm);
    }
}