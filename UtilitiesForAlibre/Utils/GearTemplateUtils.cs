using Bolsover.Involute.Model;

namespace Bolsover.Utils
{
    public class GearTemplateUtils
    {
        public (string SaveFile, string Template) TemplateFileStrings(GearStyle style)
        {
            switch (style)
            {
                case GearStyle.ExternalSpurGear:
                    return ("WheelPleaseSaveAs.AD_PRT", "WheelTemplate.AD_PRT");
                case GearStyle.ExternalSpurPinion:
                    return ("PinionPleaseSaveAs.AD_PRT", "PinionTemplate.AD_PRT");
                case GearStyle.ExternalHelicalGear:
                    return ("HelicalPinionPleaseSaveAs.AD_PRT", "WheelTemplate.AD_PRT");
                case GearStyle.ExternalHelicalPinion:
                    return ("PinionPleaseSaveAs.AD_PRT", "PinionTemplate.AD_PRT");
            }
            
            return (null, null);
        }
    }
}