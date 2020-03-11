using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockOut
{

    /// <summary>
    ///   Вход  в  систему
    /// </summary>
    [Serializable]
    public class LockOutcs
    {
        /// <summary>
        /// время входа
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// пользователь
        /// </summary>
        public User  User{ get; set; }

        /// <summary>
        /// статус
        /// </summary>
        public bool  Status { get; set; }

        /// <summary>
        /// вводимый  логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// вводимый пароль
        /// </summary>
        public string Pass { get; set; }

    }
}
