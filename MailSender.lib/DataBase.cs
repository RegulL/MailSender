﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib
{
    /// <summary>
    /// Класс для работы с базой данных, с использованием Linq2SQL
    /// </summary>
    class DataBase
    {
        MailSenderDB SenderDB = new MailSenderDB();
        public IQueryable<Recepient> recepients
        {
            get
            {
                return from r in SenderDB.Recepient select r;
            }
        }
    }
}
