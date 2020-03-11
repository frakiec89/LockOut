using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockOut
{
    
    /// <summary>
    /// пользователь  
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// логин
        /// </summary>
        public string Log { get; set; } 
        /// <summary>
        /// пароль
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// имя
        /// </summary>
        public string Name { get; set; }

    }
}
