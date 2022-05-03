using UnityEngine;
using System.Collections.Generic;

namespace GenLibrary
{
    public enum TeamDamageable
    {
        Neitral,
        Command1,
        Command2
    }

    public enum RelationTypes
    {
        Default,
        Friends,
        Enemies
    }

    [System.Serializable]
    public struct CollisionPair
    {
        public TeamsPair teamsPair;
        public RelationTypes relationType;
    }

    [System.Serializable]
    public struct TeamsPair
    {
        public TeamDamageable command1;
        public TeamDamageable command2;
    }

    public interface IRelationsReams
    {
        public RelationTypes GetRelationTypes(TeamsPair _someTeamsPair);
    }

    [System.Serializable]
    public class RelationsTeams : IRelationsReams
    {
        [SerializeField]
        public TeamDamageable testserf;
        //[SerializeField]
        //public Dictionary<int, string> testserfDictionary = new Dictionary<int, string>();

        public Dictionary<TeamsPair, CollisionPair> currentTeamsRelation; // = new Dictionary<TeamDamageable, CollisionPair>();
        //public Dictionary<TeamDamageable, CollisionPair> testOnlyShow;

        public List<CollisionPair> currentCollisionPairs = new List<CollisionPair>();
        public List<CollisionPair> testListLog = new List<CollisionPair>();

        //public List<CollisionPair> new_currentCollisionPairs = new List<CollisionPair>();
        //public List<CollisionPair> new_testListLog = new List<CollisionPair>();

        public void call_Convert_List_To_Dictionary()
        {
            Convert_List_To_Dictionary(currentTeamsRelation, currentCollisionPairs);
        }

        public void call_Convert_Dictionary_To_List()
        {
            call_Convert_List_To_Dictionary();

            Convert_Dictionary_To_List(currentTeamsRelation, currentCollisionPairs);
        }

        public void Convert_Dictionary_To_List(Dictionary<TeamsPair, CollisionPair> _currentTeamsRelation, List<CollisionPair> _currentCollisionPairs)
        {
            testListLog.Clear();
            foreach (var item in currentTeamsRelation)
            {
                testListLog.Add(item.Value);
            }

        }

        public void Convert_List_To_Dictionary(Dictionary<TeamsPair, CollisionPair> _currentTeamsRelation, List<CollisionPair> _currentCollisionPairs)
        {
            currentTeamsRelation = new Dictionary<TeamsPair, CollisionPair>();
            foreach (var item in currentCollisionPairs)
            {
                TeamsPair key = item.teamsPair;
                CollisionPair outPair = default;

                if (currentTeamsRelation.TryGetValue(key, out outPair))
                    continue;
                else
                    currentTeamsRelation.Add(key, item);
            }
            TestInitDictionaryToStringForLog();
        }

        public string testlogdictionarystr;
        private void TestInitDictionaryToStringForLog()
        {
            string testLogDictionary = "";
            if (currentTeamsRelation == null)
            {
                testlogdictionarystr = "null";
                return;
            }
            foreach (var item in currentTeamsRelation)
            {
                testLogDictionary += "com1=" + item.Value.teamsPair.command1 + " com2=" + item.Value.teamsPair.command2 + " rel=" + item.Value.relationType + "\n";
            }
            testlogdictionarystr = testLogDictionary;
            Debug.Log("testlogdictionarystr " + testlogdictionarystr);
        }

        public RelationTypes GetRelationTypes(TeamsPair _someTeamsPair)
        {
            return default;
            //currentTeamsRelation.TryGetValue    
        }

        //{

        //}
    }
}

