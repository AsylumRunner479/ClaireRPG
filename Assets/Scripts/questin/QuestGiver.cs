using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    public class QuestGiver : MonoBehaviour
    {
        public Quest quest;
        public PlayerHandler player;
        public KinInventory inv;
        public GameObject questWindow;
        public Text titleText, desText, xpText, yenText;
        public void OpenQuestWindow()
        {
            questWindow.SetActive(true);
            titleText.text = quest.title;
            desText.text = quest.description;
            xpText.text = quest.xpReward.ToString();
            yenText.text = "¥" + quest.yenReward.ToString();
        }
        public void AcceptQuest()
        {
            quest.goal.questState = QuestState.Active;
            questWindow.SetActive(false);
            player.currentQuest = quest;
        }
        public void ClaimQuest()
        {
            player.currentExp += quest.xpReward;
            inv.money += quest.yenReward;
            quest.goal.questState = QuestState.Claimed;
        }
    }
}