using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitializeData
{
    
    public class InitializeDataList : MonoBehaviour
    {
        //値データ群
        [System.Serializable]
        public struct PlayerData
        {
            [SerializeField]
            private static float MaxHP = 100;
            [SerializeField]
            private static float AssultDamege = 30;

            public float getHP() { return MaxHP; }
            public float getAssultDamege() { return AssultDamege; }
        }
        [System.Serializable]
        public struct EnemyData
        {
            [SerializeField]
            private static float MaxHP = 120;
            [SerializeField]
            private static float BulletDamege = 10;

            public float getHP() { return MaxHP; }
            public float getBulletDamege() { return BulletDamege; }
        }


        // ---- 実体宣言 ----
        public static PlayerData InitializePlayerData;
        public static EnemyData InitializeEnemyData;

    }
}