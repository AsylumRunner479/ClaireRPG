using System;
namespace Claire
{
    [Serializable]
    public class Quest
    {
        public string title;
        public string description;
        public int xpReward;
        public int yenReward;
        public QuestGoal goal;
    }
}