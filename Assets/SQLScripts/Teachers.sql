CREATE TABLE IF NOT EXISTS `teachers` (
                            `id` int NOT NULL AUTO_INCREMENT,
                            `name` varchar(45) DEFAULT NULL,
                            `family` varchar(45) DEFAULT NULL,
                            `mdlname` varchar(45) DEFAULT NULL,
                            `position` varchar(45) DEFAULT NULL,
                            `login` varchar(45) DEFAULT NULL,
                            `password` varchar(45) DEFAULT NULL,
                            `ipaddress` varchar(45) DEFAULT NULL,
                            `regtime` datetime DEFAULT NULL,
                            `choosed` tinyint(1) NOT NULL DEFAULT '0',
                            PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
