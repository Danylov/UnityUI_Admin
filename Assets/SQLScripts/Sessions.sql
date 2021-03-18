CREATE TABLE IF NOT EXISTS `sessions` (
                            `id` int unsigned NOT NULL,
                            `teacherid` int DEFAULT NULL,
                            `studentid` int DEFAULT NULL,
                            `begtime` datetime DEFAULT NULL,
                            `endtime` datetime DEFAULT NULL,
                            `taskname` varchar(45) DEFAULT NULL,
                            PRIMARY KEY (`id`),
                            KEY `studentid_fk_idx` (`studentid`),
                            KEY `teacherid_fk_idx` (`teacherid`),
                            CONSTRAINT `studentid_fk` FOREIGN KEY (`studentid`) REFERENCES `students` (`id`),
                            CONSTRAINT `teacherid_fk` FOREIGN KEY (`teacherid`) REFERENCES `teachers` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci