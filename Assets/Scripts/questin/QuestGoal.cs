using System;
namespace Claire
{
    [Serializable]
    public class QuestGoal
    {
        public GoalType goalType;
        public QuestState questState;
        public string enemyType;
        public int itemID;
        public int requiredAmount;
        public int currentAmount;
        public bool isReached;
        public void EnemyKilled(string type)
        {
            if(goalType == GoalType.Kill && type == enemyType)
            {
                currentAmount++;
                if(currentAmount>=requiredAmount)
                {
                    isReached = true;
                    questState = QuestState.Complete;
                }
            }
        }
        public void ItemCollected(int id)
        {
            if(goalType == GoalType.Collect && id == itemID)
            {
                currentAmount++;
                if (currentAmount >= requiredAmount)
                {
                    isReached = true;
                    questState = QuestState.Complete;
                }
            }
        }
    }
    public enum GoalType
    {
        Kill,
        Collect,
    };
    public enum QuestState
    {
        Available,
        Active,
        Complete,
        Claimed
    }
}