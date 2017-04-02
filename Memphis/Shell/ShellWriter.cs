using System;
using Memphis.Interface;

namespace Memphis.Shell
{
    public class ShellWriter : IFeature
    {
        public ShellWriter()
        {
            feature.FeatureName = "Shell Writer";
            feature.FeatureDescription = "Writes text from the shell to the console.";
            feature.FeatureVersion = "0.0.1";
        }
        FeatureInfo feature;
        public FeatureInfo GetInfo()
        {
            return feature;
        }

        public void Load()
        {
        }

        public void Work()
        {
            Console.Write(new string(((DefaultShell)Kernel.features["Default Shell"]).GetOutput()));
        }
    }
}
