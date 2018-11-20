using System;
using System.Collections.Generic;
using System.Text;

namespace NewFAHP.Lib
{
    public sealed class SchoolFactory
    {
        private static readonly object key = new object();

        private static List<School> schools;
        public static List<School> Schools
        {
            get
            {
                if (schools == null)
                {
                    lock (key)
                    {
                        if (schools == null)
                        {
                            schools = new List<School>
                            {

                            };
                        }
                    }
                }
                return schools;
            }
        }


    }
}
