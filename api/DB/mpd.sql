CREATE DATABASE IF NOT EXISTS db_books;

USE db_books;

-- MySQL dump 10.13  Distrib 8.3.0, for Linux (x86_64)
--
-- Host: localhost    Database: db_books
-- ------------------------------------------------------
-- Server version	8.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `t_authors`
--

DROP TABLE IF EXISTS `t_authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_authors` (
  `id_author` int NOT NULL AUTO_INCREMENT,
  `autFirstName` varchar(50) NOT NULL,
  `autLastName` varchar(50) NOT NULL,
  PRIMARY KEY (`id_author`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_authors`
--

LOCK TABLES `t_authors` WRITE;
/*!40000 ALTER TABLE `t_authors` DISABLE KEYS */;
INSERT INTO `t_authors` VALUES (1,'J.K.','Rowling'),(2,'Stephen','King'),(3,'George','Orwell'),(4,'Douglas','Kennedy'),(5,'George','Orwell'),(6,'J.R.R.','Tolkien'),(7,'Agatha','Christie'),(8,'Fyodor','Dostoevsky'),(9,'Jane','Austen'),(10,'Leo','Tolstoy'),(11,'Mark','Twain'),(12,'Charles','Dickens'),(13,'Gabriel Garca','Mrquez'),(14,'Harper','Lee');
/*!40000 ALTER TABLE `t_authors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_books`
--
CREATE DATABASE IF NOT EXISTS db_books;

USE db_books;

DROP TABLE IF EXISTS `t_books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_books` (
  `id_book` int NOT NULL AUTO_INCREMENT,
  `booTitle` varchar(100) NOT NULL,
  `booPageCount` int NOT NULL,
  `booExcerpt` varchar(500) DEFAULT NULL,
  `booSummary` varchar(900) DEFAULT NULL,
  `booAvgRating` decimal(3,2) DEFAULT NULL,
  `booCoverImage` varchar(300) DEFAULT NULL,
  `booPublishDate` date NOT NULL,
  `fk_user` int NOT NULL,
  `fk_publisher` int NOT NULL,
  PRIMARY KEY (`id_book`),
  KEY `fk_user` (`fk_user`),
  KEY `fk_publisher` (`fk_publisher`),
  CONSTRAINT `t_books_ibfk_1` FOREIGN KEY (`fk_user`) REFERENCES `t_users` (`id_user`),
  CONSTRAINT `t_books_ibfk_2` FOREIGN KEY (`fk_publisher`) REFERENCES `t_publishers` (`id_publisher`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_books`
--

LOCK TABLES `t_books` WRITE;
/*!40000 ALTER TABLE `t_books` DISABLE KEYS */;
INSERT INTO `t_books` VALUES (1,'Harry Potter and the Philosopher\'s Stone',320,'https://pbs.twimg.com/media/EPUBZ-xX4AA4HGK.png','Harry Potter has no idea how famous he is. That\'s because he\'s being raised by his miserable aunt and uncle who are terrified Harry will learn that he\'s really a wizard, just as his parents were. But everything changes when Harry is summoned to attend an infamous school for wizards, and he begins to discover some clues about his illustrious birthright. From the surprising way he is greeted by a lovable giant, to the unique curriculum and colorful faculty at his unusual school.',4.50,'https://m.media-amazon.com/images/I/71RVt35ZAbL._AC_UF1000,1000_QL80_.jpg','1997-06-26',1,1),(2,'The Shining',447,'https://miro.medium.com/v2/resize:fit:1400/1*zF6Ap40T1VB-86rIoZfx5A.png','A psychological horror novel by Stephen King, \"The Shining\" tells the story of Jack Torrance, an aspiring writer and recovering alcoholic who takes a job as the winter caretaker of the Overlook Hotel, a remote and haunted resort in the Colorado Rockies.',4.20,'https://exlibris.azureedge.net/covers/9783/4041/3089/4/9783404130894xl.webp','1977-01-28',2,2),(3,'1984',328,'https://i.pinimg.com/originals/87/65/75/8765751d9c3c99ad58990387a42ff84b.jpg','Winston Smith works for the Ministry of Truth in London, chief city of Airstrip One. Big Brother stares out from every poster, the Thought Police uncover every act of betrayal. When Winston finds love with Julia, he discovers that life does not have to be dull and deadening, and awakens to new possibilities. Despite the police helicopters that hover and circle overhead, Winston and Julia begin to question the Party; they are drawn towards conspiracy. Yet Big Brother will not tolerate dissent - even in the mind. For those with original thoughts they invented Room 101...',4.80,'https://d30a6s96kk7rhm.cloudfront.net/original/readings/978/014/103/9780141036144.jpg','1949-06-08',3,3),(4,'The Dead Heart',208,'That dumbshit map. I`d been seduced by it. Seduced by its possibilities. \nThat map had brought me here ...That map had been a serious mistake`','The map in question is of Australia, \nstumbled across in a second-hand bookshop by American journalist Nick Hawthorne, en route to another dead-end hack job in Akron, \nOhio. Seduced by all that wilderness, all that NOTHING, Nick decides to put his midlife crisis on hold and light out to the ultimate \nnowheresville - where a chance encounter throws him into a sun-baked orgy of surf, sex and swill, and a nightmare from which there is no escape. \n`Douglas Kennedy might never be allowed into Australia again. This is a crazy, compulsive ultimately serious thriller and a bravura fictional \ndebut from one of our best travel writers` Philip Kerr',4.80,'https://m.media-amazon.com/images/I/81-NNnKYezL._AC_UF1000,1000_QL80_.jpg','1995-04-13',4,4),(14,'The Lord of the Rings',1178,'https://images.squarespace-cdn.com/content/v1/57b71e086a49637a9109a3f9/1533136945543-PIIP69JJUQ03YRDYJ9GS/Fellowship+of+the+Ring+Excerpt.JPG','An epic high fantasy novel that follows the quest to destroy the One Ring and defeat the Dark Lord Sauron.',4.60,'https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1566425108l/33.jpg','1954-07-29',1,1),(15,'Murder on the Orient Express',256,'https://img.yumpu.com/44658851/1/500x640/murder-on-the-orient-express.jpg','A classic detective novel featuring the Belgian detective Hercule Poirot, who investigates a murder on a luxurious train.',4.20,'https://m.media-amazon.com/images/I/71ihbKf67RL._AC_UF1000,1000_QL80_.jpg','1934-01-01',1,1),(16,'Crime and Punishment',545,'https://welovetranslations.com/wp-content/uploads/2020/04/crime-and-punishment-extract-magarshack.jpg?ezimgfmt=rs:372x463/rscb1/ng:webp/ngcb1','A psychological thriller that explores the moral dilemmas of Rodion Raskolnikov, a poor ex-student in St. Petersburg.',4.50,'https://m.media-amazon.com/images/I/71O2XIytdqL._AC_UF1000,1000_QL80_.jpg','1866-11-14',1,1),(17,'Pride and Prejudice',432,'https://www.nls.uk/media-u4/1083315/pride-and-prejudice-first-page.png','A romantic novel that follows the emotional development of Elizabeth Bennet, who learns the repercussions of hasty judgments and eventually finds love.',4.40,'https://themarblefaunbooksandgifts.com/cdn/shop/products/Peacock_Cover_glitter_card_5_x_7.jpg?v=1571638712','1813-01-28',1,1),(18,'War and Peace',1225,'https://onehundredpages.files.wordpress.com/2018/11/7.jpeg?w=640&h=853','An epic historical novel that chronicles the impact of the Napoleonic era on Russian society through the lives of several aristocratic families.',4.70,'https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781524864989/war-and-peace-9781524864989_hr.jpg','1869-01-01',1,1),(19,'Adventures of Huckleberry Finn',366,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSit3__BcEdFelpnVgPpL3uvKHA3C5s-gHvk4hb4odsWQ&s','A novel that follows the adventures of a young boy named Huck Finn and a runaway slave named Jim as they travel down the Mississippi River.',4.20,'https://m.media-amazon.com/images/I/91sBZnKzEfL._AC_UF1000,1000_QL80_DpWeblab_.jpg','1884-12-10',1,1),(20,'Great Expectations',544,'https://assets2.titleleaf.com/lerner/product/spread/xl_9781467751872_int.jpg','A bildungsroman that follows the life and moral development of an orphan named Pip as he navigates the social hierarchy of Victorian England.',4.30,'https://images.penguinrandomhouse.com/cover/9780143106272','1861-01-01',1,1),(21,'One Hundred Years of Solitude',417,'https://www.bookxcess.com/cdn/shop/products/9780241972359_5.jpg?v=1649841184','A landmark novel that tells the multi-generational story of the Buenda family in the fictional town of Macondo.',4.60,'https://s26162.pcdn.co/wp-content/uploads/2018/02/100_Years_First_Ed_Hi_Res-768x1153.jpg','1967-05-30',1,1),(22,'To Kill a Mockingbird',324,'https://s3.studylib.net/store/data/008000832_1-192d51c7630257123e10728ad4fbdf6b-768x994.png','A coming-of-age story set in the racially charged atmosphere of the American South during the 1930s, where a young girl learns about empathy and morality.',4.50,'https://media.glamour.com/photos/56e1f3c462b398fa64cbd304/master/w_1600%2Cc_limit/entertainment-2016-02-18-main.jpg','1960-07-11',1,1);
/*!40000 ALTER TABLE `t_books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_categories`
--

DROP TABLE IF EXISTS `t_categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_categories` (
  `id_category` int NOT NULL AUTO_INCREMENT,
  `catName` varchar(50) NOT NULL,
  PRIMARY KEY (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_categories`
--

LOCK TABLES `t_categories` WRITE;
/*!40000 ALTER TABLE `t_categories` DISABLE KEYS */;
INSERT INTO `t_categories` VALUES (1,'Fantasy'),(2,'Horror'),(3,'Dystopian'),(4,'Suspense'),(5,'Fiction'),(6,'Thriller'),(7,'Science Fiction'),(8,'Children\'s literature'),(9,'Novel');
/*!40000 ALTER TABLE `t_categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_categorize`
--

DROP TABLE IF EXISTS `t_categorize`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_categorize` (
  `fk_book` int NOT NULL,
  `fk_category` int NOT NULL,
  PRIMARY KEY (`fk_book`,`fk_category`),
  KEY `fk_category` (`fk_category`),
  CONSTRAINT `t_categorize_ibfk_1` FOREIGN KEY (`fk_book`) REFERENCES `t_books` (`id_book`),
  CONSTRAINT `t_categorize_ibfk_2` FOREIGN KEY (`fk_category`) REFERENCES `t_categories` (`id_category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_categorize`
--

LOCK TABLES `t_categorize` WRITE;
/*!40000 ALTER TABLE `t_categorize` DISABLE KEYS */;
INSERT INTO `t_categorize` VALUES (1,1),(3,3),(4,4),(4,5),(4,6),(3,7),(1,8),(1,9),(2,9);
/*!40000 ALTER TABLE `t_categorize` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_publishers`
--

DROP TABLE IF EXISTS `t_publishers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_publishers` (
  `id_publisher` int NOT NULL AUTO_INCREMENT,
  `pubName` varchar(50) NOT NULL,
  PRIMARY KEY (`id_publisher`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_publishers`
--

LOCK TABLES `t_publishers` WRITE;
/*!40000 ALTER TABLE `t_publishers` DISABLE KEYS */;
INSERT INTO `t_publishers` VALUES (1,'Bloomsbury'),(2,'Penguin Random House'),(3,'HarperCollins'),(4,'Abacus Books');
/*!40000 ALTER TABLE `t_publishers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_review`
--

DROP TABLE IF EXISTS `t_review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_review` (
  `fk_book` int NOT NULL,
  `fk_user` int NOT NULL,
  `revDate` date NOT NULL,
  `revComment` varchar(900) DEFAULT NULL,
  `revRating` decimal(3,2) NOT NULL,
  PRIMARY KEY (`fk_book`,`fk_user`),
  KEY `fk_user` (`fk_user`),
  CONSTRAINT `t_review_ibfk_1` FOREIGN KEY (`fk_book`) REFERENCES `t_books` (`id_book`),
  CONSTRAINT `t_review_ibfk_2` FOREIGN KEY (`fk_user`) REFERENCES `t_users` (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_review`
--

LOCK TABLES `t_review` WRITE;
/*!40000 ALTER TABLE `t_review` DISABLE KEYS */;
INSERT INTO `t_review` VALUES (1,1,'2023-06-15','Amazing book, loved every page!',5.00),(2,2,'2023-08-01','Terrifying! Couldn\'t put it down.',4.00),(3,3,'2023-10-20','A classic that everyone should read.',5.00),(4,4,'2024-03-19','Had to read this book for ECG class and I really enjoyed it.',5.00);
/*!40000 ALTER TABLE `t_review` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_users`
--

DROP TABLE IF EXISTS `t_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_users` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `usePseudo` varchar(50) NOT NULL,
  `usePassword` varchar(50) NOT NULL,
  `useJoinDate` date NOT NULL,
  `useBookCount` int NOT NULL,
  `useReviewCount` int NOT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_users`
--

LOCK TABLES `t_users` WRITE;
/*!40000 ALTER TABLE `t_users` DISABLE KEYS */;
INSERT INTO `t_users` VALUES (1,'booklover123','password123','2023-05-10',10,5),(2,'reader456','securepass','2023-07-20',5,2),(3,'bibliophile789','strongpassword','2023-09-15',15,8),(4,'ethanschafstall','password123','2023-09-15',15,8);
/*!40000 ALTER TABLE `t_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_wrote`
--

DROP TABLE IF EXISTS `t_wrote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_wrote` (
  `fk_book` int NOT NULL,
  `fk_author` int NOT NULL,
  PRIMARY KEY (`fk_book`,`fk_author`),
  KEY `fk_author` (`fk_author`),
  CONSTRAINT `t_wrote_ibfk_1` FOREIGN KEY (`fk_book`) REFERENCES `t_books` (`id_book`),
  CONSTRAINT `t_wrote_ibfk_2` FOREIGN KEY (`fk_author`) REFERENCES `t_authors` (`id_author`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_wrote`
--

LOCK TABLES `t_wrote` WRITE;
/*!40000 ALTER TABLE `t_wrote` DISABLE KEYS */;
INSERT INTO `t_wrote` VALUES (1,1),(2,2),(3,3),(4,4);
/*!40000 ALTER TABLE `t_wrote` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-27 11:49:56
