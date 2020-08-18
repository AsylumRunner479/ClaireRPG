using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
namespace Claire
{
    public static class PlayerBinary
    {
        public static void SavePlayerData(PlayerHandler player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/kittens.jpeg"; //persistentDataPath + "/" + "kittens" + ".jpeg"
            FileStream stream = new FileStream(path, FileMode.Create);
            PlayerData data = new PlayerData(player);
            formatter.Serialize(stream, data);
            stream.Close();
        }
        public static PlayerData LoadedPlayerData(PlayerHandler player)
        {
            string path = Application.persistentDataPath + "/kittens.jpeg";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Create);
                PlayerData data = new PlayerData(player);
                stream.Close();
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}