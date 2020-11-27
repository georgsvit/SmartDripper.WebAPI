using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Options
{
    public class CultureOptions
    {
        public const string SectionName = "CultureOptions";

        public string[] SupportedCultures { get; set; }
        public string DefaultCulture { get; set; }
    }
}
