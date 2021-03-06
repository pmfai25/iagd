﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAGrim.Database.DAO.Table;
using log4net;
using NHibernate;

namespace IAGrim.Database.Migrations {
    class DatabaseItemHashFixMigration : IDatabaseMigration {

        /// <summary>
        /// When the hash field got introduced, some users ended up with a NULL value, causing issues when later on fetching using "record || hash"
        /// </summary>
        /// <param name="sessionCreator"></param>
        public void Migrate(ISessionCreator sessionCreator) {
            using (ISession session = sessionCreator.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    session.CreateSQLQuery(
                        $"UPDATE {DatabaseItemTable.Table} SET {DatabaseItemTable.Hash} = 0 WHERE {DatabaseItemTable.Hash} IS NULL"
                    ).ExecuteUpdate();

                    transaction.Commit();
                }
            }
        }
    }
}
