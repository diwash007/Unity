
using UnityEngine;

namespace SaveLoad
{
    public static class SaveLoadScore
    {
        public static void SaveHighScore(int score)
        {
            PlayerPrefs.SetInt(Tags.SaveScore, score);
        }
        
        public static int LoadHighScore()
        {
            return !PlayerPrefs.HasKey(Tags.SaveScore) ? 0 : PlayerPrefs.GetInt(Tags.SaveScore);
        }
    }
}