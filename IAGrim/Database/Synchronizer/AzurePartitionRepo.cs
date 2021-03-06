﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAGrim.Database.DAO;
using IAGrim.Database.Interfaces;

namespace IAGrim.Database.Synchronizer {
    class AzurePartitionRepo : BasicSynchronizer<AzurePartition>, IAzurePartitionDao {
        public AzurePartitionRepo(ThreadExecuter threadExecuter, ISessionCreator sessionCreator) : base(threadExecuter, sessionCreator) {
            IAzurePartitionDao repo = new AzurePartitionDaoImpl(sessionCreator);
            this.BaseRepo = repo;
        }
    }
}
