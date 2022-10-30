// using UnityEngine;

// public class Dump : MonoBehaviour {
//     public GameObject[] researchers;
//     public Vector2[] profilePositions;
//     public int[] profileStatus; // 0 - empty, 1 - add new prompt, 2 - filled

//     void Start()
//     {
//         if (ProfileManagerScript.isFirstRun == true)
//         {
//             profileStatus = new List<int> { 1, 0, 0, 0, 0, 0 };
//         }

//         profilePositions = new List<Vector2>(new Vector2[6]);

//         for (int i = 0; i < 6; i++)
//         {
//             profilePositions[i] = researchers[i].GetComponent<RectTransform>().anchoredPosition;
//         }

//         UpdateProfileUI();
//     }

//     public void AddProfile()
//     {
//         Debug.Log("Pressed add");
//         for (int i = 0; i < 6; i++)
//         {
//             if (profileStatus[i] == 1)
//             {
//                 profileStatus[i] = 2;
//                 if (i < 5)
//                 {
//                     profileStatus[i + 1] = 1;
//                 }
//                 break;
//             }
//         }

//         UpdateProfileUI();
//     }

//     public void OpenEditProfile()
//     {

//     }

//     public void DeleteProfile(int index)
//     {
//         if (profileStatus[5] == 2)
//         {
//             profileStatus.Add(1);
//         }
//         else
//         {
//             profileStatus.Add(0);
//         }
//         profileStatus.RemoveAt(index);
//         UpdateProfileUI();
//     }

//     public void UpdateProfileUI()
//     {
//         for (int i = 0; i < 6; i++)
//         {
//             Destroy(researchers[i]);

//             switch (profileStatus[i])
//             {
//                 case 0: // emptyResearcher
//                     researchers[i] = Instantiate(emptyResearcherPrefab, profilePositions[i], transform.rotation, researchersParentObject.transform);
//                     break;
//                 case 1: // addResearcher
//                     researchers[i] = Instantiate(addResearcherPrefab, profilePositions[i], transform.rotation, researchersParentObject.transform);
//                     researchers[i].GetComponent<Button>().onClick.AddListener(AddProfile);
//                     break;
//                 case 2: // filledResearcher
//                     researchers[i] = Instantiate(filledResearcherPrefab, profilePositions[i], transform.rotation, researchersParentObject.transform);
//                     int iLocal = i;
//                     researchers[i].transform.Find("DeleteResearcherButton").GetComponent<Button>().onClick.AddListener(delegate { DeleteProfile(iLocal); });
//                     researchers[i].transform.Find("EditResearcherButton").GetComponent<Button>().onClick.AddListener(OpenEditProfile);
//                     break;
//             }
//             researchers[i].GetComponent<RectTransform>().anchoredPosition = profilePositions[i];
//         }
//     }

//     public void AddProfile()
//     {
//         for (int i = 0; i < 6; i++)
//         {
//             if (profileStatus[i] == 1) // Change current profile card
//             {
//                 profileStatus[i] = 2;
//                 Destroy(researchers[i]);
//                 researchers[i] = Instantiate(filledResearcherPrefab, profilePositions[i], transform.rotation, researchersParentObject.transform);
//                 researchers[i].GetComponent<RectTransform>().anchoredPosition = profilePositions[i];
//                 researchers[i].transform.Find("DeleteResearcherButton").GetComponent<Button>().onClick.AddListener(delegate { DeleteProfile(i); });
//                 if (i < 5) // Change next profile card
//                 {
//                     profileStatus[i + 1] = 1;
//                     Destroy(researchers[i + 1]);
//                     researchers[i + 1] = Instantiate(addResearcherPrefab, profilePositions[i + 1], transform.rotation, researchersParentObject.transform);
//                     researchers[i + 1].GetComponent<RectTransform>().anchoredPosition = profilePositions[i + 1];
//                     researchers[i + 1].GetComponent<Button>().onClick.AddListener(AddProfile);
//                 }
//                 break;
//             }
//         }
//     }    
// }