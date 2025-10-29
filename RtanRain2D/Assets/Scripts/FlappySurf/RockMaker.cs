using UnityEngine;
public class RockMaker : MonoBehaviour//바위를 랜덤 생성하는 클래스.
{
    [SerializeField]
    private GameObject cloudPrefab;
    [SerializeField]
    private GameObject landPrefab;
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
    [SerializeField]
    private float cloudRevealTime = 1.0f;
    [SerializeField]
    private float landRevealTime = 1.0f;
    float currentTime = 0.0f;
    float cloudCurrentTime = 40.0f;
    float landCurrentTime = 0.0f;
    float minHeight = -3.5f;
    float maxHeight = -3.1f;
    float maxWidth = 30f;
    Vector3 location = new Vector3(0f, 0f, 0f);
    Vector3 backgroundLocation = new Vector3(39f, 0f, 0f);
    void Update()
    {
        currentTime += Time.deltaTime;
        cloudCurrentTime += Time.deltaTime;
        landCurrentTime += Time.deltaTime;
        if (cloudCurrentTime >= cloudRevealTime)
        {
            Instantiate(cloudPrefab, backgroundLocation, Quaternion.identity);
            cloudCurrentTime = 0.0f;
        }
        if (landCurrentTime >= landRevealTime)
        {
            Instantiate(landPrefab, backgroundLocation, Quaternion.identity);
            landCurrentTime = 0.0f;
        }
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
        GameObject rock = Instantiate(randomRock, location, Quaternion.identity);
        currentTime = 0f;
    }
}
