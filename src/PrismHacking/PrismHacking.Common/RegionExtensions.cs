using Prism.Regions;
using System;

namespace PrismHacking.Common
{
    public static class RegionExtensions
    {
        public static void RemoveAllViews(this IRegion region)
        {
            /*
              * If KeepAlive == false we must deactiveate rather than trying to remove it.
              * KeepAlive can be set by implementing IRegionMemberLifetime interface, or by setting the KeepAlive attribute, 
              * so we must check both. 
              * Use reflection to determine if the view has a KeepAlive attribute, and if it does, then is KeepAlive == false. 
              * 
             * */
            foreach (object view in region.Views)
            {
                Type type = view.GetType();
                if (null != Attribute.GetCustomAttribute(type, typeof(RegionMemberLifetimeAttribute)))
                {
                    RegionMemberLifetimeAttribute attribute = (RegionMemberLifetimeAttribute)Attribute.GetCustomAttribute(type, typeof(RegionMemberLifetimeAttribute));
                    if (attribute.KeepAlive == false)
                        region.Deactivate(view);
                }
                else if (view is IRegionMemberLifetime && !((IRegionMemberLifetime)view).KeepAlive)
                {
                    region.Deactivate(view);
                }
                else //This is not an item that has KeepAlive set to false so remove it
                {
                    region.Remove(view);
                }
            }
        }
    }
}
