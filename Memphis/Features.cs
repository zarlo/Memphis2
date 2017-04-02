using System.Collections.Generic;

using Memphis.Exceptions;
using Memphis.Interface;

namespace Memphis
{
    public class Features
    {
        List<IFeature> _Features = new List<IFeature>();
        public IFeature this[string index]
        {
            get
            {
                foreach (IFeature feature in _Features)
                {
                    if (feature.GetInfo().FeatureName.ToLower() == index.ToLower())
                        return feature;
                }
                throw new FeatureNotFoundException();
            }
        }
        public void AddFeature(IFeature feature)
        {
            feature.Load();
            _Features.Add(feature);
        }
    }
}