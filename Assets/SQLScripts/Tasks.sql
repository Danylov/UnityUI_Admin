CREATE TABLE IF NOT EXISTS `tasks` (
                            `id` int NOT NULL AUTO_INCREMENT,
                            `name` varchar(45) DEFAULT NULL,
                            `path` varchar(45) DEFAULT NULL,
                            PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci; 