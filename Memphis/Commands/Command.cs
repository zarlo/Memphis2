using Memphis.Interface;

namespace Memphis.Commands
{
    public abstract class Command : IFeature, IExecutable
    {
        internal FeatureInfo feature;
        internal IShell currentShell;

        public abstract string Id { get; }

        public Command()
        {
            feature.FeatureDescription = "An internal command.";
            feature.FeatureName = "Command";
            feature.FeatureVersion = "0.0.1";
        }

        public FeatureInfo GetInfo()
        {
            return feature;
        }

        public void SetShell(IShell shell)
        {
            currentShell = shell;
        }

        public abstract void Main(string[] args);

        public void Work()
        {
            Main(new string[1]);
        }

        public void Load()
        {

        }
    }
}
