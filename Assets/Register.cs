using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{

    public enum LevelResults { Win, Fail, Skip };
    public enum LevelGoal { Win, Fail, Skip };
    public enum LevelTopic { Affiliation, Homecoming, Relief, Friends, Rest, Trust, Playfulness};
    public int[] floors;
    private byte nextfloor;
    public bool[] completion;
    public static Register register { get; set; }

    void Awake()
    {
        int numberOfRegisters = FindObjectsOfType<Register>().Length;
        //if(numberOfRegisters > 1)
        if(register != null)
        {
            print("New Register deleted.");
            Destroy(gameObject);
        }
        else
        {
            print("Setting singleton register.");
            register = this as Register;
            completion = new bool[] { false, false, false, false, false, false, false, false, false };
            floors = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            nextfloor = 0;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LevelCheck(LevelResults results, LevelGoal goal, int buildingBlock, LevelTopic topic)
    {
        print("Requested Level check from "+ topic.ToString() + ": "+results.ToString()+", "+goal.ToString()+", "+buildingBlock.ToString());
        if ((results == LevelResults.Win && goal == LevelGoal.Win)
            || (results == LevelResults.Fail && goal == LevelGoal.Fail)
                || (results == LevelResults.Skip && goal == LevelGoal.Skip))
        {
            floors[nextfloor] = buildingBlock;
            /*print("House upgraded: "+ floors[0].ToString() + floors[1].ToString() + floors[2].ToString() + floors[3].ToString()
                + floors[4].ToString() + floors[5].ToString() + floors[6].ToString() + floors[7].ToString() + floors[8].ToString());*/
            nextfloor++;
        }
        completion[(int)topic] = true;
        print("Levels completed: "+completion[0].ToString() + completion[1].ToString() + completion[2].ToString()
            + completion[3].ToString() + completion[4].ToString() + completion[5].ToString() + completion[6].ToString()
            + completion[7].ToString() + completion[8].ToString());
    }

    public void Roof()
    {
        floors[nextfloor] = 99;
    }

}
