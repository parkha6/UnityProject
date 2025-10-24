using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMaker : MonoBehaviour
{
    [SerializeField]
    private GameObject rock1;
    [SerializeField]
    private GameObject rock2;
    [SerializeField]
    private GameObject rock3;
    [SerializeField]
    private GameObject rock4;
    [SerializeField]
    private GameObject rock5;
    [SerializeField]
    private GameObject rock6;
    [SerializeField]
    private GameObject rock7;
    [SerializeField]
    private GameObject rock8;
    [SerializeField]
    private GameObject rock9;
    [SerializeField]
    private GameObject rock10;
    [SerializeField]
    private GameObject rock11;

    [SerializeField]
    private float revealTime = 1.0f;
    float currentTime = 0.0f;
    float minHeight = -3.5f;
    float rtanHeight = -3.33f;
    float maxHeight = -3.1f;
    float minWidth = -10.5f;
    float maxWidth = 30f;
    Vector3 location = new Vector3(0f, 0f, 0f);
    SpriteRenderer sortingRender;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= revealTime)
        {
            switch (Random.Range(1, 13))
            {
                case 1:
                    RevealRock(rock1);
                    break;
                case 2:
                    RevealRock(rock2);
                    break;
                case 3:
                    RevealRock(rock3);
                    break;
                case 4:
                    RevealRock(rock4);
                    break;
                case 5:
                    RevealRock(rock5);
                    break;
                case 6:
                    RevealRock(rock6);
                    break;
                case 7:
                    RevealRock(rock7);
                    break;
                case 8:
                    RevealRock(rock8);
                    break;
                case 9:
                    RevealRock(rock9);
                    break;
                case 10:
                    RevealRock(rock10);
                    break;
                case 11:
                    RevealRock(rock11);
                    break;
                default:
                    break;
            }
        }
    }
    void RevealRock(GameObject randomRock)
    {
        location.y = Random.Range(minHeight, maxHeight);
        location.x = maxWidth;
        GameObject rock = Instantiate(randomRock,location, Quaternion.identity);
        sortingRender = rock.GetComponent<SpriteRenderer>();
        if (location.y >= rtanHeight)
        { sortingRender.sortingOrder = 2; }
        else if (location.y <= rtanHeight)
        { sortingRender.sortingOrder = 4; }
        currentTime = 0f;
    }
}
