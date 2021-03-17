CREATE TABLE IF NOT EXISTS `students` (
                            `id` int NOT NULL AUTO_INCREMENT,
                            `fullname` varchar(45) DEFAULT NULL,
                            `organiztype` varchar(45) DEFAULT NULL,
                            `position` varchar(45) DEFAULT NULL,
                            `persnumber` int DEFAULT NULL,
                            `login` varchar(45) DEFAULT NULL,
                            `password` varchar(45) DEFAULT NULL,
                            `ipaddress` varchar(45) DEFAULT NULL,
                            `choosed` tinyint(1) NOT NULL DEFAULT '0',
                            PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci; 