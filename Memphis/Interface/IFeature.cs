namespace Memphis.Interface
{
    public interface IFeature
    {
        FeatureInfo GetInfo();
        void Load();
        void Work();
    }
    public struct FeatureInfo
    {
        public string FeatureName;
        public string FeatureDescription;
        public string FeatureVersion;
    }
}
