using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTrackerUI : MonoBehaviour
{
    public PlayerInputHandler InputHandler;

    

    public List<PlayerInputHandler.FightInputs> uiList = new List<PlayerInputHandler.FightInputs>();
    //public List<PlayerInputHandler.FightInputs> workspace;
    public Image[] image;
    public Sprite[] sprites;


    private int listLange;
    private int newInputInList;
    private int workspaceA;
    private int workspaceB;
    private int workspaceC;


    private void Start()
    {
        newInputInList = InputHandler.NewInputInList;

    }

    public void Update()
    {
        workspaceA = InputHandler.NewInputInList;
        CheckInput();
    }

    private void CheckInput()
    {
        if(newInputInList!=workspaceA)
        {
            newInputInList= InputHandler.NewInputInList;
            workspaceB = (int)InputHandler.recentInputs[26];
            //Debug.Log(workspaceB);
            MoveInputFrame();
            image[25].sprite = sprites[workspaceB];

        }
    }

    private void MoveInputFrame()
    {
        for(int f = 0, g = 1; g <= 25; f++, g++)
        {
            image[f].sprite = image[g].sprite;

        }
    }

}
//    private void Start()
//    {
//        workspace.AddRange(InputHandler.recentInputs);
//        uiList = workspace;
//        listLange = uiList.Count - 1;
//    }

//    private void Update()
//    {
//        //CheckList();
//        CheckSprite();
//    }



//    //private void CheckList()
//    //{

//    //    //uiList = InputHandler.recentInputs;
//    //    listLange = uiList.Count - 1;
//    //}

//    public void CheckSprite()
//    {
//        for (int i = uiList.Count - 1, j = InputHandler.recentInputs.Count - 1; j >= 3|| i>=3; i--, j--)
//        {

//            PlayerInputHandler.FightInputs Uiinput = uiList[i];
//            PlayerInputHandler.FightInputs recentInputs = InputHandler.recentInputs[j];

//            if (Uiinput != recentInputs)
//            {

//                if (InputHandler.recentInputs[20] == PlayerInputHandler.FightInputs.Up)
//                {
//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                    image[0].sprite = sprites[0];
//                    Debug.Log("List NICHT Sync");
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
                        
//                    }


//                }
//                else if (InputHandler.recentInputs[20] == PlayerInputHandler.FightInputs.UpRight)
//                {
//                    Debug.Log("List NICHT Sync");
                    
//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                        image[0].sprite = sprites[1];
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
//                    }
                    
                    
//                }
//                else if (InputHandler.recentInputs[20] == PlayerInputHandler.FightInputs.Right)
//                {
//                    Debug.Log("List NICHT Sync");

//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                        image[0].sprite = sprites[2];
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
//                    }


//                }
//                else if (InputHandler.recentInputs[20] == PlayerInputHandler.FightInputs.DownRight)
//                {
//                    Debug.Log("List NICHT Sync");

//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                        image[0].sprite = sprites[3];
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
//                    }


//                }
//                else if (InputHandler.recentInputs[20] == PlayerInputHandler.FightInputs.Down)
//                {
//                    Debug.Log("List NICHT Sync");

//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                        image[0].sprite = sprites[4];
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
//                    }


//                }
//                else if (InputHandler.recentInputs[20] == PlayerInputHandler.FightInputs.DownLeft)
//                {
//                    Debug.Log("List NICHT Sync");

//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                        image[0].sprite = sprites[5];
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
//                    }


//                }
//                else if (InputHandler.recentInputs[20] == PlayerInputHandler.FightInputs.Left)
//                {
//                    Debug.Log("List NICHT Sync");

//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                        image[0].sprite = sprites[6];
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
//                    }


//                }
//                else if (InputHandler.recentInputs[20] == PlayerInputHandler.FightInputs.UpLeft)
//                {
//                    Debug.Log("List NICHT Sync");

//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                        image[0].sprite = sprites[7];
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
//                    }


//                }
//                else
//                {
//                    uiList.Clear();
//                    uiList.AddRange(InputHandler.recentInputs);
//                    Debug.Log("List NICHT Sync");
//                        image[0].sprite = sprites[8];
//                    for (int f = 16, g = 15; g >= 1; f--, g--)
//                    {
//                        image[f].sprite = image[g].sprite;
//                    }
//                }

//            }
//            else if (Uiinput == recentInputs)
//            {
//                Debug.Log("List in Sync");
//            }

//        }
//    }
//}
