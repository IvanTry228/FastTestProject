namespace GenLibrary
{
    [System.Serializable]
    public struct FilterCheckCommunication
    {
        public bool isForciblyWithoutTrigger;

        public bool isTagFilter;
        public bool isLayerFilter;
        public bool isComponentFilter;
    }
}
