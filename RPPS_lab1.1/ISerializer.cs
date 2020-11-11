using System;
using System.Collections.Generic;
using System.Text;

namespace RPPS_lab1._1
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string obj);
    }
}
